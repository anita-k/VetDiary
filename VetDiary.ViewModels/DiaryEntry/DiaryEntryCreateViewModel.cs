using System.ComponentModel.DataAnnotations;
using VetDiary.ViewModels.Breed;
using VetDiary.ViewModels.Client;
using VetDiary.ViewModels.Pet;
using VetDiary.ViewModels.Species;
using VetDiary.ViewModels.VisitReason;

namespace VetDiary.ViewModels.DiaryEntry
{
    public class DiaryEntryCreateViewModel
    {

        [Required]
        [Display(Name = "Pet")]
        public int PetId { get; set; }

        [Required]
        public DateTime VisitDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Visit Reason")]
        public int VisitReasonId { get; set; }

        public string? Description { get; set; } = null;

        public float? Weight { get; set; } = null;

        [Range(1, 50)]
        public float? Temperature { get; set; } = null;

        [Range(1, 2000)]
        public int? Pulse { get; set; } = null;

        public string? Behaviour { get; set; } = null;

        [Range(1, 9)]
        public int? BodyConditionScore { get; set; } = null;

        public IEnumerable<PetIndexViewModel>? Pets { get; set; }
        public IEnumerable<VisitReasonIndexViewModel>? VisitReasons { get; set; }


    }
}
