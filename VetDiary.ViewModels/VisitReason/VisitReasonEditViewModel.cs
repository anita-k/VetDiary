using System.ComponentModel.DataAnnotations;

namespace VetDiary.ViewModels.VisitReason
{
    public class VisitReasonEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;   

    }
}