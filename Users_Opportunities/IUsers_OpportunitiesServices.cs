using Users_Opportunities.DTO;
using Users_Opportunities.Models;

namespace Users_Opportunities.Sevices
{
    public interface IUsers_OpportunitiesServices
    {
        Task<IEnumerable<UserOpportunity>>GetAllAsync();

         Task<IOportunity?> GetByIdAsync(int id);
        
        Task<UserOpportunity>CreateAsync(UsersOpportunityDTO usersOpportunityDTO);

        Task<UserOpportunity>UpdateAsync(UsersOpportunityDTO usersOpportunitiesDTO);

        Task DeleteAsync(UsersOpportunityDTO usersOpportunityDTO);
    }

    public interface IOportunity
    {
    }
}