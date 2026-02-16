using System.ComponentModel.DataAnnotations;
using VetDiary.Shared;

namespace VetDiary.Data.Models
{
    public class Species
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.SpeciesNameMaxLength)]        
        public string Name { get; set; } = null!;

        public string? Icon { get; set; }

        public ICollection<Breed> Breeds { get; } = new List<Breed>();
        public ICollection<Pet> Pets { get; } = new List<Pet>();
    }
}
