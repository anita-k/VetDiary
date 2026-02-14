using System.ComponentModel.DataAnnotations;
using VetDiary.ViewModels.Species;

namespace VetDiary.ViewModels.Breed
{
    public class BreedDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Display(Name = "Species")]
        public int SpeciesId { get; set; }
        public SpeciesIndexViewModel Species { get; set; } = null!;

    }

}
