using System.ComponentModel.DataAnnotations;
using VetDiary.Shared;

namespace VetDiary.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ClientFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.ClientLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Display(Name = "Full Name")]
        public string FullName => FirstName + " " + LastName;

        [Required]
        [Phone]
        [MaxLength(ValidationConstants.PhoneMaxLength)]
        public string Phone { get; set; } = null!;

        [MaxLength(ValidationConstants.AddressMaxLength)]
        public string? Address { get; set; }

        [EmailAddress]
        [MaxLength(ValidationConstants.EmailAddressMaxLength)]
        public string? Email { get; set; }
              

        public ICollection<Pet> Pets { get; } = new List<Pet>();

    }
}
