using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using VetDiary.Data;
using VetDiary.Data.Models;
using VetDiary.Services.Interfaces;
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
                }
            })
            .ToListAsync();
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
                    Name = s.Name
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
                    Name = species.Name
                }
            };
        }
    }
}