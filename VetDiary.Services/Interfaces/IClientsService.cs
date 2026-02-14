using VetDiary.ViewModels.Client;

namespace VetDiary.Services.Interfaces
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientIndexViewModel>> GetAllClientAsync();

        Task<ClientDetailsViewModel> GetClientDetailsByIdAsync(int id);

        Task<ClientCreateViewModel> GetClientCreateViewModelAsync();

        Task AddClientAsync(ClientCreateViewModel model);

        Task<ClientEditViewModel> GetClientForEditAsync(int id);

        Task EditClientAsync(ClientEditViewModel model);

        Task<ClientDeleteViewModel> GetClientDeleteDetailsAsync(int id);

        Task DeleteClientAsync(int id);

    }
}
