using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserMicroservice.Models.DTO
{
    public class AuthRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
