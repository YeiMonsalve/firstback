using Institutions_Opportunity.Models;

namespace FIRSTBACK.Institutions_Opportunity.Services
{
    public interface IInstitutions_OpportunityService
    {
        Task<InstitutionOpportunity?> getByIdAsync(int id);
        Task<IEnumerable<InstitutionOpportunity>> getAllAsync();
        Task createAsync(InstitutionOpportunity institucionOpportunity);
        Task updateAsync(int id, InstitutionOpportunity institutionOpportunity);
        Task deleteAsync(int id);
    }

}
