using System.ComponentModel.DataAnnotations;
using VetDiary.Data.Models;

namespace VetDiary.ViewModels.Pet
{
    public class PetCreateViewModel
    {
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

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Display(Name = "Species")]
        public int SpeciesId { get; set; }

        [Display(Name = "Breed")]
        public int? BreedId { get; set; } = null;

    }
}
