using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Services;

namespace ApiInscripciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class InscripcionesController : ControllerBase
    {
        private readonly IInscripcionesService _inscripcionesService;

        public InscripcionesController(IInscripcionesService inscripcionesService)
        {
            _inscripcionesService = inscripcionesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _inscripcionesService.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inscripciones = await _inscripcionesService.GetByIdAsync(id);
            if (inscripciones == null)
                return NotFound(new { mensaje = "Inscripción no encontrada" });

            return Ok(inscripciones);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] InscripcionesDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _inscripcionesService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] InscripcionesDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _inscripcionesService.UpdateAsync(id, dto);
            if (!actualizado)
                return BadRequest(new { mensaje = "No se pudo actualizar la inscripción" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _inscripcionesService.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Inscripción no encontrada" });

            return NoContent();
        }
    }
}
