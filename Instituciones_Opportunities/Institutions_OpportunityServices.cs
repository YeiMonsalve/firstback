using Microsoft.EntityFrameworkCore;
using Institutions_Opportunity.Models;
using BackendProject.Data;

namespace FIRSTBACK.Institutions_Opportunity.Services
{
    public class Institutions_OpportunityService : IInstitutions_OpportunityService
    {
        private readonly ApplicationDbContext _context;

        public Institutions_OpportunityService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<InstitutionOpportunity>> getAllAsync()
        {
            return await _context.InstitutionOpportunities.ToListAsync();

        }

        public async Task deleteAsync(int id)
        {
            var institutionOpportunityOpportunity = await _context.InstitutionOpportunities.FindAsync();
            if (institutionOpportunityOpportunity == null)
            {
                throw new KeyNotFoundException("Institution not found");
            }

            _context.InstitutionOpportunities.Remove(institutionOpportunityOpportunity);
            await _context.SaveChangesAsync();
        }

        public async Task<InstitutionOpportunity?> getByIdAsync(int id)
        {
            return await _context.InstitutionOpportunities.FindAsync();
        }

        public async Task createAsync(InstitutionOpportunity institucionOpportunity)
        {
            _context.InstitutionOpportunities.Add(institucionOpportunity);
            await _context.SaveChangesAsync();
        }

        public async Task updateAsync(int id, InstitutionOpportunity institutionOpportunity)
        {
            var institutionOpportunityOpportunity = await _context.InstitutionOpportunities.FindAsync();
            if (institutionOpportunityOpportunity != null)
            {
               institutionOpportunityOpportunity.institutionId = institutionOpportunity.institutionId;
               institutionOpportunityOpportunity.opportunityId = institutionOpportunity.opportunityId;
               await _context.SaveChangesAsync();

            }
        }
    }


}