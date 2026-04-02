using VetDiary.Data.Models;
using VetDiary.ViewModels.Species;

namespace VetDiary.Services.Tests
{
    public class SpeciesServiceTests
    {
        [Fact]
        public async Task GetAllSpeciesAsync_ReturnsAllSpecies()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            context.Species.AddRange(
                new Species { Name = "Dog" },
                new Species { Name = "Cat" },
                new Species { Name = "Bird" }
            );
            await context.SaveChangesAsync();
            var service = new SpeciesService(context);

            // Act
            var result = await service.GetAllSpeciesAsync();

            // Assert
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetAllSpeciesAsync_Paginated_ReturnsPaginatedResults()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            for (int i = 1; i <= 5; i++)
            {
                context.Species.Add(new Species { Name = $"Species{i}" });
            }
            await context.SaveChangesAsync();
            var service = new SpeciesService(context);

            // Act
            var result = await service.GetAllSpeciesAsync(page: 1, pageSize: 2);

            // Assert
            Assert.Equal(2, result.Items.Count);
            Assert.Equal(5, result.TotalCount);
            Assert.Equal(3, result.TotalPages);
        }

        [Fact]
        public async Task GetAllSpeciesAsync_WithSearchTerm_FiltersByName()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            context.Species.AddRange(
                new Species { Name = "Dog" },
                new Species { Name = "Cat" },
                new Species { Name = "Dogfish" },
                new Species { Name = "Catfish" }
            );
            await context.SaveChangesAsync();
            var service = new SpeciesService(context);

            // Act
            var result = await service.GetAllSpeciesAsync(page: 1, pageSize: 10, searchTerm: "Dog");

            // Assert
            Assert.Equal(2, result.Items.Count);
        }

        [Fact]
        public async Task GetSpeciesDetailsByIdAsync_ReturnsCorrectSpecies()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = new Species { Name = "Dog", Icon = "dog-icon" };
            context.Species.Add(species);
            await context.SaveChangesAsync();
            var service = new SpeciesService(context);

            // Act
            var result = await service.GetSpeciesDetailsByIdAsync(species.Id);

            // Assert
            Assert.Equal(species.Id, result.Id);
            Assert.Equal("Dog", result.Name);
            Assert.Equal("dog-icon", result.Icon);
        }

        [Fact]
        public async Task GetSpeciesDetailsByIdAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new SpeciesService(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.GetSpeciesDetailsByIdAsync(999));
        }

    }
}
