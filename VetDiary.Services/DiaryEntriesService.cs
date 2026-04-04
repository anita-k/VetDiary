using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Data;
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
    public class DiaryEntriesService : IDiaryEntriesService
    {

        private readonly ApplicationDbContext _context;

        public DiaryEntriesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiaryEntryIndexViewModel>> GetAllDiaryEntriesAsync()
        {
            return await _context.DiaryEntries
            .Include(d => d.Pet)
                .ThenInclude(p => p.Client)
            .Include(d => d.Pet)
                .ThenInclude(p => p.Species)
            .Include(d => d.Pet)
                .ThenInclude(p => p.Breed)
            .Include(d => d.VisitReason)
            .Select(d => new DiaryEntryIndexViewModel
            {
                Id = d.Id,
                PetId = d.PetId,
                Pet = new PetIndexViewModel { 
                    Id = d.PetId,
                    Name = d.Pet.Name,
                    ClientId = d.Pet.ClientId,
                    Client = new ClientIndexViewModel {
                        Id = d.Pet.Client.Id,
                        FirstName = d.Pet.Client.FirstName,
                        LastName = d.Pet.Client.LastName,
                        Phone = d.Pet.Client.Phone,
                        Email = d.Pet.Client.Email,
                    },
                    SpeciesId = d.Pet.SpeciesId,
                    Species = new SpeciesIndexViewModel
                    {
                        Name = d.Pet.Species.Name,
                        Icon = d.Pet.Species.Icon,
                    },
                    BreedId = d.Pet.BreedId,
                    Breed = d.Pet.Breed != null
                        ? new BreedIndexViewModel
                        {
                            Name = d.Pet.Breed.Name,
                            SpeciesId = d.Pet.Breed.SpeciesId
                        }
                        : null,
                },
                VisitDate = d.VisitDate,
                VisitReasonId = d.VisitReasonId,
                VisitReason = new VisitReasonIndexViewModel {
                    Id = d.VisitReasonId,
                    Name = d.VisitReason.Name,
                },
            })
            .ToListAsync();
        }

        public async Task<PaginatedList<DiaryEntryIndexViewModel>> GetAllDiaryEntriesAsync(int page, int pageSize, string? searchTerm = null, int? visitReasonId = null, string? sortBy = null, bool sortDesc = false)
        {
            var query = _context.DiaryEntries
                .Include(d => d.Pet)
                    .ThenInclude(p => p.Client)
                .Include(d => d.Pet)
                    .ThenInclude(p => p.Species)
                .Include(d => d.Pet)
                    .ThenInclude(p => p.Breed)
                .Include(d => d.VisitReason)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(d =>
                    d.Pet.Name.Contains(searchTerm) ||
                    d.Pet.Client.FirstName.Contains(searchTerm) ||
                    d.Pet.Client.LastName.Contains(searchTerm) ||
                    d.VisitReason.Name.Contains(searchTerm) ||
                    (d.Description != null && d.Description.Contains(searchTerm)));
            }

            if (visitReasonId.HasValue)
            {
                query = query.Where(d => d.VisitReasonId == visitReasonId.Value);
            }

            query = sortBy switch
            {
                "date" => sortDesc ? query.OrderByDescending(d => d.VisitDate) : query.OrderBy(d => d.VisitDate),
                "pet" => sortDesc ? query.OrderByDescending(d => d.Pet.Name) : query.OrderBy(d => d.Pet.Name),
                "client" => sortDesc ? query.OrderByDescending(d => d.Pet.Client.FirstName).ThenByDescending(d => d.Pet.Client.LastName) : query.OrderBy(d => d.Pet.Client.FirstName).ThenBy(d => d.Pet.Client.LastName),
                "reason" => sortDesc ? query.OrderByDescending(d => d.VisitReason.Name) : query.OrderBy(d => d.VisitReason.Name),
                _ => query.OrderByDescending(d => d.VisitDate)
            };

            var count = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(d => new DiaryEntryIndexViewModel
                {
                    Id = d.Id,
                    PetId = d.PetId,
                    Pet = new PetIndexViewModel
                    {
                        Id = d.PetId,
                        Name = d.Pet.Name,
                        ClientId = d.Pet.ClientId,
                        Client = new ClientIndexViewModel
                        {
                            Id = d.Pet.Client.Id,
                            FirstName = d.Pet.Client.FirstName,
                            LastName = d.Pet.Client.LastName,
                            Phone = d.Pet.Client.Phone,
                            Email = d.Pet.Client.Email,
                        },
                        SpeciesId = d.Pet.SpeciesId,
                        Species = new SpeciesIndexViewModel
                        {
                            Name = d.Pet.Species.Name,
                            Icon = d.Pet.Species.Icon,
                        },
                        BreedId = d.Pet.BreedId,
                        Breed = d.Pet.Breed != null
                            ? new BreedIndexViewModel
                            {
                                Name = d.Pet.Breed.Name,
                                SpeciesId = d.Pet.Breed.SpeciesId
                            }
                            : null,
                    },
                    VisitDate = d.VisitDate,
                    VisitReasonId = d.VisitReasonId,
                    VisitReason = new VisitReasonIndexViewModel
                    {
                        Id = d.VisitReasonId,
                        Name = d.VisitReason.Name,
                    },
                })
                .ToListAsync();

            return new PaginatedList<DiaryEntryIndexViewModel>(items, count, page, pageSize);
        }

        public async Task<DiaryEntryDetailsViewModel> GetDiaryEntryDetailsByIdAsync(int id)
        {
            var diaryEntry = await _context.DiaryEntries
            .Include(d => d.Pet)
                .ThenInclude(p => p.Client)
            .Include(d => d.Pet)
                .ThenInclude(p => p.Species)
            .Include(d => d.Pet)
                .ThenInclude(p => p.Breed)
            .Include(d => d.VisitReason)
                   .FirstOrDefaultAsync(p => p.Id == id);

            if (diaryEntry == null)
            {
                throw new InvalidOperationException("Not found");
            }

            return new DiaryEntryDetailsViewModel
            {
                Id = diaryEntry.Id,
                PetId = diaryEntry.PetId,
                Pet = new PetDetailsViewModel
                {
                    Id = diaryEntry.Pet.Id,
                    Name = diaryEntry.Pet.Name,
                    Gender = diaryEntry.Pet.Gender,
                    BirthDate = diaryEntry.Pet.BirthDate,
                    IsNeutered = diaryEntry.Pet.IsNeutered,
                    MicrochipNumber = diaryEntry.Pet.MicrochipNumber,
                    PassportNumber = diaryEntry.Pet.PassportNumber,
                    ClientId = diaryEntry.Pet.ClientId,
                    Client = new ClientIndexViewModel
                    {
                        FirstName = diaryEntry.Pet.Client.FirstName,
                        LastName = diaryEntry.Pet.Client.LastName,
                        Phone = diaryEntry.Pet.Client.Phone,
                        Email = diaryEntry.Pet.Client.Email,
                    },
                    SpeciesId = diaryEntry.Pet.SpeciesId,
                    Species = new SpeciesIndexViewModel
                    {
                        Name = diaryEntry.Pet.Species.Name,
                        Icon = diaryEntry.Pet.Species.Icon,
                    },
                    BreedId = diaryEntry.Pet.BreedId,
                    Breed = diaryEntry.Pet.Breed != null
                        ? new BreedIndexViewModel
                        {
                            Name = diaryEntry.Pet.Breed.Name,
                            SpeciesId = diaryEntry.Pet.Breed.SpeciesId
                        }
                        : null
                },
                VisitDate = diaryEntry.VisitDate,
                VisitReasonId = diaryEntry.VisitReasonId,
                VisitReason = new VisitReasonIndexViewModel
                {
                    Id = diaryEntry.VisitReasonId,
                    Name = diaryEntry.VisitReason.Name,
                },
                Behaviour = diaryEntry.Behaviour,
                BodyConditionScore = diaryEntry.BodyConditionScore,
                Description = diaryEntry.Description,
                Temperature = diaryEntry.Temperature,
                Pulse = diaryEntry.Pulse,
                Weight = diaryEntry.Weight
            };
        }

        public async Task<DiaryEntryCreateViewModel> GetDiaryEntryCreateViewModelAsync()
        {
            IEnumerable<PetIndexViewModel> pets = await _context.Pets
             .Select(s => new PetIndexViewModel
             {
                 Id = s.Id,
                 Name = s.Name
             })
             .ToListAsync();

            IEnumerable<VisitReasonIndexViewModel> visitReasons = await _context.VisitReasons
             .Select(s => new VisitReasonIndexViewModel
             {
                 Id = s.Id,
                 Name = s.Name
             })
             .ToListAsync();

            return new DiaryEntryCreateViewModel
            {
                Pets = pets,
                VisitReasons = visitReasons,
            };
        }

        public async Task AddDiaryEntryAsync(DiaryEntryCreateViewModel model)
        {
            var diaryEntry = new DiaryEntry
            {
                PetId = model.PetId,
                VisitDate = model.VisitDate,
                VisitReasonId = model.VisitReasonId,
                Behaviour = model.Behaviour,
                BodyConditionScore = model.BodyConditionScore,
                Description = model.Description,
                Temperature = model.Temperature,
                Pulse = model.Pulse,
                Weight = model.Weight
            };
            _context.DiaryEntries.Add(diaryEntry);
            await _context.SaveChangesAsync();
        }

        public async Task<DiaryEntryEditViewModel> GetDiaryEntryForEditAsync(int id)
        {
            var diaryEntry = await _context.DiaryEntries
                        .Include(d => d.Pet)
                            .ThenInclude(p => p.Client)
                        .Include(d => d.Pet)
                            .ThenInclude(p => p.Species)
                        .Include(d => d.Pet)
                            .ThenInclude(p => p.Breed)
                        .Include(d => d.VisitReason)
                               .FirstOrDefaultAsync(p => p.Id == id);

            if (diaryEntry == null)
            {
                throw new InvalidOperationException("Diary Entry not found");
            }

            IEnumerable<PetIndexViewModel> pets = await _context.Pets
             .Select(p => new PetIndexViewModel
             {
                 Id = p.Id,
                 Name = p.Name
             })
             .ToListAsync();

            IEnumerable<VisitReasonIndexViewModel> visitReasons = await _context.VisitReasons
             .Select(v => new VisitReasonIndexViewModel
             {
                 Id = v.Id,
                 Name = v.Name
             })
             .ToListAsync();

            return new DiaryEntryEditViewModel
            {
                Id = diaryEntry.Id,
                PetId = diaryEntry.PetId,
                Pet = new PetDetailsViewModel
                {
                    Id = diaryEntry.Pet.Id,
                    Name = diaryEntry.Pet.Name,
                    Gender = diaryEntry.Pet.Gender,
                    BirthDate = diaryEntry.Pet.BirthDate,
                    IsNeutered = diaryEntry.Pet.IsNeutered,
                    MicrochipNumber = diaryEntry.Pet.MicrochipNumber,
                    PassportNumber = diaryEntry.Pet.PassportNumber,
                    ClientId = diaryEntry.Pet.ClientId,
                    Client = new ClientIndexViewModel
                    {
                        FirstName = diaryEntry.Pet.Client.FirstName,
                        LastName = diaryEntry.Pet.Client.LastName,
                        Phone = diaryEntry.Pet.Client.Phone,
                        Email = diaryEntry.Pet.Client.Email,
                    },
                    SpeciesId = diaryEntry.Pet.SpeciesId,
                    Species = new SpeciesIndexViewModel
                    {
                        Name = diaryEntry.Pet.Species.Name,
                        Icon = diaryEntry.Pet.Species.Icon,
                    },
                    BreedId = diaryEntry.Pet.BreedId,
                    Breed = diaryEntry.Pet.Breed != null
                        ? new BreedIndexViewModel
                        {
                            Name = diaryEntry.Pet.Breed.Name,
                            SpeciesId = diaryEntry.Pet.Breed.SpeciesId
                        }
                        : null
                },
                VisitDate = diaryEntry.VisitDate,
                VisitReasonId = diaryEntry.VisitReasonId,
                VisitReason = new VisitReasonIndexViewModel
                {
                    Id = diaryEntry.VisitReasonId,
                    Name = diaryEntry.VisitReason.Name,
                },
                Behaviour = diaryEntry.Behaviour,
                BodyConditionScore = diaryEntry.BodyConditionScore,
                Description = diaryEntry.Description,
                Temperature = diaryEntry.Temperature,
                Pulse = diaryEntry.Pulse,
                Weight = diaryEntry.Weight,
                Pets = pets,
                VisitReasons = visitReasons,
            };
        }

        public async Task EditDiaryEntryAsync(DiaryEntryEditViewModel model)
        {
            var diaryEntry = await _context.DiaryEntries.FirstOrDefaultAsync(d => d.Id == model.Id);
            if (diaryEntry == null)
            {
                throw new ArgumentException("Diary Entry not found.");
            }
            diaryEntry.VisitDate = model.VisitDate;
            diaryEntry.Behaviour = model.Behaviour;
            diaryEntry.BodyConditionScore = model.BodyConditionScore;
            diaryEntry.Description = model.Description;
            diaryEntry.Temperature = model.Temperature;
            diaryEntry.Pulse = model.Pulse;
            diaryEntry.Weight = model.Weight;
            diaryEntry.PetId = model.PetId;
            diaryEntry.VisitReasonId = model.VisitReasonId;
            await _context.SaveChangesAsync();
        }

        public async Task<DiaryEntryDeleteViewModel> GetDiaryEntryDeleteDetailsAsync(int id)
        {
            DiaryEntry? diaryEntry = await _context.DiaryEntries
                .Include(d => d.Pet)
                    .ThenInclude(p => p.Client)
                .Include(d => d.Pet)
                    .ThenInclude(p => p.Species)
                .Include(d => d.Pet)
                    .ThenInclude(p => p.Breed)
                .Include(d => d.VisitReason)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (diaryEntry == null)
            {
                throw new ArgumentException("Pet not found.");
            }

            return new DiaryEntryDeleteViewModel
            {
                Id = diaryEntry.Id,
                PetId = diaryEntry.PetId,
                Pet = new PetDetailsViewModel
                {
                    Id = diaryEntry.Pet.Id,
                    Name = diaryEntry.Pet.Name,
                    Gender = diaryEntry.Pet.Gender,
                    BirthDate = diaryEntry.Pet.BirthDate,
                    IsNeutered = diaryEntry.Pet.IsNeutered,
                    MicrochipNumber = diaryEntry.Pet.MicrochipNumber,
                    PassportNumber = diaryEntry.Pet.PassportNumber,
                    ClientId = diaryEntry.Pet.ClientId,
                    Client = new ClientIndexViewModel
                    {
                        FirstName = diaryEntry.Pet.Client.FirstName,
                        LastName = diaryEntry.Pet.Client.LastName,
                        Phone = diaryEntry.Pet.Client.Phone,
                        Email = diaryEntry.Pet.Client.Email,
                    },
                    SpeciesId = diaryEntry.Pet.SpeciesId,
                    Species = new SpeciesIndexViewModel
                    {
                        Name = diaryEntry.Pet.Species.Name,
                        Icon = diaryEntry.Pet.Species.Icon,
                    },
                    BreedId = diaryEntry.Pet.BreedId,
                    Breed = diaryEntry.Pet.Breed != null
                        ? new BreedIndexViewModel
                        {
                            Name = diaryEntry.Pet.Breed.Name,
                            SpeciesId = diaryEntry.Pet.Breed.SpeciesId
                        }
                        : null
                },
                VisitReasonId = diaryEntry.VisitReasonId,
                VisitReason = new VisitReasonIndexViewModel
                {
                    Id = diaryEntry.VisitReasonId,
                    Name = diaryEntry.VisitReason.Name,
                },
                Description = diaryEntry.Description
            };
        }

        public async Task DeleteDiaryEntryAsync(int id)
        {
            var diaryEntry = await _context.DiaryEntries
                .FirstOrDefaultAsync(p => p.Id == id);

            if (diaryEntry == null)
            {
                throw new ArgumentException("Diary Entry not found.");
            }
            _context.DiaryEntries.Remove(diaryEntry);
            await _context.SaveChangesAsync();
        }

    }
}