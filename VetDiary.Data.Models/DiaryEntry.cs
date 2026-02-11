using System.ComponentModel.DataAnnotations;

namespace VetDiary.Data.Models
{
    public class DiaryEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PetId { get; set; }

        public Pet Pet { get; set; } = null!;

        [Required]
        public DateTime VisitDate { get; set; }

        [Required]
        public int VisitReasonId { get; set; }

        public VisitReason VisitReason { get; set; } = null!;

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