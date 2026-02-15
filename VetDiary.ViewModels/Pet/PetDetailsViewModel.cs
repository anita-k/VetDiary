using System.ComponentModel.DataAnnotations;
using VetDiary.Data.Models;
using VetDiary.Shared;
using VetDiary.ViewModels.Breed;
using VetDiary.ViewModels.Client;
using VetDiary.ViewModels.DiaryEntry;
using VetDiary.ViewModels.Species;

namespace VetDiary.ViewModels.Pet
{
    public class PetDetailsViewModel
    {
        public int Id { get; set; }

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

        public int ClientId { get; set; }
        public ClientIndexViewModel Client { get; set; } = null!;

        public int SpeciesId { get; set; }
        public SpeciesIndexViewModel Species { get; set; } = null!;

        [Display(Name = "Breed")]
        public int? BreedId { get; set; } = null;
        public BreedIndexViewModel? Breed { get; set; } = null;

        public ICollection<DiaryEntryIndexViewModel> DiaryEntries { get; set; } = new List<DiaryEntryIndexViewModel>();

    }
}
