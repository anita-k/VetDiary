using System.ComponentModel.DataAnnotations;

namespace VetDiary.ViewModels.VisitReason
{
    public class VisitReasonCreateViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;   

    }
}