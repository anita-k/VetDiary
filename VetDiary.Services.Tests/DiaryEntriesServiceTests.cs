using VetDiary.Data.Models;
using VetDiary.Shared;
using VetDiary.ViewModels.DiaryEntry;

namespace VetDiary.Services.Tests
{
    public class DiaryEntriesServiceTests
    {
        private static (Client client, Species species, Breed breed, Pet pet, VisitReason visitReason) SeedFullData(Data.ApplicationDbContext context)
        {
            var species = new Species { Name = "Dog" };
            context.Species.Add(species);
            context.SaveChanges();

            var breed = new Breed { Name = "Labrador", SpeciesId = species.Id };
            context.Breeds.Add(breed);
            context.SaveChanges();

            var client = new Client { FirstName = "John", LastName = "Doe", Phone = "1234567890", Email = "john@test.com" };
            context.Clients.Add(client);
            context.SaveChanges();

            var pet = new Pet
            {
                Name = "Buddy",
                Gender = PetGender.Male,
                ClientId = client.Id,
                SpeciesId = species.Id,
                BreedId = breed.Id
            };
            context.Pets.Add(pet);
            context.SaveChanges();

            var visitReason = new VisitReason { Name = "Checkup" };
            context.VisitReasons.Add(visitReason);
            context.SaveChanges();

            return (client, species, breed, pet, visitReason);
        }

        [Fact]
        public async Task GetAllDiaryEntriesAsync_ReturnsAllWithRelatedData()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, breed, pet, visitReason) = SeedFullData(context);

            context.DiaryEntries.AddRange(
                new DiaryEntry { PetId = pet.Id, VisitDate = DateTime.Now, VisitReasonId = visitReason.Id, Description = "Entry 1" },
                new DiaryEntry { PetId = pet.Id, VisitDate = DateTime.Now.AddDays(-1), VisitReasonId = visitReason.Id, Description = "Entry 2" }
            );
            await context.SaveChangesAsync();
            var service = new DiaryEntriesService(context);

            // Act
            var result = (await service.GetAllDiaryEntriesAsync()).ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, e => Assert.NotNull(e.Pet));
            Assert.All(result, e => Assert.NotNull(e.Pet.Client));
            Assert.All(result, e => Assert.NotNull(e.Pet.Species));
            Assert.All(result, e => Assert.NotNull(e.VisitReason));
        }

        [Fact]
        public async Task GetAllDiaryEntriesAsync_Paginated_ReturnsPaginatedResults()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (_, _, _, pet, visitReason) = SeedFullData(context);

            for (int i = 1; i <= 5; i++)
            {
                context.DiaryEntries.Add(new DiaryEntry
                {
                    PetId = pet.Id,
                    VisitDate = DateTime.Now.AddDays(-i),
                    VisitReasonId = visitReason.Id,
                    Description = $"Entry {i}"
                });
            }
            await context.SaveChangesAsync();
            var service = new DiaryEntriesService(context);

            // Act
            var result = await service.GetAllDiaryEntriesAsync(page: 1, pageSize: 2);

            // Assert
            Assert.Equal(2, result.Items.Count);
            Assert.Equal(5, result.TotalCount);
        }

        [Fact]
        public async Task GetAllDiaryEntriesAsync_WithSearchTerm_FiltersByPetNameOrDescription()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, breed, pet, visitReason) = SeedFullData(context);

            var pet2 = new Pet { Name = "Max", ClientId = client.Id, SpeciesId = species.Id };
            context.Pets.Add(pet2);
            await context.SaveChangesAsync();

            context.DiaryEntries.AddRange(
                new DiaryEntry { PetId = pet.Id, VisitDate = DateTime.Now, VisitReasonId = visitReason.Id, Description = "Routine" },
                new DiaryEntry { PetId = pet2.Id, VisitDate = DateTime.Now, VisitReasonId = visitReason.Id, Description = "Special" }
            );
            await context.SaveChangesAsync();
            var service = new DiaryEntriesService(context);

            // Act
            var result = await service.GetAllDiaryEntriesAsync(page: 1, pageSize: 10, searchTerm: "Buddy");

            // Assert
            Assert.Single(result.Items);
        }

        [Fact]
        public async Task GetAllDiaryEntriesAsync_WithVisitReasonIdFilter_FiltersByVisitReason()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (_, _, _, pet, visitReason) = SeedFullData(context);

            var otherReason = new VisitReason { Name = "Surgery" };
            context.VisitReasons.Add(otherReason);
            await context.SaveChangesAsync();

            context.DiaryEntries.AddRange(
                new DiaryEntry { PetId = pet.Id, VisitDate = DateTime.Now, VisitReasonId = visitReason.Id },
                new DiaryEntry { PetId = pet.Id, VisitDate = DateTime.Now, VisitReasonId = otherReason.Id }
            );
            await context.SaveChangesAsync();
            var service = new DiaryEntriesService(context);

            // Act
            var result = await service.GetAllDiaryEntriesAsync(page: 1, pageSize: 10, visitReasonId: otherReason.Id);

            // Assert
            Assert.Single(result.Items);
            Assert.Equal(otherReason.Id, result.Items.First().VisitReasonId);
        }
    }
}        