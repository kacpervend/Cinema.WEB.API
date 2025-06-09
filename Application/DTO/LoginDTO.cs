using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class LoginDTO
    {
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
