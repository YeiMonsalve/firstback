namespace firstback.bootcamps
{
    public interface IBootcampService
    {
        Task<IEnumerable<BootcampInstitucionDTO>> GetBootcampsAsync();
        Task<BootcampInstitucionDTO?> GetBootcampByIdAsync(int id);
        Task<int> CreateBootcampAsync(BootcampDTO bootcamp);
        Task UpdateBootcampAsync(int id, BootcampDTO bootcamp);
        Task DeleteBootcampAsync(int id);
    }
}