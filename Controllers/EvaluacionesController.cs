using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Services;

namespace ApiEvaluaciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class EvaluacionesController : ControllerBase
    {
        private readonly IEvaluacionesService _evaluacionesService;

        public EvaluacionesController(IEvaluacionesService evaluacionesService)
        {
            _evaluacionesService = evaluacionesService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PostQueryFilter filter)
        {
            var response = await _evaluacionesService.GetAllAsync(filter);
            return Ok(response);
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _evaluacionesService.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evaluaciones = await _evaluacionesService.GetByIdAsync(id);
            if (evaluaciones == null)
                return NotFound(new { mensaje = "Evaluación no encontrada" });

            return Ok(evaluaciones);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] EvaluacionesDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _evaluacionesService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EvaluacionesDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _evaluacionesService.UpdateAsync(id, dto);
            if (!actualizado)
                return BadRequest(new { mensaje = "No se pudo actualizar la evaluación" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _evaluacionesService.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Evaluación no encontrada" });

            return NoContent();
        }
    }
}
