using System.ComponentModel.DataAnnotations;
using VetDiary.ViewModels.Pet;
using VetDiary.ViewModels.VisitReason;

namespace VetDiary.ViewModels.DiaryEntry
{
    public class DiaryEntryDeleteViewModel
    {
        public int Id { get; set; }

        public int PetId { get; set; }

        public PetDetailsViewModel Pet { get; set; } = null!;

        [Display(Name = "Visit Date")]
        public DateTime VisitDate { get; set; }

        [Display(Name = "Visit Reason")]
        public int VisitReasonId { get; set; }

        public VisitReasonIndexViewModel VisitReason { get; set; } = null!;

        public string? Description { get; set; } = null;
    }
}
