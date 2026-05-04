using AutoMapper;
using SisColegio.Dtos;
using SisColegio.Models;

namespace SisColegio.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<UsuarioCreateDto, Usuario>().ReverseMap();
            CreateMap<UsuarioUpdateDto, Usuario>().ReverseMap();
            CreateMap<Profesores, ProfesoresDto>().ReverseMap();
            CreateMap<Trimestre, TrimestreDto>().ReverseMap();  
            CreateMap<Padre, PadreDto>().ReverseMap();
            CreateMap<Materia, MateriaDto>().ReverseMap();
            CreateMap<Inscripcione, InscripcionesDto>().ReverseMap();
            CreateMap<Evaluacione, EvaluacionesDto>().ReverseMap();
            CreateMap<Estudiante, EstudiantesDto>().ReverseMap();
            CreateMap<Disciplina, DisciplinaDto>().ReverseMap();
            CreateMap<Curso, CursoDto>().ReverseMap();
            CreateMap<Curso, CursoAddDto>().ReverseMap();
            CreateMap<Asignacione, AsignacioneDto>().ReverseMap();

            CreateMap<Asignacione, AsignacioneDto>()
                .ForMember(dest => dest.NombreCurso,
                    opt => opt.MapFrom(src => src.IdCursoNavigation != null
                        ? src.IdCursoNavigation.Nombre
                        : null))
                .ForMember(dest => dest.NombreMateria,
                    opt => opt.MapFrom(src => src.IdMateriaNavigation != null
                        ? src.IdMateriaNavigation.Nombre
                        : null));



            CreateMap<Nota,  NotaDto>().ReverseMap();
            CreateMap<Inscripcione, InscripcionesCursoDto>()
              .ForMember(dest => dest.NombreEstudiante,
                  opt => opt.MapFrom(src => src.IdEstudianteNavigation != null
                      ? src.IdEstudianteNavigation.Nombre + " " + src.IdEstudianteNavigation.Apellido
                      : null))
              .ForMember(dest => dest.Ci,
                  opt => opt.MapFrom(src => src.IdEstudianteNavigation != null
                      ? src.IdEstudianteNavigation.Ci
                      : null))
              .ForMember(dest => dest.Edad,
                  opt => opt.MapFrom(src => src.IdEstudianteNavigation != null
                      ? src.IdEstudianteNavigation.Edad.ToString()
                      : null))
              .ReverseMap();


            CreateMap<Inscripcione, InscripcionesCursoDto>()
                .ForMember(dest => dest.NombreEstudiante,
                    opt => opt.MapFrom(src => src.IdEstudianteNavigation!.Nombre))
                .ForMember(dest => dest.Ci,
                    opt => opt.MapFrom(src => src.IdEstudianteNavigation!.Ci))
                .ForMember(dest => dest.Edad,
                    opt => opt.MapFrom(src => src.IdEstudianteNavigation!.Edad.ToString()))
                .ReverseMap();


            CreateMap<Asignacione, AsignacioneAddDto>().ReverseMap();
        }
    }
}

