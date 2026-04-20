using AutoMapper;
using Microsoft.VisualBasic;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Services
{
    public class TrimestreService : ITrimestreService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public TrimestreService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<TrimestreDto>> GetAllAsync()
        {
            var trimestre = await _unitOfWork.Trimestre.GetAllAsync();
            return _mapper.Map<IEnumerable<TrimestreDto>>(trimestre);
        }

        public async Task<TrimestreDto?> GetByIdAsync(int id)
        {
            var trimestre = await _unitOfWork.Trimestre.GetByIdAsync(id);
            if (trimestre == null)
                return null;

            return _mapper.Map<TrimestreDto>(trimestre);
        }
        public async Task<TrimestreDto> AddAsync(TrimestreDto dto)
        {
            var objeto = _mapper.Map<Trimestre>(dto);

            await _unitOfWork.Trimestre.AddAsync(objeto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<TrimestreDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, TrimestreDto dto)
        {
            if (id != dto.Id)
                return false;

            var objeto = await _unitOfWork.Trimestre.GetByIdAsync(id);
            if (objeto == null)
                return false;

            objeto.Nombre = dto.Nombre;
            objeto.FechaFin = dto.FechaFin;
            objeto.FechaInicio = dto.FechaInicio;


            _unitOfWork.Trimestre.Update(objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var trimestre = await _unitOfWork.Trimestre.GetByIdAsync(id);
            if (trimestre == null)
                return false;

            await _unitOfWork.Trimestre.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}