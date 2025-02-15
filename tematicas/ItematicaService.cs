using FIRSTBACK.Tematicas;

public interface ITematicaService
{
    Task<IEnumerable<Tematica>> GetAllAsync();
    Task<Tematica?> GetByIdAsync(int id);
    Task CreateAsync(Tematica tematica);
    Task UpdateAsync(int id, Tematica tematica);
    Task DeleteAsync(int id);
}
