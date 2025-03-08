using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using firstback.bootcamps;

namespace FIRSTBACK.Instituciones
{
    public class Institucion
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }

        public string? ubicacion { get; set; }

        public string? url_generalidades { get; set; }

        public string? url_oferta_academica { get; set; }

        public string? url_bienestar { get; set; }

        public string? url_admision { get; set; }

        [JsonIgnore]
        public ICollection<Bootcamp>? bootcamps { get; set; }
    }
}