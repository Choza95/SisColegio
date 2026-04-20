using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface IPadreService
    {
        Task<IEnumerable<PadreDto>> GetAllAsync();
        Task<PadreDto?> GetByIdAsync(int id);
        Task<PadreDto> AddAsync(PadreDto dto);
        Task<bool> UpdateAsync(int id, PadreDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
