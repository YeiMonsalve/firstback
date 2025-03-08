using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BackendProject.Data;

namespace FIRSTBACK.BootcampsTematicas
{
    public class BootcampTematicaService : IBootcampTematicaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BootcampTematicaService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BootcampTematicaGetDto>> GetAllAsync()
        {
            var entities = await _context.BootcampTematicas
                .Include(bt => bt.Bootcamp)
                .Include(bt => bt.Tematica)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BootcampTematicaGetDto>>(entities);
        }

        public async Task<BootcampTematicaGetDto?> GetByIdAsync(int idBootcamp, int idTematica)
        {
            var entity = await _context.BootcampTematicas
                .Include(bt => bt.Bootcamp)
                .Include(bt => bt.Tematica)
                .FirstOrDefaultAsync(bt => bt.IdBootcamp == idBootcamp && bt.IdTematica == idTematica);

            return entity == null ? null : _mapper.Map<BootcampTematicaGetDto>(entity);
        }

        public async Task<BootcampTematicaGetDto> CreateAsync(BootcampTematicaDto bootcampTematicaDto)
        {
            var entity = _mapper.Map<BootcampTematica>(bootcampTematicaDto);

            _context.BootcampTematicas.Add(entity);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(entity.IdBootcamp, entity.IdTematica) ?? _mapper.Map<BootcampTematicaGetDto>(entity);
        }

        public async Task<bool> DeleteAsync(int idBootcamp, int idTematica)
        {
            var entity = await _context.BootcampTematicas
                .FirstOrDefaultAsync(bt => bt.IdBootcamp == idBootcamp && bt.IdTematica == idTematica);

            if (entity == null) return false;

            _context.BootcampTematicas.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}