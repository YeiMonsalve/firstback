using Microsoft.EntityFrameworkCore;
using BackendProject.Data;

namespace BackendProject.bootcamps
{
    public class BootcampService : IBootcampService
    {
        private readonly ApplicationDbContext _context;

        public BootcampService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bootcamp>> GetBootcampsAsync()
        {
            return await _context.Bootcamps.ToListAsync();
        }

        public async Task<Bootcamp> GetBootcampByIdAsync(int id)
        {
            return await _context.Bootcamps.FindAsync(id);
        }

        public async Task<Bootcamp> CreateBootcampAsync(Bootcamp bootcamp)
        {
            _context.Bootcamps.Add(bootcamp);
            await _context.SaveChangesAsync();
            return bootcamp;
        }

        public async Task<Bootcamp> UpdateBootcampAsync(int id, Bootcamp bootcamp)
        {
            if (id != bootcamp.Id)
            {
                return null;
            }

            _context.Entry(bootcamp).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return bootcamp;
        }

        public async Task<bool> DeleteBootcampAsync(int id)
        {
            var bootcamp = await _context.Bootcamps.FindAsync(id);
            if (bootcamp == null)
            {
                return false;
            }

            _context.Bootcamps.Remove(bootcamp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}