namespace FIRSTBACK.Instituciones
{
    public interface IInstitucionService
    {
        Task<IEnumerable<Institucion>> GetAllAsync();
        Task<Institucion?> GetByIdAsync(int id);
        Task<int> CreateAsync(InstitucionDTO institucion);
        Task UpdateAsync(int id, InstitucionDTO institucion);
        Task DeleteAsync(int id);
    }
}