using Microsoft.EntityFrameworkCore;
using VetDiary.Data;
using VetDiary.Data.Models;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels;
using VetDiary.ViewModels.Breed;
using VetDiary.ViewModels.Species;

namespace VetDiary.Services
{
    public class BreedsService : IBreedsService
    {
        private readonly ApplicationDbContext _context;

        public BreedsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BreedIndexViewModel>> GetAllBreedsAsync()
        {
            return await _context.Breeds
            .Include(b => b.Species)
            .Select(b => new BreedIndexViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Species = new SpeciesIndexViewModel
                {
                    Name = b.Species.Name,
                    Icon = b.Species.Icon,
                }
            })
            .ToListAsync();
        }

        public async Task<PaginatedList<BreedIndexViewModel>> GetAllBreedsAsync(int page, int pageSize, string? searchTerm = null, string? sortBy = null, bool sortDesc = false)
        {
            var query = _context.Breeds
                .Include(b => b.Species)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(b => b.Name.Contains(searchTerm));
            }

            query = sortBy switch
            {
                "name" => sortDesc ? query.OrderByDescending(b => b.Name) : query.OrderBy(b => b.Name),
                "species" => sortDesc ? query.OrderByDescending(b => b.Species.Name) : query.OrderBy(b => b.Species.Name),
                _ => query.OrderBy(b => b.Name)
            };

            var count = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new BreedIndexViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Species = new SpeciesIndexViewModel
                    {
                        Name = b.Species.Name,
                        Icon = b.Species.Icon,
                    }
                })
                .ToListAsync();

            return new PaginatedList<BreedIndexViewModel>(items, count, page, pageSize);
        }

        public async Task<BreedDetailsViewModel> GetBreedDetailsByIdAsync(int id)
        {
            var breed = await _context.Breeds
                .Include(b => b.Species)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (breed == null)
            {
                throw new InvalidOperationException("Not found");
            }

            return new BreedDetailsViewModel
            {
                Id = breed.Id,
                Name = breed.Name,
                Species = new SpeciesIndexViewModel
                {
                    Name = breed.Species.Name,
                    Icon = breed.Species.Icon,
                }
            };
        }

        public async Task<BreedCreateViewModel> GetBreedCreateViewModelAsync()
        {
            IEnumerable<SpeciesIndexViewModel> species = await _context.Species
             .Select(s => new SpeciesIndexViewModel
             {
                 Id = s.Id,
                 Name = s.Name
             })
             .ToListAsync();

            return new BreedCreateViewModel
            {
                Species = species
            };
        }

        public async Task AddBreedAsync(BreedCreateViewModel model)
        {
            var breed = new Breed
            {
                Name = model.Name,
                SpeciesId = model.SpeciesId,
            };
            _context.Breeds.Add(breed);
            await _context.SaveChangesAsync();
        }

        public async Task<BreedEditViewModel> GetBreedForEditAsync(int id)
        {
            var breed = await _context.Breeds
                .Include(b => b.Species)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (breed == null)
            {
                throw new ArgumentException("Breed not found.");
            }

            return new BreedEditViewModel
            {
                Name = breed.Name,
                SpeciesId = breed.Species.Id,
                Species = await _context.Species.Select(s => new SpeciesIndexViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Icon = s.Icon,
                })
                .ToListAsync()
            };
        }

        public async Task EditBreedAsync(BreedEditViewModel model)
        {
            var breed = await _context.Breeds.FirstOrDefaultAsync(b => b.Id == model.Id);
            if (breed == null)
            {
                throw new ArgumentException("Breed not found.");
            }
            breed.Name = model.Name;
            breed.SpeciesId = model.SpeciesId;
            await _context.SaveChangesAsync();
        }

        public async Task<BreedDeleteViewModel> GetBreedDeleteDetailsAsync(int id)
        {
            Breed? breed = await _context.Breeds
                .FirstOrDefaultAsync(b => b.Id == id);

            if (breed == null)
            {
                throw new ArgumentException("Breed not found.");
            }

            var species = await _context.Species.FirstOrDefaultAsync(s => s.Id == breed.SpeciesId);

            if (species == null)
            {
                throw new ArgumentException("Species not found.");
            }

            return new BreedDeleteViewModel
            {
                Id = breed.Id,
                Name = breed.Name,
                Species = new SpeciesIndexViewModel
                {
                    Name = species.Name,
                    Icon = species.Icon,
                }
            };
        }

        public async Task DeleteBreedAsync(int id)
        {
            var breed = await _context.Breeds
                .FirstOrDefaultAsync(b => b.Id == id);

            if (breed == null)
            {
                throw new ArgumentException("Breed not found.");
            }

            _context.Breeds.Remove(breed);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BreedIndexViewModel>> GetBreedsBySpecies(int speciesId)
        {
            var breeds = _context.Breeds
                .Where(b => b.SpeciesId == speciesId)
                .Select(b => new BreedIndexViewModel { 
                    Id = b.Id,
                    Name = b.Name,
                    SpeciesId = b.SpeciesId
                })
                .ToList();

            return breeds;
        }

    }

}