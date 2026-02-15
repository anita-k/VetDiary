using System.ComponentModel;
using VetDiary.ViewModels.Pet;
using VetDiary.ViewModels.VisitReason;

namespace VetDiary.ViewModels.DiaryEntry
{
    public class DiaryEntryDetailsViewModel
    {
        public int Id { get; set; }

        public int PetId { get; set; }

        public PetDetailsViewModel Pet { get; set; } = null!;

        [DisplayName("Visit Date")]
        public DateTime VisitDate { get; set; }

        [DisplayName("Visit Reason Id")]
        public int VisitReasonId { get; set; }

        [DisplayName("Visit Reason")]
        public VisitReasonIndexViewModel VisitReason { get; set; } = null!;

        public string? Description { get; set; } = null;

        public float? Weight { get; set; } = null;

        public float? Temperature { get; set; } = null;

        public int? Pulse { get; set; } = null;

        public string? Behaviour { get; set; } = null;

        [DisplayName ("Body Condition Score")]
        public int? BodyConditionScore { get; set; } = null;

    }
}
