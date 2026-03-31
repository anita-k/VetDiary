using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using VetDiary.Data;
using VetDiary.Data.Models;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels;
using VetDiary.ViewModels.Breed;
using VetDiary.ViewModels.Client;
using VetDiary.ViewModels.DiaryEntry;
using VetDiary.ViewModels.Pet;
using VetDiary.ViewModels.Species;
using VetDiary.ViewModels.VisitReason;

namespace VetDiary.Services
{
    public class PetsService : IPetsService
    {

        private readonly ApplicationDbContext _context;

        public PetsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PetIndexViewModel>> GetAllPetsAsync()
        {
            return await _context.Pets
            .Include(p => p.Client)
            .Include(p => p.Species)
            .Include(p => p.Breed)
            .Select(p => new PetIndexViewModel
            {
                Id = p.Id,
                Name = p.Name,
                ClientId = p.ClientId,
                Client = new ClientIndexViewModel
                {
                    FirstName = p.Client.FirstName,
                    LastName = p.Client.LastName,
                    Phone = p.Client.Phone,
                    Email = p.Client.Email,
                },
                SpeciesId = p.SpeciesId,
                Species = new SpeciesIndexViewModel
                {
                    Name = p.Species.Name,
                    Icon = p.Species.Icon,
                },
                BreedId = p.BreedId,
                Breed = p.Breed != null
                        ? new BreedIndexViewModel { Name = p.Breed.Name }
                        : null,
            })
            .ToListAsync();
        }

        public async Task<PaginatedList<PetIndexViewModel>> GetAllPetsAsync(int page, int pageSize, string? searchTerm = null, int? speciesId = null)
        {
            var query = _context.Pets
                .Include(p => p.Client)
                .Include(p => p.Species)
                .Include(p => p.Breed)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(
                    p => p.Name.Contains(searchTerm) ||
                    p.MicrochipNumber.Equals(searchTerm) ||
                    p.PassportNumber.Contains(searchTerm) ||
                    p.Client.FirstName.Contains(searchTerm) ||
                    p.Client.LastName.Contains(searchTerm));
            }

            if (speciesId.HasValue)
            {
                query = query.Where(p => p.SpeciesId == speciesId.Value);
            }

