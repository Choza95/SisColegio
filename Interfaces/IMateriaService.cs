using SisColegio.Data;
using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface IMateriaService
    {
        Task<IEnumerable<MateriaDto>> GetAllAsync();
        Task<MateriaDto?> GetByIdAsync(int id);
        Task<MateriaDto> AddAsync(MateriaDto dto);
        Task<bool> UpdateAsync(int id, MateriaDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<MateriaDto>>> GetAllAsync(PostQueryFilter filter);

    }
}
