using System.ComponentModel.DataAnnotations;

namespace VetDiary.ViewModels.Client
{
    public class ClientIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Full Name")]
        public string FullName => FirstName + " " + LastName;
               
        public string Phone { get; set; } = null!;

        public string? Email { get; set; }

    }
}
