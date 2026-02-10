using System.ComponentModel.DataAnnotations;

namespace VetDiary.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [Phone]
        [MaxLength(30)]
        public string Phone { get; set; } = null!;

        [MaxLength(250)]
        public string? Address { get; set; }

        [EmailAddress]
        [MaxLength(150)]
        public string? Email { get; set; }
              

        public ICollection<Pet> Pets { get; } = new List<Pet>();

    }
}
