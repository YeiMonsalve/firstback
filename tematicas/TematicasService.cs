using BackendProject.Data;
using FIRSTBACK.Tematicas;
using Microsoft.EntityFrameworkCore;

public class TematicaService : ITematicaService
{
    private readonly ApplicationDbContext _context;

    public TematicaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tematica>> GetAllAsync()
    {
        return await _context.Tematicas.ToListAsync();
    }

    public async Task<Tematica?> GetByIdAsync(int id)
    {
        return await _context.Tematicas.FindAsync(id);
    }

    public async Task CreateAsync(Tematica tematica)
    {
        _context.Tematicas.Add(tematica);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, Tematica tematica)
    {
        var existingTematica = await _context.Tematicas.FindAsync(id);
        if (existingTematica != null)
        {
            existingTematica.Nombre = tematica.Nombre;
            existingTematica.Descripcion = tematica.Descripcion;
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
