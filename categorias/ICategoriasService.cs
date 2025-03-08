namespace firstback.categorias
{
    public interface ICategoriasService
    {
        Task<IEnumerable<Categorias>> GetAllAsync();
        Task<Categorias?> GetByIDAsync(int id);
        Task<int> CreateAsync(CategoriasDTO categoria);
        Task UpdateAsync(int id, CategoriasDTO categoria);
        Task DeleteAsync(int id);
    }
}