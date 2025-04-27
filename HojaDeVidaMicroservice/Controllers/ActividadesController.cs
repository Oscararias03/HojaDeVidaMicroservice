using Microsoft.AspNetCore.Mvc;
using HojaDeVidaMicroservice.Services;
using HojaDeVidaMicroservice.Models;

namespace HojaDeVidaMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly IActividadService _service;

        public ActividadesController(IActividadService service)
        {
            _service = service;
        }

        [HttpGet("{estudianteId}")]
        public async Task<ActionResult<List<Actividad>>> GetByEstudianteId(string estudianteId)
        {
            try
            {
                var actividades = await _service.GetByEstudianteIdAsync(estudianteId);
                return Ok(actividades);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Actividad>> Create([FromBody] Actividad actividad)
        {
            try
            {
                var nuevaActividad = await _service.CreateAsync(actividad);
                return CreatedAtAction(nameof(GetByEstudianteId), new { estudianteId = actividad.EstudianteId }, nuevaActividad);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
