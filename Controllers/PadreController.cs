using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Services;

namespace ApiPadre.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PadreController : ControllerBase
    {
        private readonly IPadreService _padreService;

        public PadreController(IPadreService padreService)
        {
            _padreService = padreService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PostQueryFilter filter)
        {
            var response = await _padreService.GetAllAsync(filter);
            return Ok(response);
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _padreService.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var padre = await _padreService.GetByIdAsync(id);
            if (padre == null)
                return NotFound(new { mensaje = "Padre no encontrado" });

            return Ok(padre);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] PadreDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _padreService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] PadreDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _padreService.UpdateAsync(id, dto);
            if (!actualizado)
                return BadRequest(new { mensaje = "No se pudo actualizar el padre" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _padreService.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Padre no encontrado" });

            return NoContent();
        }
    }
}
