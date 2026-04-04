using VetDiary.ViewModels;
using VetDiary.ViewModels.VisitReason;

namespace VetDiary.Services.Interfaces
{
    public interface IVisitReasonsService
    {
        Task<IEnumerable<VisitReasonIndexViewModel>> GetAllVisitReasonsAsync();

        Task<PaginatedList<VisitReasonIndexViewModel>> GetAllVisitReasonsAsync(int page, int pageSize, string? searchTerm = null, string? sortBy = null, bool sortDesc = false);

        Task<VisitReasonDetailsViewModel> GetVisitReasonDetailsByIdAsync(int id);

        Task<VisitReasonCreateViewModel> GetVisitReasonCreateViewModelAsync();

        Task AddVisitReasonAsync(VisitReasonCreateViewModel model);

        Task<VisitReasonEditViewModel> GetVisitReasonForEditAsync(int id);

        Task EditVisitReasonAsync(VisitReasonEditViewModel model);

    }
}
