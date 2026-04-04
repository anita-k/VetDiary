using System.ComponentModel.DataAnnotations;
using VetDiary.Shared;
using VetDiary.ViewModels.Pet;

namespace VetDiary.ViewModels.Client
{
    public class ClientEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.ClientFirstNameMaxLength)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.ClientLastNameMaxLength)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(ValidationConstants.PhoneMaxLength)]
        public string Phone { get; set; } = null!;

        [StringLength(ValidationConstants.AddressMaxLength)]
        public string? Address { get; set; }

        [EmailAddress]
        [StringLength(ValidationConstants.EmailAddressMaxLength)]
        public string? Email { get; set; }

    }
}