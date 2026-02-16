using System.ComponentModel.DataAnnotations;
using VetDiary.Shared;

namespace VetDiary.Data.Models
{
    public class VisitReason
    {
        [Key]
        public int Id { get; set; }

        [Required]        
        [MaxLength(ValidationConstants.VisitReasonNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<DiaryEntry> DiaryEntries { get; } = new List<DiaryEntry>();
    }
}