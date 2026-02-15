using VetDiary.ViewModels.Pet;
using VetDiary.ViewModels.VisitReason;

namespace VetDiary.ViewModels.DiaryEntry
{
    public class DiaryEntryIndexViewModel
    {
        public int Id { get; set; }

        public int PetId { get; set; }

        public PetIndexViewModel Pet { get; set; } = null!;

        public DateTime VisitDate { get; set; }

        public int VisitReasonId { get; set; }

        public VisitReasonIndexViewModel VisitReason { get; set; } = null!;

    }
}
