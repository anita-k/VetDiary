using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;
using VetDiary.Data;
using VetDiary.Data.Models;
using VetDiary.Services.Interfaces;
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

        public async Task<ClientDetailsViewModel> GetClientDetailsByIdAsync(int id)
        {
            var client = await _context.Clients
                .Include(c => c.Pets)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                throw new InvalidOperationException("Not found");
            }

            var pets = client.Pets.Select(p => new PetIndexViewModel
            {
                Id = p.Id,
                Name = p.Name
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