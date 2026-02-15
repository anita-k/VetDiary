using System.ComponentModel.DataAnnotations;
using VetDiary.ViewModels.Breed;
using VetDiary.ViewModels.Client;
using VetDiary.ViewModels.Species;

namespace VetDiary.ViewModels.Pet
{
    public class PetIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ClientId { get; set; }
        public ClientIndexViewModel Client { get; set; } = null!;
        public int SpeciesId { get; set; }
        public SpeciesIndexViewModel Species { get; set; } = null!;
        [Display(Name = "Breed")]
        public int? BreedId { get; set; } = null;
        public BreedIndexViewModel? Breed { get; set; } = null;

    }
}
