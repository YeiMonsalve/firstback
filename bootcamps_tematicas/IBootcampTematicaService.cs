namespace FIRSTBACK.BootcampsTematicas
{
    public interface IBootcampTematicaService
    {
        Task<IEnumerable<BootcampTematicaGetDto>> GetAllAsync();
        Task<BootcampTematicaGetDto?> GetByIdAsync(int idBootcamp, int idTematica);
        Task<BootcampTematicaGetDto> CreateAsync(BootcampTematicaDto bootcampTematicaDto);
        Task<bool> DeleteAsync(int idBootcamp, int idTematica);
    }
}