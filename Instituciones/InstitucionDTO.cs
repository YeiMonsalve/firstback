using System.ComponentModel.DataAnnotations;

namespace FIRSTBACK.Instituciones
{
    public class InstitucionDTO
    {
        [StringLength(255)]
        public string? nombre { get; set; }

        public string? ubicacion { get; set; }

        public string? url_generalidades { get; set; }

        public string? url_oferta_academica { get; set; }

        public string? url_bienestar { get; set; }

        public string? url_admision { get; set; }
    }
}