using System.ComponentModel.DataAnnotations;

namespace BackendProject.Data
{
    public class Bootcamp
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Informacion { get; set; }
        public string Costos { get; set; }
        public int Id_Institucion { get; set; }
    }
}