using SisColegio.Dtos;

namespace SisColegio.Interfaces
{
    public interface ITrimestreService
    {
        Task<IEnumerable<TrimestreDto>> GetAllAsync();
        Task<TrimestreDto?> GetByIdAsync(int id);
        Task<TrimestreDto> AddAsync(TrimestreDto dto);
        Task<bool> UpdateAsync(int id, TrimestreDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
