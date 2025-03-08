using Microsoft.EntityFrameworkCore;
using BackendProject.Data;
using AutoMapper;

namespace firstback.bootcamps
{
    public class BootcampService : IBootcampService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BootcampService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BootcampInstitucionDTO>> GetBootcampsAsync()
        {
            var bootcamps = await _context.Bootcamps.Include(b => b.Institucion).ToListAsync();
            return _mapper.Map<IEnumerable<BootcampInstitucionDTO>>(bootcamps);
        }

        public async Task<BootcampInstitucionDTO?> GetBootcampByIdAsync(int id)
        {
            var bootcamp = await _context.Bootcamps.Include(b => b.Institucion).FirstOrDefaultAsync(u => u.Id == id); 

            return _mapper.Map<BootcampInstitucionDTO>(bootcamp);
        }

        public async Task<int> CreateBootcampAsync(BootcampDTO bootcampDTO)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(bootcampDTO);
            _context.Bootcamps.Add(bootcamp);
            await _context.SaveChangesAsync();

            return bootcamp.Id;
        }

        public async Task UpdateBootcampAsync(int id, BootcampDTO bootcampDTO)
        {
            var existingBootcamp = await _context.Bootcamps.FindAsync(id);

            if (existingBootcamp != null)
            {
                _mapper.Map(bootcampDTO, existingBootcamp);
                _context.Bootcamps.Update(existingBootcamp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBootcampAsync(int id)
        {
            var existingBootcamp = await _context.Bootcamps.FindAsync(id);

            if (existingBootcamp != null)
            {
                _context.Bootcamps.Remove(existingBootcamp);
                await _context.SaveChangesAsync();
            }
        }
    }
}