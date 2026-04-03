using VetDiary.Data.Models;
using VetDiary.ViewModels.Breed;

namespace VetDiary.Services.Tests
{
    public class BreedsServiceTests
    {
        private static Species SeedSpecies(Data.ApplicationDbContext context, string name = "Dog")
        {
            var species = new Species { Name = name };
            context.Species.Add(species);
            context.SaveChanges();
            return species;
        }

        [Fact]
        public async Task GetAllBreedsAsync_ReturnsAllBreedsWithSpecies()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = SeedSpecies(context);
            context.Breeds.AddRange(
                new Breed { Name = "Labrador", SpeciesId = species.Id },
                new Breed { Name = "Poodle", SpeciesId = species.Id }
            );
            await context.SaveChangesAsync();
            var service = new BreedsService(context);

            // Act
            var result = (await service.GetAllBreedsAsync()).ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, b => Assert.NotNull(b.Species));
            Assert.All(result, b => Assert.Equal("Dog", b.Species.Name));
        }

        [Fact]
        public async Task GetAllBreedsAsync_Paginated_ReturnsPaginatedResults()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = SeedSpecies(context);
            for (int i = 1; i <= 5; i++)
            {
                context.Breeds.Add(new Breed { Name = $"Breed{i}", SpeciesId = species.Id });
            }
            await context.SaveChangesAsync();
            var service = new BreedsService(context);

            // Act
            var result = await service.GetAllBreedsAsync(page: 1, pageSize: 2);

            // Assert
            Assert.Equal(2, result.Items.Count);
            Assert.Equal(5, result.TotalCount);
        }

        [Fact]
        public async Task GetAllBreedsAsync_WithSearchTerm_FiltersByName()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = SeedSpecies(context);
            context.Breeds.AddRange(
                new Breed { Name = "Labrador", SpeciesId = species.Id },
                new Breed { Name = "Poodle", SpeciesId = species.Id },
                new Breed { Name = "Labradoodle", SpeciesId = species.Id }
            );
            await context.SaveChangesAsync();
            var service = new BreedsService(context);

            // Act
            var result = await service.GetAllBreedsAsync(page: 1, pageSize: 10, searchTerm: "Labra");

            // Assert
            Assert.Equal(2, result.Items.Count);
        }

        [Fact]
        public async Task GetBreedDetailsByIdAsync_ReturnsBreedWithSpecies()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = SeedSpecies(context);
            var breed = new Breed { Name = "Labrador", SpeciesId = species.Id };
            context.Breeds.Add(breed);
            await context.SaveChangesAsync();
            var service = new BreedsService(context);

            // Act
            var result = await service.GetBreedDetailsByIdAsync(breed.Id);

            // Assert
            Assert.Equal(breed.Id, result.Id);
            Assert.Equal("Labrador", result.Name);
            Assert.NotNull(result.Species);
            Assert.Equal("Dog", result.Species.Name);
        }

        [Fact]
        public async Task GetBreedDetailsByIdAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new BreedsService(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.GetBreedDetailsByIdAsync(999));
        }

        [Fact]
        public async Task AddBreedAsync_AddsBreed()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = SeedSpecies(context);
            var service = new BreedsService(context);
            var model = new BreedCreateViewModel
            {
                Name = "Golden Retriever",
                SpeciesId = species.Id
            };

            // Act
            await service.AddBreedAsync(model);

            // Assert
            Assert.Equal(1, context.Breeds.Count());
            var breed = context.Breeds.First();
            Assert.Equal("Golden Retriever", breed.Name);
            Assert.Equal(species.Id, breed.SpeciesId);
        }
    }
}

