using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Services;

namespace ApiEstudiantes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiantesService _estudiantesService;

        public EstudiantesController(IEstudiantesService estudiantesService)
        {
            _estudiantesService = estudiantesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _estudiantesService.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estudiantes = await _estudiantesService.GetByIdAsync(id);
            if (estudiantes == null)
                return NotFound(new { mensaje = "Estudiante no encontrado" });

            return Ok(estudiantes);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] EstudiantesDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _estudiantesService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstudiantesDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _estudiantesService.UpdateAsync(id, dto);
            if (!actualizado)
                return BadRequest(new { mensaje = "No se pudo actualizar al estudiante" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _estudiantesService.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Estudiante no encontrado" });

            return NoContent();
        }
    }
}
