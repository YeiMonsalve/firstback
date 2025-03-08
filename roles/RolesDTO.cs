using System.ComponentModel.DataAnnotations;

namespace firstback.roles
{
    public class RolesDTO
    {
        [Required]
        public string? rol { get; set; }
    }
}