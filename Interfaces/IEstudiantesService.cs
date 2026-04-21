using SisColegio.Data;
using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface IEstudiantesService
    {
        Task<IEnumerable<EstudiantesDto>> GetAllAsync();
        Task<EstudiantesDto?> GetByIdAsync(int id);
        Task<EstudiantesDto> AddAsync(EstudiantesDto dto);
        Task<bool> UpdateAsync(int id, EstudiantesDto dto);
        Task<bool> DeleteAsync(int id);

        Task<ApiResponse<IEnumerable<EstudiantesDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
