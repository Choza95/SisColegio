using AutoMapper;
using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;
using SisColegio.Repositories;
using System.Collections;

namespace SisColegio.Services
{
    public class DisciplinaService : IDisciplinaService
    { 
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public readonly IPasswordHasher _passwordHasher;

        public DisciplinaService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<IEnumerable<DisciplinaDto>> GetAllAsync() 
        {
            var disciplina = await _unitOfWork.Disciplina.GetAllAsync();
            return _mapper.Map<IEnumerable<DisciplinaDto>> (disciplina);
        }

        public async Task<DisciplinaDto?> GetByIdAsync(int id) 
        {
            var disciplina = await _unitOfWork.Disciplina.GetByIdAsync(id);
            if (disciplina == null)
                return null;
            return _mapper.Map<DisciplinaDto>(disciplina);
        }

       
        public async Task<DisciplinaDto> AddAsync(DisciplinaDto dto)
        {
            var objeto = _mapper.Map<Disciplina>(dto);

            await _unitOfWork.Disciplina.AddAsync(objeto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DisciplinaDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, DisciplinaDto dto)
        {
            if (id != dto.Id)
                return false;

            var objeto = await _unitOfWork.Disciplina.GetByIdAsync(id);
            if (objeto == null)
                return false;

            objeto.IdEstudiante = dto.IdEstudiante;
            objeto.IdAsignacion = dto.IdAsignacion;
            objeto.Tipo = dto.Tipo;
            objeto.Descripcion = dto.Descripcion;
            objeto.Fecha = dto.Fecha;   

            _unitOfWork.Disciplina.Update(objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id) 
        {
            var disciplina = await _unitOfWork.Disciplina.GetByIdAsync(id);
            if (disciplina == null)
                return false;

            await _unitOfWork.Disciplina.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


        public async Task<ApiResponse<IEnumerable<DisciplinaDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var disciplinas = await _unitOfWork.Disciplina.GetAllAsync(filter);
            var disciplinasDto = _mapper.Map<IEnumerable<DisciplinaDto>>(disciplinas);

            return new ApiResponse<IEnumerable<DisciplinaDto>>(disciplinasDto, disciplinas.MetaData);
        }




    }

}
