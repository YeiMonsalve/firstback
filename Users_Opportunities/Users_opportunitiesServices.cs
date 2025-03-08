using BackendProject.Data;
using Microsoft.EntityFrameworkCore;
using Users_Opportunities.DTO;
using Users_Opportunities.Models;
using Users_Opportunities.Sevices;

namespace Users_Opportunities.Services
{
    public class Users_OpportunitiesServices : IUsers_OpportunitiesServices
    {
        private readonly ApplicationDbContext _context;

        public Users_OpportunitiesServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserOpportunity>> GetAllAsync()
        {
            return await _context.UsersOpportunities.ToListAsync<UserOpportunity>();
        }
        
        public async Task<UserOpportunity> CreateAsync(UsersOpportunityDTO usersOpportunityDTO)
        {
            var userOpportunities = new UserOpportunity{
                userId = usersOpportunityDTO.UserId,
                opportunityId = usersOpportunityDTO.OpportunityId
            };
            _context.UsersOpportunities.Add(userOpportunities);
            await _context.SaveChangesAsync();

            return userOpportunities;
        }

        public async Task DeleteAsync(UsersOpportunityDTO usersOpportunityDTO)
        {
            var userOpportunities = await _context.UsersOpportunities.FindAsync();
            if (userOpportunities == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            _context.UsersOpportunities.Remove(userOpportunities);
            await _context.SaveChangesAsync();
        }

        public Task<IOportunity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserOpportunity> UpdateAsync(UsersOpportunityDTO usersOpportunitiesDTO)
        {
            throw new NotImplementedException();
        }

        public Task<UserOpportunity> UpdateAsync(int Id, UsersOpportunityDTO usersOpportunitiesDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
