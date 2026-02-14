using VetDiary.Services.Interfaces;
using VetDiary.ViewModels.Client;

namespace VetDiary.Services
{
    public class ClientsService : IClientsService
    {
        public Task AddClientAsync(ClientCreateViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditClientAsync(ClientEditViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientIndexViewModel>> GetAllClientAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ClientCreateViewModel> GetClientCreateViewModelAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ClientDeleteViewModel> GetClientDeleteDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientDetailsViewModel> GetClientDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientEditViewModel> GetClientForEditAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}