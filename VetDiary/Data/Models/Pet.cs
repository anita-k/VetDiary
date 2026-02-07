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

        public bool? IsNeutered { get; set; } = null;

        public DateOnly? BirthDate { get; set; } = null;

        public int? MicrochipNumber { get; set; } = null;

        public string? PassportNumber { get; set; } = string.Empty;


        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        [Required]
        public int SpeciesId { get; set; }
        public Species Species { get; set; } = null!;


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
