using System.ComponentModel.DataAnnotations;

namespace firstback.user
{
    public class UserRoleDTO
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Email { get; set; }
        public string? rol { get; set; }
    }
}