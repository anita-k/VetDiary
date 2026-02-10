using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace VetDiary.Data.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public PetGender? Gender { get; set; } = null;

        [Display(Name = "Neuter Status")]
        public bool? IsNeutered { get; set; } = null;

        [Display(Name = "Birthdate")]
        public DateOnly? BirthDate { get; set; } = null;

        [Display(Name = "Microchip Number")]
        public int? MicrochipNumber { get; set; } = null;

        [Display(Name = "Passport Number")]
        public string? PassportNumber { get; set; } = string.Empty;


        [Required]
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        [Required]
        [Display(Name = "Species")]
        public int SpeciesId { get; set; }
        public Species Species { get; set; } = null!;

        [Display(Name = "Breed")]
        public int? BreedId { get; set; } = null;
        public Breed? Breed { get; set; } = null;
    
        public ICollection<DiaryEntry> DiaryEntries { get; } = new List<DiaryEntry>();

    }

    public enum PetGender
    { 
        Male,
        Female
    } 
}
