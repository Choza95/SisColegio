using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisColegio.Dtos;
using SisColegio.Interfaces;

namespace ApiNota.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class NotaController : ControllerBase
    {
        private readonly INotaService _notaService;

        public NotaController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _notaService.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nota = await _notaService.GetByIdAsync(id);
            if (nota == null)
                return NotFound(new { mensaje = "Nota no encontrada" });

            return Ok(nota);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] NotaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _notaService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] NotaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _notaService.UpdateAsync(id, dto);
            if (!actualizado)
                return BadRequest(new { mensaje = "No se pudo actualizar la nota" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _notaService.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Nota no encontrada" });

            return NoContent();
        }
    }
}
