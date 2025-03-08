using System.ComponentModel.DataAnnotations;
using FIRSTBACK.Instituciones;

namespace firstback.bootcamps
{
    public class Bootcamp
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Informacion { get; set; }
        public int Costos { get; set; }
        public int InstitucionId { get; set; }

        public Institucion? Institucion { get; set; }
    }
}