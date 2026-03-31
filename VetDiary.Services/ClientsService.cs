using Microsoft.EntityFrameworkCore;
using VetDiary.Data;
using VetDiary.Data.Models;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels;
using VetDiary.ViewModels.Breed;
using VetDiary.ViewModels.Client;
using VetDiary.ViewModels.Pet;
using VetDiary.ViewModels.Species;

namespace VetDiary.Services
{
    public class ClientsService : IClientsService
    {

        private readonly ApplicationDbContext _context;

        public ClientsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientIndexViewModel>> GetAllClientsAsync()
        {
            return await _context.Clients
            .Select(c => new ClientIndexViewModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Phone = c.Phone,
                    Email = c.Email,
                })
            .ToListAsync();
        }

        public async Task<PaginatedList<ClientIndexViewModel>> GetAllClientsAsync(int page, int pageSize, string? searchTerm = null)
        {
            var query = _context.Clients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c =>
                    c.FirstName.Contains(searchTerm) ||
                    c.LastName.Contains(searchTerm) ||
                    c.Phone.Contains(searchTerm) ||
                    c.Address.Contains(searchTerm) ||
                    (c.Email != null && c.Email.Contains(searchTerm)));
            }

            var count = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new ClientIndexViewModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Phone = c.Phone,
                    Email = c.Email,
                })
                .ToListAsync();

            return new PaginatedList<ClientIndexViewModel>(items, count, page, pageSize);
        }

        public async Task<ClientDetailsViewModel> GetClientDetailsByIdAsync(int id)
        {
            var client = await _context.Clients
                .Include(c => c.Pets)
                    .ThenInclude(p => p.Species)
                .Include(c => c.Pets)
                    .ThenInclude(p => p.Breed)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                throw new InvalidOperationException("Not found");
            }

            var pets = client.Pets.Select(p => new PetIndexViewModel
            {
                Id = p.Id,
                Name = p.Name,
                SpeciesId = p.SpeciesId,
                Species = new SpeciesIndexViewModel
                {
                    Id = p.Species.Id,
                    Name = p.Species.Name,
                    Icon = p.Species.Icon,
                },
                BreedId = p.BreedId,
                Breed = p.Breed != null
                        ? new BreedIndexViewModel {
                            Id = p.Breed.Id,
                            Name = p.Breed.Name
                        }
                        : null,

            }).ToList();

            return new ClientDetailsViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Phone = client.Phone,
                Address = client.Address,
                Email = client.Email,
                Pets = pets,
            };
        }

        public async Task<ClientCreateViewModel> GetClientCreateViewModelAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddClientAsync(ClientCreateViewModel model)
        {
            var client = new Client
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address,
            };
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientEditViewModel> GetClientForEditAsync(int id)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(b => b.Id == id);

            if (client == null)
            {
                throw new ArgumentException("Client not found.");
            }

            return new ClientEditViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Phone = client.Phone,
                Email = client.Email,
                Address = client.Address,
            };
        }

        public async Task EditClientAsync(ClientEditViewModel model)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(b => b.Id == model.Id);
            if (client == null)
            {
                throw new ArgumentException("Client not found.");
            }
            client.FirstName = model.FirstName;
            client.LastName = model.LastName;
            client.Phone = model.Phone;
            client.Email = model.Email;
            client.Address = model.Address;
            await _context.SaveChangesAsync();
        }

        public async Task<ClientDeleteViewModel> GetClientDeleteDetailsAsync(int id)
        {
            var client = await _context.Clients
                .Include(c => c.Pets)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                throw new ArgumentException("Client not found.");
            }

            var pets = client.Pets.Select(p => new PetIndexViewModel
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ClientDeleteViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Phone = client.Phone,
                Address = client.Address,
                Email = client.Email,
                Pets = pets
            };
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(b => b.Id == id);

            if (client == null)
            {
                throw new ArgumentException("Client not found.");
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }


    }
}