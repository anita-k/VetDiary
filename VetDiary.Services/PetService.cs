using VetDiary.Data;
using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.Pet;

namespace VetDiary.Services
{
    public class PetsService : IPetsService
    {

        private readonly ApplicationDbContext _context;

        public PetsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddPetAsync(PetCreateViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task EditPetAsync(PetEditViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PetIndexViewModel>> GetAllPetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PetCreateViewModel> GetPetCreateViewModelAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PetDeleteViewModel> GetPetDeleteDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PetDetailsViewModel> GetPetDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PetEditViewModel> GetPetForEditAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}