using VetDiary.Data.Models;
using VetDiary.ViewModels.VisitReason;

namespace VetDiary.Services.Tests
{
    public class VisitReasonsServiceTests
    {
        [Fact]
        public async Task GetAllVisitReasonsAsync_ReturnsAll()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            context.VisitReasons.AddRange(
                new VisitReason { Name = "Checkup" },
                new VisitReason { Name = "Vaccination" },
                new VisitReason { Name = "Surgery" }
            );
            await context.SaveChangesAsync();
            var service = new VisitReasonsService(context);

            // Act
            var result = await service.GetAllVisitReasonsAsync();

            // Assert
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetAllVisitReasonsAsync_Paginated_ReturnsPaginatedResults()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            for (int i = 1; i <= 5; i++)
            {
                context.VisitReasons.Add(new VisitReason { Name = $"Reason{i}" });
            }
            await context.SaveChangesAsync();
            var service = new VisitReasonsService(context);

            // Act
            var result = await service.GetAllVisitReasonsAsync(page: 1, pageSize: 2);

            // Assert
            Assert.Equal(2, result.Items.Count);
            Assert.Equal(5, result.TotalCount);
            Assert.Equal(3, result.TotalPages);
        }

        [Fact]
        public async Task GetAllVisitReasonsAsync_WithSearchTerm_FiltersByName()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            context.VisitReasons.AddRange(
                new VisitReason { Name = "Checkup" },
                new VisitReason { Name = "Vaccination" },
                new VisitReason { Name = "Annual Checkup" }
            );
            await context.SaveChangesAsync();
            var service = new VisitReasonsService(context);

            // Act
            var result = await service.GetAllVisitReasonsAsync(page: 1, pageSize: 10, searchTerm: "Checkup");

            // Assert
            Assert.Equal(2, result.Items.Count);
        }

        [Fact]
        public async Task GetVisitReasonDetailsByIdAsync_ReturnsCorrectVisitReason()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var visitReason = new VisitReason { Name = "Checkup" };
            context.VisitReasons.Add(visitReason);
            await context.SaveChangesAsync();
            var service = new VisitReasonsService(context);

            // Act
            var result = await service.GetVisitReasonDetailsByIdAsync(visitReason.Id);

            // Assert
            Assert.Equal(visitReason.Id, result.Id);
            Assert.Equal("Checkup", result.Name);
        }

        [Fact]
        public async Task GetVisitReasonDetailsByIdAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new VisitReasonsService(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.GetVisitReasonDetailsByIdAsync(999));
        }

        [Fact]
        public async Task AddVisitReasonAsync_AddsVisitReason()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new VisitReasonsService(context);
            var model = new VisitReasonCreateViewModel { Name = "Emergency" };

            // Act
            await service.AddVisitReasonAsync(model);

            // Assert
            Assert.Equal(1, context.VisitReasons.Count());
            Assert.Equal("Emergency", context.VisitReasons.First().Name);
        }

        [Fact]
        public async Task GetVisitReasonForEditAsync_ReturnsEditModel()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var visitReason = new VisitReason { Name = "Checkup" };
            context.VisitReasons.Add(visitReason);
            await context.SaveChangesAsync();
            var service = new VisitReasonsService(context);

            // Act
            var result = await service.GetVisitReasonForEditAsync(visitReason.Id);

            // Assert
            Assert.Equal("Checkup", result.Name);
        }

        [Fact]
        public async Task GetVisitReasonForEditAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new VisitReasonsService(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.GetVisitReasonForEditAsync(999));
        }

        [Fact]
        public async Task EditVisitReasonAsync_UpdatesVisitReason()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var visitReason = new VisitReason { Name = "Checkup" };
            context.VisitReasons.Add(visitReason);
            await context.SaveChangesAsync();
            var service = new VisitReasonsService(context);

            var editModel = new VisitReasonEditViewModel
            {
                Id = visitReason.Id,
                Name = "Updated Checkup"
            };

            // Act
            await service.EditVisitReasonAsync(editModel);

            // Assert
            Assert.Equal("Updated Checkup", context.VisitReasons.First().Name);
        }

        [Fact]
        public async Task EditVisitReasonAsync_ThrowsForNonExistent()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new VisitReasonsService(context);
            var editModel = new VisitReasonEditViewModel { Id = 999, Name = "X" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.EditVisitReasonAsync(editModel));
        }
    }
}
