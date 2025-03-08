using AutoMapper;
using Institutions_Opportunity.DTO;
using Institutions_Opportunity.Models;

namespace FIRSTBACK.Institutions_Opportunity.DTO
{
    public class InstitutionOpportunityProfile : Profile
    {
        public InstitutionOpportunityProfile()
        {
            // De DTO a Entidad
            CreateMap<InstitutionOpportunityDTO, InstitutionOpportunity>();
            // De Entidad a DTO
            CreateMap<InstitutionOpportunity, InstitutionOpportunityDTO>();
        }
    }
}