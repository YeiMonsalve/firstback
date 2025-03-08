using BackendProject.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace FIRSTBACK.Instituciones
{
    public class InstitucionService : IInstitucionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InstitucionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Institucion>> GetAllAsync()
        {
            return await _context.Instituciones.ToListAsync();
        }

        public async Task<Institucion?> GetByIdAsync(int id)
        {
            return await _context.Instituciones.FindAsync(id);
        }

        public async Task<int> CreateAsync(InstitucionDTO institucionDTO)
        {
            Institucion institucion = _mapper.Map<Institucion>(institucionDTO);
            _context.Instituciones.Add(institucion);
            await _context.SaveChangesAsync();

            return institucion.id;
        }

        public async Task UpdateAsync(int id, InstitucionDTO institucionDTO)
        {
            var existingInstitucion = await _context.Instituciones.FindAsync(id);
            if (existingInstitucion != null)
            {
                _mapper.Map(institucionDTO, existingInstitucion);
                _context.Instituciones.Update(existingInstitucion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var institucion = await _context.Instituciones.FindAsync(id);
            if (institucion != null)
            {
                _context.Instituciones.Remove(institucion);
                await _context.SaveChangesAsync();
            }
        }
    }
}