            var count = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PetIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ClientId = p.ClientId,
                    Client = new ClientIndexViewModel
                    {
                        FirstName = p.Client.FirstName,
                        LastName = p.Client.LastName,
                        Phone = p.Client.Phone,
                        Email = p.Client.Email,
                    },
                    SpeciesId = p.SpeciesId,
                    Species = new SpeciesIndexViewModel
                    {
                        Name = p.Species.Name,
                        Icon = p.Species.Icon,
                    },
                    BreedId = p.BreedId,
                    Breed = p.Breed != null
                            ? new BreedIndexViewModel { Name = p.Breed.Name }
                            : null,
                })
                .ToListAsync();

            return new PaginatedList<PetIndexViewModel>(items, count, page, pageSize);
        }


        public async Task<PetDetailsViewModel> GetPetDetailsByIdAsync(int id)
        {
            var pet = await _context.Pets
                .Include(p => p.Client)
                .Include(p => p.Species)
                .Include(p => p.Breed)
                .Include(p => p.DiaryEntries)
                    .ThenInclude(d => d.VisitReason)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
            {
                throw new InvalidOperationException("Not found");
            }

            var diaryEntries = pet.DiaryEntries
                .Select(d => new DiaryEntryIndexViewModel
            {
                Id = d.Id,
                PetId = d.PetId,
                Pet = new PetIndexViewModel
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    SpeciesId = pet.SpeciesId,
                    Species = new SpeciesIndexViewModel
                    {
                        Name = pet.Species.Name,
                        Icon = pet.Species.Icon,
                    },
                    BreedId = pet.BreedId,
                    Breed = pet.Breed != null
                        ? new BreedIndexViewModel
                        {
                            Name = pet.Breed.Name,
                            SpeciesId = pet.Breed.SpeciesId
                        }
                        : null,
                    ClientId = pet.ClientId,

                    Client = new ClientIndexViewModel
                    {
                        
                        Id = pet.Client.Id,
                        FirstName = pet.Client.FirstName,
                        LastName = pet.Client.LastName,
                        Phone = pet.Client.Phone,
                        Email = pet.Client.Email,
                    },
                },
                VisitDate = d.VisitDate,
                VisitReasonId = d.VisitReasonId,
                VisitReason = new VisitReasonIndexViewModel {
                    Id = d.VisitReasonId,
                    Name = d.VisitReason.Name,
                },
                });

            return new PetDetailsViewModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Gender = pet.Gender,
                BirthDate = pet.BirthDate, 
                IsNeutered = pet.IsNeutered,
                MicrochipNumber = pet.MicrochipNumber,
                PassportNumber = pet.PassportNumber,
                ClientId = pet.ClientId,
                Client = new ClientIndexViewModel
                {
                    Id = pet.ClientId,
                    FirstName = pet.Client.FirstName,
                    LastName = pet.Client.LastName,
                    Phone = pet.Client.Phone,
                    Email = pet.Client.Email,
                },
                SpeciesId = pet.SpeciesId,
                Species = new SpeciesIndexViewModel
                {
                    Name = pet.Species.Name,
                    Icon = pet.Species.Icon,
                },
                BreedId = pet.BreedId,
                Breed = pet.Breed != null
                        ? new BreedIndexViewModel { 
                            Name = pet.Breed.Name, 
                            SpeciesId = pet.Breed.SpeciesId 
                        }
                        : null,
                DiaryEntries = diaryEntries != null
                    ? new Collection<DiaryEntryIndexViewModel>(diaryEntries.ToList())
                    : new Collection<DiaryEntryIndexViewModel>(),
            };
        }

        public async Task<PetCreateViewModel> GetPetCreateViewModelAsync()
        {
            IEnumerable<ClientIndexViewModel> clients = await _context.Clients
             .Select(c => new ClientIndexViewModel
             {
                 Id = c.Id,
                 FirstName = c.FirstName,
                 LastName = c.LastName,
                 Phone = c.Phone,
                 Email = c.Email,
             })
             .ToListAsync();

            IEnumerable<SpeciesIndexViewModel> species = await _context.Species
             .Select(s => new SpeciesIndexViewModel
             {
                 Id = s.Id,
                 Name = s.Name
             })
             .ToListAsync();

            IEnumerable<BreedIndexViewModel> breeds = await _context.Breeds
             .Select(s => new BreedIndexViewModel
             {
                 Id = s.Id,
                 Name = s.Name
             })
             .ToListAsync();

            return new PetCreateViewModel
            {
                Clients = clients,
                Species = species,
                Breeds = breeds,
            };
        }

        public async Task AddPetAsync(PetCreateViewModel model)
        {
            var pet = new Pet
            {
                Name = model.Name,
                Gender = model.Gender,
                BirthDate = model.BirthDate,
                IsNeutered = model.IsNeutered,
                MicrochipNumber = model.MicrochipNumber,
                PassportNumber = model.PassportNumber,
                ClientId = model.ClientId,
                SpeciesId = model.SpeciesId,
                BreedId = model.BreedId,
            };
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<PetEditViewModel> GetPetForEditAsync(int id)
        {
            var pet = await _context.Pets
                .Include(p => p.Client)
                .Include(p => p.Species)
                .Include(p => p.Breed)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (pet == null)
            {
                throw new ArgumentException("Pet not found.");
            }
            IEnumerable<ClientIndexViewModel> clients = await _context.Clients
                        .Select(c => new ClientIndexViewModel
                        {
                            Id = c.Id,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Phone = c.Phone,
                            Email = c.Email,
                        })
                        .ToListAsync();

            IEnumerable<SpeciesIndexViewModel> species = await _context.Species
             .Select(s => new SpeciesIndexViewModel
             {
                 Id = s.Id,
                 Name = s.Name
             })
             .ToListAsync();

            IEnumerable<BreedIndexViewModel> breeds = await _context.Breeds
             .Select(b => new BreedIndexViewModel
             {
                 Id = b.Id,
                 Name = b.Name
             })
             .ToListAsync();

            return new PetEditViewModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Gender = pet.Gender,
                BirthDate = pet.BirthDate,
                IsNeutered = pet.IsNeutered,
                MicrochipNumber = pet.MicrochipNumber,
                PassportNumber = pet.PassportNumber,
                ClientId = pet.ClientId,
                SpeciesId = pet.SpeciesId,
                BreedId = pet.BreedId,
                Clients = clients,
                Species = species,
                Breeds = breeds,
            };
        }

        public async Task EditPetAsync(PetEditViewModel model)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(p => p.Id == model.Id);
            if (pet == null)
            {
                throw new ArgumentException("Pet not found.");
            }
            pet.Name = model.Name;
            pet.Gender = model.Gender;
            pet.IsNeutered = model.IsNeutered;
            pet.BirthDate = model.BirthDate;
            pet.MicrochipNumber = model.MicrochipNumber;
            pet.PassportNumber = model.PassportNumber;
            pet.ClientId = model.ClientId;
            pet.SpeciesId = model.SpeciesId;
            pet.BreedId = model.BreedId;
            await _context.SaveChangesAsync();
        }


        public async Task<PetDeleteViewModel> GetPetDeleteDetailsAsync(int id)
        {
            Pet? pet = await _context.Pets
                 .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
            {
                throw new ArgumentException("Pet not found.");
            }

            var species = await _context.Species.FirstOrDefaultAsync(s => s.Id == pet.SpeciesId);

            if (species == null)
            {
                throw new ArgumentException("Species not found.");
            }

            return new PetDeleteViewModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Species = new SpeciesIndexViewModel
                {
                    Name = species.Name
                }
            };
        }

        public async Task DeletePetAsync(int id)
        {
            var pet = await _context.Pets
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
            {
                throw new ArgumentException("Pet not found.");
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }

    }
}