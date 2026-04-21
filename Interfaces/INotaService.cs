using SisColegio.Data;
using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface INotaService
    {
        Task<IEnumerable<NotaDto>> GetAllAsync();
        Task<NotaDto?> GetByIdAsync(int id);
        Task<NotaDto> AddAsync(NotaDto dto);
        Task<bool> UpdateAsync(int id, NotaDto dto);
        Task<bool> DeleteAsync(int id);

        Task<ApiResponse<IEnumerable<NotaDto>>> GetAllAsync(PostQueryFilter filter);


    }
}
