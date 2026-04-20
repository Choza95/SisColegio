using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface IAsignacioneService
    {
        Task<IEnumerable<AsignacioneDto>> GetAllAsync();
        Task<AsignacioneDto?> GetByIdAsync(int id);
        Task<AsignacioneDto> AddAsync(AsignacioneDto dto);
        Task<bool> UpdateAsync(int id, AsignacioneDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
