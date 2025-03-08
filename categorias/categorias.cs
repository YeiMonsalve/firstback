using System.ComponentModel.DataAnnotations;

namespace firstback.categorias
{
    public class Categorias
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? nombre { get; set; }
        [Required]

        public string? descripcion { get; set; }
    }
}