using System.ComponentModel.DataAnnotations;
using VetDiary.Shared;

namespace VetDiary.ViewModels.Client
{
    public class ClientCreateViewModel
    {
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
