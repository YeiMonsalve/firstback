using Users_Opportunities.DTO;
using Users_Opportunities.Models;

namespace Users_Opportunities.Sevices
{
    public interface IUsers_OpportunitiesServices
    {
        Task<IEnumerable<UserOpportunity>>GetAllAsync();

         Task<IOportunity?> GetByIdAsync(int id);
        
        Task<UserOpportunity>CreateAsync(UsersOpportunityDTO usersOpportunityDTO);

        Task<UserOpportunity>UpdateAsync(int Id, UsersOpportunityDTO usersOpportunitiesDTO);

        Task DeleteAsync(int id);
    }

    public interface IOportunity
    {
        int userId { get; set; }
    }
}