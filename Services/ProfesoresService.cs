using AutoMapper;
using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Services
{
    public class ProfesoresService : IProfesoresService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public ProfesoresService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<ProfesoresDto>> GetAllAsync()
        {
            var profesores = await _unitOfWork.Profesores.GetAllAsync();
            return _mapper.Map<IEnumerable<ProfesoresDto>>(profesores);
        }

        public async Task<ProfesoresDto?> GetByIdAsync(int id)
        {
            var profesores = await _unitOfWork.Profesores.GetByIdAsync(id);
            if (profesores == null)
                return null;

            return _mapper.Map<ProfesoresDto>(profesores);
        }
        public async Task<ProfesoresDto> AddAsync(ProfesoresDto dto)
        {
            var objeto = _mapper.Map<Profesores>(dto);

            await _unitOfWork.Profesores.AddAsync(objeto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProfesoresDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, ProfesoresDto dto)
        {
            if (id != dto.Id)
                return false;

            var objeto = await _unitOfWork.Profesores.GetByIdAsync(id);
            if (objeto == null)
                return false;

            objeto.IdUsuario = dto.IdUsuario;
            objeto.Nombre = dto.Nombre;
            objeto.Apellido = dto.Apellido;
            objeto.Ci = dto.Ci;
            objeto.Celular = dto.Celular;
            objeto.Titulo = dto.Titulo;

            _unitOfWork.Profesores.Update(objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var profesores = await _unitOfWork.Profesores.GetByIdAsync(id);
            if (profesores == null)
                return false;

            await _unitOfWork.Profesores.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResponse<IEnumerable<ProfesoresDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var profesores = await _unitOfWork.Profesores.GetAllAsync(filter);
            var profesoresDto = _mapper.Map<IEnumerable<ProfesoresDto>>(profesores);

            return new ApiResponse<IEnumerable<ProfesoresDto>>(profesoresDto, profesores.MetaData);
        }

    }
}
