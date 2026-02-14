using System.ComponentModel.DataAnnotations;

namespace VetDiary.ViewModels.Species
{
    public class SpeciesEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

    }
}
