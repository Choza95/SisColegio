using SisColegio.Data;
using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface IAsignacioneService
    {
        Task<IEnumerable<AsignacioneDto>> GetAllAsync();
        Task<AsignacioneDto?> GetByIdAsync(int id);
        Task<AsignacioneDto> AddAsync(AsignacioneAddDto dto);
        Task<bool> UpdateAsync(int id, AsignacioneAddDto dto);
        Task<bool> DeleteAsync(int id);
        IEnumerable<AsignacioneDto?> GetAsignacionByProfesor(int idProfesor);
        Task<ApiResponse<IEnumerable<AsignacioneDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
