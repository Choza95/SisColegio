using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SisColegio.Data;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;
using SisColegio.Repositories;
using System.Collections;

namespace SisColegio.Services
{
    public class AsignacioneService : IAsignacioneService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public readonly IPasswordHasher _passwordHasher;
  


        public AsignacioneService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<IEnumerable<AsignacioneDto>> GetAllAsync()
        {
            var asignacione = await _unitOfWork.Asignacione.GetAllAsync();
            return _mapper.Map<IEnumerable<AsignacioneDto>>(asignacione);
        }

        public async Task<AsignacioneDto?> GetByIdAsync(int id)
        {
            var asignacione = await _unitOfWork.Asignacione.GetByIdAsync(id);
            if (asignacione == null)
                return null;
            return _mapper.Map<AsignacioneDto>(asignacione);
        }


        public  IEnumerable<AsignacioneDto?> GetAsignacionByProfesor(int idProfesor)
        {
            var asignaciones =  _unitOfWork.Asignacione.GetAsignacionByProfesor(idProfesor);

            if (asignaciones == null)
                return null;
            return _mapper.Map< IEnumerable< AsignacioneDto> >(asignaciones);
        }





        public async Task<AsignacioneDto> AddAsync(AsignacioneAddDto dto)
        {
            var objeto = _mapper.Map<Asignacione>(dto);

            await _unitOfWork.Asignacione.AddAsync(objeto);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AsignacioneDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, AsignacioneAddDto dto)
        {
            

            var objeto = await _unitOfWork.Asignacione.GetByIdAsync(id);
            if (objeto == null)
                return false;

            objeto.IdProfesor = dto.IdProfesor;
            objeto.IdMateria = dto.IdMateria;
            objeto.IdCurso = dto.IdCurso;

            _unitOfWork.Asignacione.Update(objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var asignacione = await _unitOfWork.Asignacione.GetByIdAsync(id);
            if (asignacione == null)
                return false;

            await _unitOfWork.Asignacione.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


        public async Task<ApiResponse<IEnumerable<AsignacioneDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var asignaciones = await _unitOfWork.Asignacione.GetAllAsync(filter);
            var asignacionesDto = _mapper.Map<IEnumerable<AsignacioneDto>>(asignaciones);

            return new ApiResponse<IEnumerable<AsignacioneDto>>(asignacionesDto, asignaciones.MetaData);
        }

      
    }

}
