using System.ComponentModel.DataAnnotations;

namespace firstback.bootcamps
{
    public class BootcampInstitucionDTO
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Informacion { get; set; }
        public int Costos { get; set; }
        public int InstitucionId { get; set; }
        public string? NombreInstitucion { get; set; }
    }
}