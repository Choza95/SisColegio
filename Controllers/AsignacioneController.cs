using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisColegio.Dtos;
using SisColegio.Interfaces;
using SisColegio.Models;
using SisColegio.Services;

namespace ApiAsignacione.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AsignacioneController : ControllerBase
    {
        private readonly IAsignacioneService _asignacioneService;

        public AsignacioneController(IAsignacioneService asignacioneService)
        {
            _asignacioneService = asignacioneService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PostQueryFilter filter)
        {
            var response = await _asignacioneService.GetAllAsync(filter);
            return Ok(response);
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _asignacioneService.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var asignacione = await _asignacioneService.GetByIdAsync(id);
            if (asignacione == null)
                return NotFound(new { mensaje = "Asignación no encontrada" });

            return Ok(asignacione);
        }


        [HttpGet("ObtenerPorProfesor")] 
        public async Task<IActionResult> GetByProfesores(int id)
        {
            var asignacione = await _asignacioneService.GetByIdAsync(id);
            if (asignacione == null)
                return NotFound(new { mensaje = "Asignación no encontrada" });

            return Ok(asignacione);
        }


        [HttpGet("AsignacionesProfesor/{idProfesor:int}")]
        public IActionResult GetAsignacionesByProfesor(int idProfesor)
        {
            var lista = _asignacioneService.GetAsignacionByProfesor(idProfesor);
            return Ok(lista);
        }




        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] AsignacioneAddDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _asignacioneService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AsignacioneAddDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _asignacioneService.UpdateAsync(id, dto);
            if (!actualizado)
                return BadRequest(new { mensaje = "No se pudo actualizar la Asignación" });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _asignacioneService.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Asignación no encontrada" });

            return NoContent();
        }
    }
}