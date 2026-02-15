using System.ComponentModel.DataAnnotations;
using VetDiary.ViewModels.Pet;

namespace VetDiary.ViewModels.Client
{
    public class ClientEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [Phone]
        public string Phone { get; set; } = null!;

        public string? Address { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

    }
}