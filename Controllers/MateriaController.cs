using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisColegio.Dtos;
using SisColegio.Interfaces;

namespace ApiMateria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _materiaService;

        public MateriaController(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _materiaService.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var materia = await _materiaService.GetByIdAsync(id);
            if (materia == null)
                return NotFound(new { mensaje = "Materia no encontrada" });

            return Ok(materia);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] MateriaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _materiaService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] MateriaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _materiaService.UpdateAsync(id, dto);
            if (!actualizado)
                return BadRequest(new { mensaje = "No se pudo actualizar la materia" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _materiaService.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Materia no encontrada" });

            return NoContent();
        }
    }
}
