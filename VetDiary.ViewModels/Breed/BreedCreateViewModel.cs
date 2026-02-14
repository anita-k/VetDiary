using System.ComponentModel.DataAnnotations;
using VetDiary.ViewModels.Species;

namespace VetDiary.ViewModels.Breed
{
    public class BreedCreateViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Species")]
        public int SpeciesId { get; set; }

        public IEnumerable<SpeciesIndexViewModel>? Species { get; set; }
    }
}
