using Microsoft.EntityFrameworkCore;
using VetDiary.Data;
using VetDiary.Data.Models;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels;
using VetDiary.ViewModels.Species;

namespace VetDiary.Services
{
    public class SpeciesService : ISpeciesService
    {
        private readonly ApplicationDbContext _context;

        public SpeciesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpeciesIndexViewModel>> GetAllSpeciesAsync()
        {
            return await _context.Species.Select(vr => new SpeciesIndexViewModel
            {
                Id = vr.Id,
                Name = vr.Name,
                Icon = vr.Icon,
            })
            .ToListAsync();
        }

        public async Task<PaginatedList<SpeciesIndexViewModel>> GetAllSpeciesAsync(int page, int pageSize, string? searchTerm = null, string? sortBy = null, bool sortDesc = false)
        {
            var query = _context.Species.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(s => s.Name.Contains(searchTerm));
            }

            query = sortBy switch
            {
                "name" => sortDesc ? query.OrderByDescending(s => s.Name) : query.OrderBy(s => s.Name),
                _ => query.OrderBy(s => s.Name)
            };

            var count = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(vr => new SpeciesIndexViewModel
                {
                    Id = vr.Id,
                    Name = vr.Name,
                    Icon = vr.Icon,
                })
                .ToListAsync();

            return new PaginatedList<SpeciesIndexViewModel>(items, count, page, pageSize);
        }

        public async Task<SpeciesDetailsViewModel> GetSpeciesDetailsByIdAsync(int id)
        {
            var Species = await _context.Species
                .FirstOrDefaultAsync(vr => vr.Id == id);

            if (Species == null)
            {
                throw new InvalidOperationException("Not found");
            }

            return new SpeciesDetailsViewModel
            {
                Id = Species.Id,
                Name = Species.Name,
                Icon = Species.Icon,
            };
        }

        public async Task<SpeciesCreateViewModel> GetSpeciesCreateViewModelAsync()
        {
            throw new NotImplementedException { };
        }

        public async Task AddSpeciesAsync(SpeciesCreateViewModel model)
        {
            var Species = new Species
            {
                Name = model.Name,
            };

            _context.Species.Add(Species);
            await _context.SaveChangesAsync();
        }

        public async Task<SpeciesEditViewModel> GetSpeciesForEditAsync(int id)
        {
            var Species = await _context.Species.FirstOrDefaultAsync(r => r.Id == id);

            if (Species == null)
            {
                throw new ArgumentException("Species not found.");
            }

            return new SpeciesEditViewModel
            {
                Name = Species.Name,
            };
        }

        public async Task EditSpeciesAsync(SpeciesEditViewModel model)
        {
                var Species = await _context.Species.FirstOrDefaultAsync(r => r.Id == model.Id);
                if (Species == null)
                {
                    throw new ArgumentException("Species not found.");
                }
                Species.Name = model.Name;
                await _context.SaveChangesAsync();
        }


        public async Task DeleteSpeciesAsync(int id)
        {
            var species = await _context.Species
                .FirstOrDefaultAsync(r => r.Id == id);

            if (species == null)
            {
                throw new ArgumentException("Species not found.");
            }

            _context.Species.Remove(species);
            await _context.SaveChangesAsync();
        }

        public async Task<SpeciesDeleteViewModel> GetSpeciesDeleteDetailsAsync(int id)
        {
            var Species = await _context.Species.FirstOrDefaultAsync(r => r.Id == id);

            if (Species == null)
            {
                throw new ArgumentException("Species not found.");
            }

            return new SpeciesDeleteViewModel
            {
                Id = Species.Id,
                Name = Species.Name,
            };
        }

    }
}