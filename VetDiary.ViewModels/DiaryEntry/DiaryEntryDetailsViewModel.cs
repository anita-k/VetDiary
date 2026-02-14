using VetDiary.ViewModels.Pet;
using VetDiary.ViewModels.VisitReason;

namespace VetDiary.ViewModels.DiaryEntry
{
    public class DiaryEntryDetailsViewModel
    {
        public int Id { get; set; }

        public int PetId { get; set; }

        public PetDetailsViewModel Pet { get; set; } = null!;

        public DateTime VisitDate { get; set; }

        public int VisitReasonId { get; set; }

        public VisitReasonIndexViewModel VisitReason { get; set; } = null!;

        public string? Description { get; set; } = null;

        public float? Weight { get; set; } = null;

        public float? Temperature { get; set; } = null;

        public int? Pulse { get; set; } = null;

        public string? Behaviour { get; set; } = null;

        public int? BodyConditionScore { get; set; } = null;

    }
}
