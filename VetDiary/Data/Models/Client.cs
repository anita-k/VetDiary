using System.ComponentModel.DataAnnotations;

namespace VetDiary.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;


    }
}
