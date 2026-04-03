using VetDiary.Data.Models;
using VetDiary.Services;
using VetDiary.Services.Tests;
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

        [Fact]
        public async Task AddSpeciesAsync_AddsSpecies()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new SpeciesService(context);
            var model = new SpeciesCreateViewModel { Name = "Hamster" };

            // Act
            await service.AddSpeciesAsync(model);

            // Assert
            Assert.Equal(1, context.Species.Count());
            Assert.Equal("Hamster", context.Species.First().Name);
        }

        [Fact]
        public async Task GetSpeciesForEditAsync_ReturnsEditModel()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = new Species { Name = "Dog" };
            context.Species.Add(species);
            await context.SaveChangesAsync();
            var service = new SpeciesService(context);

            // Act
            var result = await service.GetSpeciesForEditAsync(species.Id);

            // Assert
            Assert.Equal("Dog", result.Name);
        }

        [Fact]
        public async Task GetSpeciesForEditAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new SpeciesService(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.GetSpeciesForEditAsync(999));
        }

        [Fact]
        public async Task EditSpeciesAsync_UpdatesSpecies()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = new Species { Name = "Dog" };
            context.Species.Add(species);
            await context.SaveChangesAsync();
            var service = new SpeciesService(context);

            var editModel = new SpeciesEditViewModel
            {
                Id = species.Id,
                Name = "Updated Dog"
            };

            // Act
            await service.EditSpeciesAsync(editModel);

            // Assert
            Assert.Equal("Updated Dog", context.Species.First().Name);
        }

        [Fact]
        public async Task EditSpeciesAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new SpeciesService(context);
            var editModel = new SpeciesEditViewModel { Id = 999, Name = "X" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.EditSpeciesAsync(editModel));
        }

        [Fact]
        public async Task DeleteSpeciesAsync_RemovesSpecies()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = new Species { Name = "Dog" };
            context.Species.Add(species);
            await context.SaveChangesAsync();
            var service = new SpeciesService(context);

            // Act
            await service.DeleteSpeciesAsync(species.Id);

            // Assert
            Assert.Empty(context.Species);
        }

        [Fact]
        public async Task DeleteSpeciesAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new SpeciesService(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.DeleteSpeciesAsync(999));
        }

        [Fact]
        public async Task GetSpeciesDeleteDetailsAsync_ReturnsDetails()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = new Species { Name = "Dog" };
            context.Species.Add(species);
            await context.SaveChangesAsync();
            var service = new SpeciesService(context);

            // Act
            var result = await service.GetSpeciesDeleteDetailsAsync(species.Id);

            // Assert
            Assert.Equal(species.Id, result.Id);
            Assert.Equal("Dog", result.Name);
        }

        [Fact]
        public async Task GetSpeciesDeleteDetailsAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new SpeciesService(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.GetSpeciesDeleteDetailsAsync(999));
        }
    }
}