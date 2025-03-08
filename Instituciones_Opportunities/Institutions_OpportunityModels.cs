using System.ComponentModel.DataAnnotations.Schema;
using FIRSTBACK.Instituciones;
using FIRSTBACK.Oportunidades;

namespace Institutions_Opportunity.Models
{
    public class InstitutionOpportunity
    {
        [ForeignKey("id_institucion")]
        public int? institutionId { get; set; }
        [ForeignKey("id_institucion")]
        public virtual Institucion? Institucion { get; set; } //Relacion a la entidad
        [ForeignKey("id_oportunidad")]
        public int? opportunityId { get; set; }
        [ForeignKey("id_oportunidad")]
        public virtual Oportunidad? Oportunidad { get; set; } //Relacion a la entidad
    }
}