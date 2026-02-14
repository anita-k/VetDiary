using VetDiary.ViewModels.VisitReason;

namespace VetDiary.Services.Interfaces
{
    public interface IVisitReasonsService
    {
        Task<IEnumerable<VisitReasonIndexViewModel>> GetAllVisitReasonsAsync();

        Task<VisitReasonDetailsViewModel> GetVisitReasonDetailsByIdAsync(int id);

        Task<VisitReasonCreateViewModel> GetVisitReasonCreateViewModelAsync();

        Task AddVisitReasonAsync(VisitReasonCreateViewModel model);

        Task<VisitReasonEditViewModel> GetVisitReasonForEditAsync(int id);

        Task EditVisitReasonAsync(VisitReasonEditViewModel model);

    }
}
