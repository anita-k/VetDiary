using System.ComponentModel.DataAnnotations;
using VetDiary.Shared;

namespace VetDiary.Data.Models
{
    public class Breed
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.BreedNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int SpeciesId { get; set; }
                
        public Species Species { get; set; } = null!;

        public ICollection<Pet> Pets { get; } = new List<Pet>();

    }
}
