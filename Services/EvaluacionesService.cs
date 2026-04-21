using AutoMapper;
using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;

namespace SisColegio.Services
{
    public class EvaluacionesService : IEvaluacionesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public EvaluacionesService(
                             IUnitOfWork unitOfWork,
                             IMapper mapper,
                             IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<EvaluacionesDto>> GetAllAsync()
        {
            var evaluaciones = await _unitOfWork.Nota.GetAllAsync();
            return _mapper.Map<IEnumerable<EvaluacionesDto>>(evaluaciones);
        }

        public async Task<EvaluacionesDto?> GetByIdAsync(int id)
        {
            var evaluaciones = await _unitOfWork.Nota.GetByIdAsync(id);
            if (evaluaciones == null)
                return null;

            return _mapper.Map<EvaluacionesDto>(evaluaciones);
        }
        public async Task<EvaluacionesDto> AddAsync(EvaluacionesDto dto)
        {
            var objeto = _mapper.Map<Evaluacione>(dto);

            await _unitOfWork.Evaluacione.AddAsync(objeto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<EvaluacionesDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, EvaluacionesDto dto)
        {
            if (id != dto.Id)
                return false;

            var objeto = await _unitOfWork.Evaluacione.GetByIdAsync(id);
            if (objeto == null)
                return false;

            objeto.IdAsignacion = dto.IdAsignacion;
            objeto.IdTrimestre = dto.IdTrimestre;
            objeto.Titulo = dto.Titulo;
            objeto.Descripcion = dto.Descripcion;
            objeto.Tipo = dto.Tipo;
            objeto.Porcentaje = dto.Porcentaje;
            objeto.FechaPublicacion = dto.FechaPublicacion;
            objeto.FechaEntrega = dto.FechaEntrega;

            _unitOfWork.Evaluacione.Update(objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var evaluaciones = await _unitOfWork.Evaluacione.GetByIdAsync(id);
            if (evaluaciones == null)
                return false;

            await _unitOfWork.Evaluacione.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResponse<IEnumerable<EvaluacionesDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var evaluaciones = await _unitOfWork.Evaluacione.GetAllAsync(filter);
            var evaluacionesDto = _mapper.Map<IEnumerable<EvaluacionesDto>>(evaluaciones);

            return new ApiResponse<IEnumerable<EvaluacionesDto>>(evaluacionesDto, evaluaciones.MetaData);
        }



    }
}