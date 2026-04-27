using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Services;

namespace ApiTrimestre.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class TrimestreController : ControllerBase
    {
        private readonly ITrimestreService _trimestreService;

        public TrimestreController(ITrimestreService trimestreService)
        {
            _trimestreService = trimestreService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PostQueryFilter filter)
        {
            var response = await _trimestreService.GetAllAsync(filter);
            return Ok(response);
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _trimestreService.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trimestre = await _trimestreService.GetByIdAsync(id);
            if (trimestre == null)
                return NotFound(new { mensaje = "Trimestre no encontrado" });

            return Ok(trimestre);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] TrimestreDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var objeto = await _trimestreService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = objeto.Id }, objeto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TrimestreDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _trimestreService.UpdateAsync(id, dto);
            if (!actualizado)
                return BadRequest(new { mensaje = "No se pudo actualizar el trimestre" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _trimestreService.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Trimestre no encontrado" });

            return NoContent();
        }
    }
}
