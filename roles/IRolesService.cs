namespace firstback.roles
{
    public interface IRolesService
    {
        Task<IEnumerable<Roles>> GetAllAsync();
        Task<Roles?> GetByIDAsync(int id);
        Task<int> CreateAsync(RolesDTO categoria);
        Task UpdateAsync(int id, RolesDTO categoria);
        Task DeleteAsync(int id);
    }
}