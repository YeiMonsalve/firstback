using AutoMapper;
using BackendProject.Data;
using FIRSTBACK.Tematicas;
using Microsoft.EntityFrameworkCore;

public class TematicaService : ITematicaService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public TematicaService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Tematica>> GetAllAsync()
    {
        return await _context.Tematicas.ToListAsync();
    }

    public async Task<Tematica?> GetByIdAsync(int id)
    {
        return await _context.Tematicas.FindAsync(id);
    }

    public async Task<int> CreateAsync(TematicaDTO tematicaDTO)
    {
        Tematica tematica = _mapper.Map<Tematica>(tematicaDTO);
        _context.Tematicas.Add(tematica);
        await _context.SaveChangesAsync();

        return tematica.Id;
    }

    public async Task UpdateAsync(int id, TematicaDTO tematicaDTO)
    {
        var existingTematica = await _context.Tematicas.FindAsync(id);

        if (existingTematica != null)
        {
            _mapper.Map(tematicaDTO, existingTematica);
            _context.Tematicas.Update(existingTematica);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var tematica = await _context.Tematicas.FindAsync(id);
        if (tematica != null)
        {
            _context.Tematicas.Remove(tematica);
            await _context.SaveChangesAsync();
        }
    }
}
