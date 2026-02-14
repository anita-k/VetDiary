using System.ComponentModel.DataAnnotations;

namespace VetDiary.ViewModels.Species
{
    public class SpeciesCreateViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

    }
}
