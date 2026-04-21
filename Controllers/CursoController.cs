using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Services;

namespace ApiCurso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _cursoService.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var curso = await _cursoService.GetByIdAsync(id);
            if (curso == null)
                return NotFound(new { mensaje = "Curso no encontrado" });

            return Ok(curso);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CursoAddDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var creado = await _cursoService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CursoAddDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _cursoService.UpdateAsync(id, dto);
            if (!actualizado)
                return BadRequest(new { mensaje = "No se pudo actualizar el Curso" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _cursoService.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Curso no encontrado" });

            return NoContent();
        }
    }
}
