using System.ComponentModel.DataAnnotations.Schema;
using firstback.user;
using FIRSTBACK.Oportunidades;

namespace Users_Opportunities.Models
{
    public class UserOpportunity
    {
        [ForeignKey("id_usuario")]
        public int? userId { get; set; }

        [ForeignKey("id_usuario")]
        public virtual User? User { get; set; } // Relación a la entidad

        [ForeignKey("id_oportunidad")]
        public int? opportunityId { get; set; }

        [ForeignKey("id_oportunidad")]
        public virtual Oportunidad? Oportunidad { get; set; } // Relación a la entidad


    }
}
