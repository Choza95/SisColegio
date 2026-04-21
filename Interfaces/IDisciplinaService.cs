using SisColegio.Data;
using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface IDisciplinaService
    {
        Task<IEnumerable<DisciplinaDto>> GetAllAsync();
        Task<DisciplinaDto?> GetByIdAsync(int id);
        Task<DisciplinaDto> AddAsync(DisciplinaDto dto);
        Task<bool> UpdateAsync(int id, DisciplinaDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<DisciplinaDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
