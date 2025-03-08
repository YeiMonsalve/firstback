using FIRSTBACK.Tematicas;

public interface ITematicaService
{
    Task<IEnumerable<Tematica>> GetAllAsync();
    Task<Tematica?> GetByIdAsync(int id);
    Task<int> CreateAsync(TematicaDTO tematica);
    Task UpdateAsync(int id, TematicaDTO tematica);
    Task DeleteAsync(int id);
}