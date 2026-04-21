using SisColegio.Data;
using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface IEvaluacionesService
    {
        Task<IEnumerable<EvaluacionesDto>> GetAllAsync();
        Task<EvaluacionesDto?> GetByIdAsync(int id);
        Task<EvaluacionesDto> AddAsync(EvaluacionesDto dto);
        Task<bool> UpdateAsync(int id, EvaluacionesDto dto);

        Task<bool> DeleteAsync(int id);

        Task<ApiResponse<IEnumerable<EvaluacionesDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
