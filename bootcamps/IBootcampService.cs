using System.Collections.Generic;
using System.Threading.Tasks;
using BackendProject.Data;

namespace BackendProject.bootcamps
{
    public interface IBootcampService
    {
        Task<IEnumerable<Bootcamp>> GetBootcampsAsync();
        Task<Bootcamp> GetBootcampByIdAsync(int id);
        Task<Bootcamp> CreateBootcampAsync(Bootcamp bootcamp);
        Task<Bootcamp> UpdateBootcampAsync(int id, Bootcamp bootcamp);
        Task<bool> DeleteBootcampAsync(int id);
    }
}