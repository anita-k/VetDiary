using VetDiary.Data.Models;
using VetDiary.Shared;
using VetDiary.ViewModels.DiaryEntry;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            // First three variables are discarded with _ to avoid unused variable warnings
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
            // First three variables are discarded with _ to avoid unused variable warnings
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

        [Fact]
        public async Task GetDiaryEntryDetailsByIdAsync_ReturnsEntryWithAllRelatedData()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            // First three variables are discarded with _ to avoid unused variable warnings
            var (_, _, _, pet, visitReason) = SeedFullData(context);

            var entry = new DiaryEntry
            {
                PetId = pet.Id,
                VisitDate = new DateTime(2025, 6, 15),
                VisitReasonId = visitReason.Id,
                Description = "Routine checkup",
                Weight = 25.5f,
                Temperature = 38.5f,
                Pulse = 80,
                Behaviour = "Calm",
                BodyConditionScore = 5
            };
            context.DiaryEntries.Add(entry);
            await context.SaveChangesAsync();
            var service = new DiaryEntriesService(context);

            // Act
            var result = await service.GetDiaryEntryDetailsByIdAsync(entry.Id);

            // Assert
            Assert.Equal(entry.Id, result.Id);
            Assert.Equal(pet.Id, result.PetId);
            Assert.NotNull(result.Pet);
            Assert.Equal("Buddy", result.Pet.Name);
            Assert.NotNull(result.Pet.Client);
            Assert.NotNull(result.Pet.Species);
            Assert.NotNull(result.VisitReason);
            Assert.Equal("Checkup", result.VisitReason.Name);
            Assert.Equal("Routine checkup", result.Description);
            Assert.Equal(25.5f, result.Weight);
            Assert.Equal(38.5f, result.Temperature);
            Assert.Equal(80, result.Pulse);
            Assert.Equal("Calm", result.Behaviour);
            Assert.Equal(5, result.BodyConditionScore);
        }

        [Fact]
        public async Task GetDiaryEntryDetailsByIdAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new DiaryEntriesService(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.GetDiaryEntryDetailsByIdAsync(999));
        }

        [Fact]
        public async Task AddDiaryEntryAsync_AddsEntry()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            // First three variables are discarded with _ to avoid unused variable warnings
            var (_, _, _, pet, visitReason) = SeedFullData(context);
            var service = new DiaryEntriesService(context);

            var model = new DiaryEntryCreateViewModel
            {
                PetId = pet.Id,
                VisitDate = new DateTime(2025, 7, 1),
                VisitReasonId = visitReason.Id,
                Description = "New entry",
                Weight = 30.0f,
                Temperature = 39.0f,
                Pulse = 90,
                Behaviour = "Active",
                BodyConditionScore = 6
            };

            // Act
            await service.AddDiaryEntryAsync(model);

            // Assert
            Assert.Equal(1, context.DiaryEntries.Count());
            var entry = context.DiaryEntries.First();
            Assert.Equal(pet.Id, entry.PetId);
            Assert.Equal(visitReason.Id, entry.VisitReasonId);
            Assert.Equal("New entry", entry.Description);
            Assert.Equal(30.0f, entry.Weight);
            Assert.Equal(39.0f, entry.Temperature);
            Assert.Equal(90, entry.Pulse);
            Assert.Equal("Active", entry.Behaviour);
            Assert.Equal(6, entry.BodyConditionScore);
        }

        [Fact]
        public async Task GetDiaryEntryForEditAsync_ReturnsEditModelWithDropdowns()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            // First three variables are discarded with _ to avoid unused variable warnings
            var (_, _, _, pet, visitReason) = SeedFullData(context);

            var entry = new DiaryEntry
            {
                PetId = pet.Id,
                VisitDate = DateTime.Now,
                VisitReasonId = visitReason.Id,
                Description = "Test",
                Weight = 20.0f,
                Temperature = 38.0f,
                Pulse = 70,
                Behaviour = "Normal",
                BodyConditionScore = 4
            };
            context.DiaryEntries.Add(entry);
            await context.SaveChangesAsync();
            var service = new DiaryEntriesService(context);

            // Act
            var result = await service.GetDiaryEntryForEditAsync(entry.Id);

            // Assert
            Assert.Equal(entry.Id, result.Id);
            Assert.Equal(pet.Id, result.PetId);
            Assert.Equal(visitReason.Id, result.VisitReasonId);
            Assert.Equal("Test", result.Description);
            Assert.Equal(20.0f, result.Weight);
            Assert.NotNull(result.Pet);
            Assert.NotNull(result.VisitReason);
            Assert.NotNull(result.Pets);
            Assert.NotNull(result.VisitReasons);
            Assert.Single(result.Pets!);
            Assert.Single(result.VisitReasons!);
        }

        [Fact]
        public async Task GetDiaryEntryForEditAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new DiaryEntriesService(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.GetDiaryEntryForEditAsync(999));
        }   

     [Fact]
        public async Task EditDiaryEntryAsync_UpdatesEntry()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            // First three variables are discarded with _ to avoid unused variable warnings
            var (_, _, _, pet, visitReason) = SeedFullData(context);

            var entry = new DiaryEntry
            {
                PetId = pet.Id,
                VisitDate = DateTime.Now,
                VisitReasonId = visitReason.Id,
                Description = "Original"
            };
            context.DiaryEntries.Add(entry);
            await context.SaveChangesAsync();
            var service = new DiaryEntriesService(context);

            var editModel = new DiaryEntryEditViewModel
            {
                Id = entry.Id,
                PetId = pet.Id,
                VisitDate = new DateTime(2025, 8, 1),
                VisitReasonId = visitReason.Id,
                Description = "Updated description",
                Weight = 28.0f,
                Temperature = 38.8f,
                Pulse = 85,
                Behaviour = "Energetic",
                BodyConditionScore = 7
            };

            // Act
            await service.EditDiaryEntryAsync(editModel);

            // Assert
            var updated = context.DiaryEntries.First();
            Assert.Equal("Updated description", updated.Description);
            Assert.Equal(28.0f, updated.Weight);
            Assert.Equal(38.8f, updated.Temperature);
            Assert.Equal(85, updated.Pulse);
            Assert.Equal("Energetic", updated.Behaviour);
            Assert.Equal(7, updated.BodyConditionScore);
        }

        [Fact]
        public async Task EditDiaryEntryAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new DiaryEntriesService(context);
            var editModel = new DiaryEntryEditViewModel
            {
                Id = 999,
                PetId = 1,
                VisitDate = DateTime.Now,
                VisitReasonId = 1
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.EditDiaryEntryAsync(editModel));
        }

        [Fact]
        public async Task DeleteDiaryEntryAsync_RemovesEntry()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            // First three variables are discarded with _ to avoid unused variable warnings
            var (_, _, _, pet, visitReason) = SeedFullData(context);

            var entry = new DiaryEntry
            {
                PetId = pet.Id,
                VisitDate = DateTime.Now,
                VisitReasonId = visitReason.Id
            };
            context.DiaryEntries.Add(entry);
            await context.SaveChangesAsync();
            var service = new DiaryEntriesService(context);

            // Act
            await service.DeleteDiaryEntryAsync(entry.Id);

            // Assert
            Assert.Empty(context.DiaryEntries);
        }

        [Fact]
        public async Task DeleteDiaryEntryAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new DiaryEntriesService(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.DeleteDiaryEntryAsync(999));
        }

        [Fact]
        public async Task GetDiaryEntryDeleteDetailsAsync_ReturnsDetails()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            // First three variables are discarded with _ to avoid unused variable warnings
            var (_, _, _, pet, visitReason) = SeedFullData(context);

            var entry = new DiaryEntry
            {
                PetId = pet.Id,
                VisitDate = new DateTime(2025, 6, 15),
                VisitReasonId = visitReason.Id,
                Description = "To be deleted"
            };
            context.DiaryEntries.Add(entry);
            await context.SaveChangesAsync();
            var service = new DiaryEntriesService(context);

            // Act
            var result = await service.GetDiaryEntryDeleteDetailsAsync(entry.Id);

            // Assert
            Assert.Equal(entry.Id, result.Id);
            Assert.Equal(pet.Id, result.PetId);
            Assert.NotNull(result.Pet);
            Assert.Equal("Buddy", result.Pet.Name);
            Assert.NotNull(result.VisitReason);
            Assert.Equal("Checkup", result.VisitReason.Name);
            Assert.Equal("To be deleted", result.Description);
        }

        [Fact]
        public async Task GetDiaryEntryDeleteDetailsAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new DiaryEntriesService(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.GetDiaryEntryDeleteDetailsAsync(999));
        }
    }
}