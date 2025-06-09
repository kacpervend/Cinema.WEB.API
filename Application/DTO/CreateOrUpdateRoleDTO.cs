using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateOrUpdateRoleDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
