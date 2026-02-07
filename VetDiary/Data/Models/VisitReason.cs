using System.ComponentModel.DataAnnotations;

namespace VetDiary.Data.Models
{
    public class VisitReason
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;


    }
}