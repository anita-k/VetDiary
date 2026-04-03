using VetDiary.Data.Models;
using VetDiary.ViewModels.Client;

namespace VetDiary.Services.Tests
{
    public class ClientsServiceTests
    {
        [Fact]
        public async Task GetAllClientsAsync_ReturnsAllClients()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            context.Clients.AddRange(
                new Client { FirstName = "John", LastName = "Doe", Phone = "1234567890" },
                new Client { FirstName = "Jane", LastName = "Smith", Phone = "0987654321" }
            );
            await context.SaveChangesAsync();
            var service = new ClientsService(context);

            // Act
            var result = await service.GetAllClientsAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetAllClientsAsync_Paginated_ReturnsPaginatedResults()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            for (int i = 1; i <= 5; i++)
            {
                context.Clients.Add(new Client
                {
                    FirstName = $"First{i}",
                    LastName = $"Last{i}",
                    Phone = $"000000000{i}"
                });
            }
            await context.SaveChangesAsync();
            var service = new ClientsService(context);

            // Act
            var result = await service.GetAllClientsAsync(page: 1, pageSize: 2);

            // Assert
            Assert.Equal(2, result.Items.Count);
            Assert.Equal(5, result.TotalCount);
            Assert.Equal(3, result.TotalPages);
        }

        [Fact]
        public async Task GetAllClientsAsync_WithSearchTerm_FiltersByName()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            context.Clients.AddRange(
                new Client { FirstName = "John", LastName = "Doe", Phone = "1234567890" },
                new Client { FirstName = "Jane", LastName = "Smith", Phone = "0987654321" },
                new Client { FirstName = "Bob", LastName = "Johnson", Phone = "1112223333" }
            );
            await context.SaveChangesAsync();
            var service = new ClientsService(context);

            // Act
            var result = await service.GetAllClientsAsync(page: 1, pageSize: 10, searchTerm: "John");

            // Assert
            Assert.Equal(2, result.Items.Count);
        }

        [Fact]
        public async Task GetClientDetailsByIdAsync_ReturnsCorrectClient()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = new Species { Name = "Dog" };
            context.Species.Add(species);
            await context.SaveChangesAsync();

            var client = new Client { FirstName = "John", LastName = "Doe", Phone = "1234567890", Address = "123 Main St", Email = "john@abc.com" };
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            var pet = new Pet { Name = "Buddy", ClientId = client.Id, SpeciesId = species.Id };
            context.Pets.Add(pet);
            await context.SaveChangesAsync();

            var service = new ClientsService(context);

            // Act
            var result = await service.GetClientDetailsByIdAsync(client.Id);

            // Assert
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
            Assert.Equal("1234567890", result.Phone);
            Assert.Equal("123 Main St", result.Address);
            Assert.Equal("john@abc.com", result.Email);
            Assert.Single(result.Pets);
            Assert.Equal("Buddy", result.Pets.First().Name);
        }

        [Fact]
        public async Task GetClientDetailsByIdAsync_ThrowsForNonExistentId()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new ClientsService(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.GetClientDetailsByIdAsync(999));
        }

        [Fact]
        public async Task AddClientAsync_AddsClientToDatabase()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new ClientsService(context);
            var model = new ClientCreateViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                Phone = "1234567890",
                Email = "john@abc.com",
                Address = "123 Main St"
            };

            // Act
            await service.AddClientAsync(model);

            // Assert
            Assert.Equal(1, context.Clients.Count());
            var client = context.Clients.First();
            Assert.Equal("John", client.FirstName);
            Assert.Equal("Doe", client.LastName);
            Assert.Equal("1234567890", client.Phone);
            Assert.Equal("john@abc.com", client.Email);
            Assert.Equal("123 Main St", client.Address);
        }

        [Fact]
        public async Task GetClientForEditAsync_ReturnsEditViewModel()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var client = new Client { FirstName = "John", LastName = "Doe", Phone = "1234567890", Email = "john@test.com", Address = "Add" };
            context.Clients.Add(client);
            await context.SaveChangesAsync();
            var service = new ClientsService(context);

            // Act
            var result = await service.GetClientForEditAsync(client.Id);

            // Assert
            Assert.Equal(client.Id, result.Id);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
            Assert.Equal("1234567890", result.Phone);
            Assert.Equal("john@test.com", result.Email);
            Assert.Equal("Add", result.Address);
        }

        [Fact]
        public async Task GetClientForEditAsync_ThrowsForNonExistentClient()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new ClientsService(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.GetClientForEditAsync(999));
        }

        [Fact]
        public async Task EditClientAsync_UpdatesClientData()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var client = new Client { FirstName = "John", LastName = "Doe", Phone = "1234567890" };
            context.Clients.Add(client);
            await context.SaveChangesAsync();
            var service = new ClientsService(context);

            var editModel = new ClientEditViewModel
            {
                Id = client.Id,
                FirstName = "Updated",
                LastName = "Name",
                Phone = "9999999999",
                Email = "updated@test.com",
                Address = "New Address"
            };

            // Act
            await service.EditClientAsync(editModel);

            // Assert
            var updated = context.Clients.First();
            Assert.Equal("Updated", updated.FirstName);
            Assert.Equal("Name", updated.LastName);
            Assert.Equal("9999999999", updated.Phone);
            Assert.Equal("updated@test.com", updated.Email);
            Assert.Equal("New Address", updated.Address);
        }

        [Fact]
        public async Task EditClientAsync_ThrowsForNonExistentClient()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new ClientsService(context);
            var editModel = new ClientEditViewModel
            {
                Id = 999,
                FirstName = "X",
                LastName = "Y",
                Phone = "0000000000"
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.EditClientAsync(editModel));
        }

        [Fact]
        public async Task DeleteClientAsync_RemovesClient()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var client = new Client { FirstName = "John", LastName = "Doe", Phone = "1234567890" };
            context.Clients.Add(client);
            await context.SaveChangesAsync();
            var service = new ClientsService(context);

            // Act
            await service.DeleteClientAsync(client.Id);

            // Assert
            Assert.Empty(context.Clients);
        }

        [Fact]
        public async Task DeleteClientAsync_ThrowsForNonExistentClient()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var service = new ClientsService(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => service.DeleteClientAsync(999));
        }

        [Fact]
        public async Task GetClientDeleteDetailsAsync_ReturnsCorrectData()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            var species = new Species { Name = "Cat" };
            context.Species.Add(species);
            await context.SaveChangesAsync();

            var client = new Client { FirstName = "John", LastName = "Doe", Phone = "1234567890", Address = "Add", Email = "e@e.com" };
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            context.Pets.Add(new Pet { Name = "Whiskers", ClientId = client.Id, SpeciesId = species.Id });
            await context.SaveChangesAsync();

            var service = new ClientsService(context);

            // Act
            var result = await service.GetClientDeleteDetailsAsync(client.Id);

            // Assert
            Assert.Equal(client.Id, result.Id);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
            Assert.Single(result.Pets);
            Assert.Equal("Whiskers", result.Pets.First().Name);
        }
    }
}
