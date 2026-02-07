using System.ComponentModel.DataAnnotations;

namespace VetDiary.Data.Models
{
    public class Breed
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public int SpeciesId { get; set; }
                
        public Species Species { get; set; } = null!;


    }
}
