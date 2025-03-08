using BackendProject.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace firstback.roles
{
    public class RolesService : IRolesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RolesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Roles?> GetByIDAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<int> CreateAsync(RolesDTO rolesDTO)
        {
            Roles roles = _mapper.Map<Roles>(rolesDTO);
            _context.Roles.Add(roles);
            await _context.SaveChangesAsync();

            return roles.id;
        }

        public async Task UpdateAsync(int id, RolesDTO rolesDTO)
        {
            var existingRoles = await _context.Roles.FindAsync(id);

            if (existingRoles != null)
            {
                _mapper.Map(rolesDTO, existingRoles);
                _context.Roles.Update(existingRoles);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var existingRoles = await _context.Roles.FindAsync(id);

            if (existingRoles != null)
            {
                _context.Roles.Remove(existingRoles);
                await _context.SaveChangesAsync();
            }
        }
    }
}