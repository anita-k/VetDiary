using System.ComponentModel.DataAnnotations;

namespace VetDiary.ViewModels.Client
{
    public class ClientCreateViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        public string Phone { get; set; } = null!;

        public string? Address { get; set; }

        public string? Email { get; set; }
               
    }
}
