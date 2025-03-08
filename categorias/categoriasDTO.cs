using System.ComponentModel.DataAnnotations;

namespace firstback.categorias
{
    public class CategoriasDTO
    {
        [Required]
        public string? nombre { get; set; }
        [Required]

        public string? descripcion { get; set; }
    }
}