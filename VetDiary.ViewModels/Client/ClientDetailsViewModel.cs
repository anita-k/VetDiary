using System.ComponentModel.DataAnnotations;
using VetDiary.ViewModels.Pet;

namespace VetDiary.ViewModels.Client
{
    public class ClientDetailsViewModel
    {
        public int Id { get; set; }
               
        public string FirstName { get; set; } = null!;
                
        public string LastName { get; set; } = null!;

        [Display(Name = "Full Name")]
        public string FullName => FirstName + " " + LastName;
               
        public string Phone { get; set; } = null!;

        public string? Address { get; set; }

        public string? Email { get; set; }

        public ICollection<PetIndexViewModel> Pets { get; set; } = new List<PetIndexViewModel>();
    }
}
