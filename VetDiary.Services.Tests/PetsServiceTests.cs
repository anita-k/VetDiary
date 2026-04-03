using VetDiary.Data.Models;
using VetDiary.Shared;
using VetDiary.ViewModels.Pet;

namespace VetDiary.Services.Tests
{
    public class PetsServiceTests
    {
        private static (Client client, Species species, Breed breed) SeedBasicData(Data.ApplicationDbContext context)
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

            return (client, species, breed);
        }

        [Fact]
        public async Task GetAllPetsAsync_ReturnsAllPetsWithRelatedData()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, breed) = SeedBasicData(context);

            context.Pets.AddRange(
                new Pet { Name = "Buddy", ClientId = client.Id, SpeciesId = species.Id, BreedId = breed.Id },
                new Pet { Name = "Max", ClientId = client.Id, SpeciesId = species.Id }
            );
            await context.SaveChangesAsync();
            var service = new PetsService(context);

            // Act
            var result = (await service.GetAllPetsAsync()).ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, p => Assert.NotNull(p.Client));
            Assert.All(result, p => Assert.NotNull(p.Species));
            var buddyResult = result.First(p => p.Name == "Buddy");
            Assert.NotNull(buddyResult.Breed);
            Assert.Equal("Labrador", buddyResult.Breed!.Name);
        }

        [Fact]
        public async Task GetAllPetsAsync_Paginated_ReturnsPaginatedResults()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, _) = SeedBasicData(context);

            for (int i = 1; i <= 5; i++)
            {
                context.Pets.Add(new Pet { Name = $"Pet{i}", ClientId = client.Id, SpeciesId = species.Id });
            }
            await context.SaveChangesAsync();
            var service = new PetsService(context);

            // Act
            var result = await service.GetAllPetsAsync(page: 1, pageSize: 2);

            // Assert
            Assert.Equal(2, result.Items.Count);
            Assert.Equal(5, result.TotalCount);
        }

        [Fact]
        public async Task GetAllPetsAsync_WithSearchTerm_FiltersByPetName()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, _) = SeedBasicData(context);

            context.Pets.AddRange(
                new Pet { Name = "Buddy", ClientId = client.Id, SpeciesId = species.Id },
                new Pet { Name = "Max", ClientId = client.Id, SpeciesId = species.Id },
                new Pet { Name = "BuddyJr", ClientId = client.Id, SpeciesId = species.Id }
            );
            await context.SaveChangesAsync();
            var service = new PetsService(context);

            // Act
            var result = await service.GetAllPetsAsync(page: 1, pageSize: 10, searchTerm: "Buddy");

            // Assert
            Assert.Equal(2, result.Items.Count);
        }

        [Fact]
        public async Task GetAllPetsAsync_WithSpeciesIdFilter_FiltersBySpecies()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, _) = SeedBasicData(context);

            var catSpecies = new Species { Name = "Cat" };
            context.Species.Add(catSpecies);
            await context.SaveChangesAsync();

            context.Pets.AddRange(
                new Pet { Name = "Buddy", ClientId = client.Id, SpeciesId = species.Id },
                new Pet { Name = "Whiskers", ClientId = client.Id, SpeciesId = catSpecies.Id }
            );
            await context.SaveChangesAsync();
            var service = new PetsService(context);

            // Act
            var result = await service.GetAllPetsAsync(page: 1, pageSize: 10, speciesId: catSpecies.Id);

            // Assert
            Assert.Single(result.Items);
            Assert.Equal("Whiskers", result.Items.First().Name);
        }

        [Fact]
        public async Task GetPetDetailsByIdAsync_ReturnsPetWithDiaryEntries()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, breed) = SeedBasicData(context);

            var pet = new Pet
            {
                Name = "Buddy",
                Gender = PetGender.Male,
                IsNeutered = true,
                BirthDate = new DateOnly(2020, 1, 15),
                MicrochipNumber = 123456,
                PassportNumber = "AB123",
                ClientId = client.Id,
                SpeciesId = species.Id,
                BreedId = breed.Id
            };
            context.Pets.Add(pet);
            await context.SaveChangesAsync();

            var visitReason = new VisitReason { Name = "Checkup" };
            context.VisitReasons.Add(visitReason);
            await context.SaveChangesAsync();

            context.DiaryEntries.Add(new DiaryEntry
            {
                PetId = pet.Id,
                VisitDate = DateTime.Now,
                VisitReasonId = visitReason.Id,
                Description = "Routine checkup"
            });
            await context.SaveChangesAsync();

            var service = new PetsService(context);

            // Act
            var result = await service.GetPetDetailsByIdAsync(pet.Id);

            // Assert
            Assert.Equal("Buddy", result.Name);
            Assert.Equal(PetGender.Male, result.Gender);
            Assert.True(result.IsNeutered);
            Assert.Equal(new DateOnly(2020, 1, 15), result.BirthDate);
            Assert.Equal(123456, result.MicrochipNumber);
            Assert.Equal("AB123", result.PassportNumber);
            Assert.NotNull(result.Client);
            Assert.NotNull(result.Species);
            Assert.NotNull(result.Breed);
            Assert.Single(result.DiaryEntries);
        }

        [Fact]
        public async Task GetPetDetailsByIdAsync_ThrowsForNonExistentId()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new PetsService(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.GetPetDetailsByIdAsync(999));
        }

        [Fact]
        public async Task AddPetAsync_AddsPetToDatabase()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, breed) = SeedBasicData(context);
            var service = new PetsService(context);

            var model = new PetCreateViewModel
            {
                Name = "Buddy",
                Gender = PetGender.Male,
                IsNeutered = false,
                BirthDate = new DateOnly(2021, 6, 1),
                MicrochipNumber = 789,
                PassportNumber = "XY789",
                ClientId = client.Id,
                SpeciesId = species.Id,
                BreedId = breed.Id
            };

            // Act
            await service.AddPetAsync(model);

            // Assert
            Assert.Equal(1, context.Pets.Count());
            var pet = context.Pets.First();
            Assert.Equal("Buddy", pet.Name);
            Assert.Equal(PetGender.Male, pet.Gender);
            Assert.Equal(client.Id, pet.ClientId);
            Assert.Equal(species.Id, pet.SpeciesId);
            Assert.Equal(breed.Id, pet.BreedId);
        }

        [Fact]
        public async Task GetPetForEditAsync_ReturnsPetWithDropdownData()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, breed) = SeedBasicData(context);

            var pet = new Pet { Name = "Buddy", ClientId = client.Id, SpeciesId = species.Id, BreedId = breed.Id };
            context.Pets.Add(pet);
            await context.SaveChangesAsync();
            var service = new PetsService(context);

            // Act
            var result = await service.GetPetForEditAsync(pet.Id);

            // Assert
            Assert.Equal(pet.Id, result.Id);
            Assert.Equal("Buddy", result.Name);
            Assert.Equal(client.Id, result.ClientId);
            Assert.Equal(species.Id, result.SpeciesId);
            Assert.Equal(breed.Id, result.BreedId);
            Assert.NotNull(result.Clients);
            Assert.NotNull(result.Species);
            Assert.NotNull(result.Breeds);
            Assert.Single(result.Clients!);
            Assert.Single(result.Species!);
            Assert.Single(result.Breeds!);
        }

        [Fact]
        public async Task EditPetAsync_UpdatesPetData()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, breed) = SeedBasicData(context);

            var pet = new Pet { Name = "Buddy", ClientId = client.Id, SpeciesId = species.Id };
            context.Pets.Add(pet);
            await context.SaveChangesAsync();
            var service = new PetsService(context);

            var editModel = new PetEditViewModel
            {
                Id = pet.Id,
                Name = "UpdatedBuddy",
                Gender = PetGender.Female,
                IsNeutered = true,
                BirthDate = new DateOnly(2019, 3, 10),
                MicrochipNumber = 111,
                PassportNumber = "NEW123",
                ClientId = client.Id,
                SpeciesId = species.Id,
                BreedId = breed.Id
            };

            // Act
            await service.EditPetAsync(editModel);

            // Assert
            var updated = context.Pets.First();
            Assert.Equal("UpdatedBuddy", updated.Name);
            Assert.Equal(PetGender.Female, updated.Gender);
            Assert.True(updated.IsNeutered);
            Assert.Equal(breed.Id, updated.BreedId);
        }

        [Fact]
        public async Task DeletePetAsync_RemovesPet()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, _) = SeedBasicData(context);

            var pet = new Pet { Name = "Buddy", ClientId = client.Id, SpeciesId = species.Id };
            context.Pets.Add(pet);
            await context.SaveChangesAsync();
            var service = new PetsService(context);

            // Act
            await service.DeletePetAsync(pet.Id);

            // Assert
            Assert.Empty(context.Pets);
        }

        [Fact]
        public async Task GetPetCreateViewModelAsync_ReturnsViewModelWithDropdownLists()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var (client, species, breed) = SeedBasicData(context);
            var service = new PetsService(context);

            // Act
            var result = await service.GetPetCreateViewModelAsync();

            // Assert
            Assert.NotNull(result.Clients);
            Assert.NotNull(result.Species);
            Assert.NotNull(result.Breeds);
            Assert.Single(result.Clients!);
            Assert.Single(result.Species!);
            Assert.Single(result.Breeds!);
        }
    }
}
