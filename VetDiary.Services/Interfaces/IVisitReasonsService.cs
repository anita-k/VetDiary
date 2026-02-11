using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetDiary.ViewModels;

namespace VetDiary.Services.Interfaces
{
    public interface IVisitReasonsService
    {
        Task<IEnumerable<VisitReasonViewModel>> GetAllVisitReasonsAsync();
        Task<VisitReasonViewModel> GetVisitReasonByIdAsync(int id);

        Task<VisitReasonViewModel> GetVisitReasonDetailsByIdAsync(int id);

        Task<VisitReasonCreateViewModel> GetVisitReasonCreateViewModelAsync();

        Task SaveVisitReasonAsync(int id);

        Task RemoveVisitReasonAsync(int id);

        Task<VisitReasonViewModel> GetVisitReasonForEditAsync(int id);

        Task EditVisitReasonAsync(VisitReasonViewModel model);

    }
}
