using AutoMapper;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Services
{
    public class NotaService : INotaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public NotaService(
                     IUnitOfWork unitOfWork,
                     IMapper mapper,
                     IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<NotaDto>> GetAllAsync()
        {
            var nota = await _unitOfWork.Nota.GetAllAsync();
            return _mapper.Map<IEnumerable<NotaDto>>(nota);
        }

        public async Task<NotaDto?> GetByIdAsync(int id)
        {
            var nota = await _unitOfWork.Nota.GetByIdAsync(id);
            if (nota == null)
                return null;

            return _mapper.Map<NotaDto>(nota);
        }
        public async Task<NotaDto> AddAsync(NotaDto dto)
        {
            var objeto = _mapper.Map<Nota>(dto);

            await _unitOfWork.Nota.AddAsync(objeto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<NotaDto>(objeto);
        }
        public async Task<bool> UpdateAsync(int id, NotaDto dto)
        {
            if (id != dto.Id)
                return false;

            var objeto = await _unitOfWork.Nota.GetByIdAsync(id);
            if (objeto == null)
                return false;

            objeto.IdEstudiante = dto.IdEstudiante;
            objeto.IdEvaluacion = dto.IdEvaluacion;
            objeto.Nota1 = dto.Nota1;
            
            

            _unitOfWork.Nota.Update(objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var nota = await _unitOfWork.Nota.GetByIdAsync(id);
            if (nota == null)
                return false;

            await _unitOfWork.Nota.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}