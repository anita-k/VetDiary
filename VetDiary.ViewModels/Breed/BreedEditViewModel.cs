using System.ComponentModel.DataAnnotations;
using VetDiary.Shared;
using VetDiary.ViewModels.Species;

namespace VetDiary.ViewModels.Breed
{
    public class BreedEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.BreedNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Species")]
        public int SpeciesId { get; set; }

        public IEnumerable<SpeciesIndexViewModel>? Species { get; set; }

    }
}