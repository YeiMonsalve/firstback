using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using firstback.user;

namespace firstback.roles
{
    public class Roles
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? rol { get; set; }

        [JsonIgnore] 
        public ICollection<User>? Users { get; set; }
    }
}