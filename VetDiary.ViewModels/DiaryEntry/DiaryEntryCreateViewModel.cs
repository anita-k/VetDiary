using System.ComponentModel.DataAnnotations;

namespace VetDiary.ViewModels.DiaryEntry
{
    public class DiaryEntryCreateViewModel
    {

        [Required]
        public int PetId { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [Required]
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

    }
}
