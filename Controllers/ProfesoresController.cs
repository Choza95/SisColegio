using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Services;

namespace ApiProfesores.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesoresService _profesoresService;

        public ProfesoresController(IProfesoresService profesoresService)
        {
            _profesoresService = profesoresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PostQueryFilter filter)
        {
            var response = await _profesoresService.GetAllAsync(filter);
            return Ok(response);
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _profesoresService.GetAllAsync();
            return Ok(lista);
        }



        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var usuario = await _profesoresService.GetByIdAsync(id);
            if (usuario == null)
                return NotFound(new { mensaje = "Usuario no encontrado" });

            return Ok(usuario);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] ProfesoresDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _profesoresService.AddAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = creado.Id }, creado);
        }
                                                        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProfesoresDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _profesoresService.UpdateAsync(id, dto);
            if (!actualizado)
                return BadRequest(new { mensaje = "No se pudo actualizar el profesor" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _profesoresService.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Profesor no encontrado" });

            return NoContent();
        }
    }
}
