using Data.Domain;
using Data.Services;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiciosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServicioService _svc;

        public ServiciosController( IServicioService svc)
        {
            _svc = svc;
        }

        // GET: api/<ServiciosController>
        [HttpGet]
        async public Task<IActionResult> Get()
        {
            try
            {
                return Ok( await _svc.GetServicios());
            }
            catch (Exception e)
            {

                return StatusCode(500, "Error interno");
            }
            
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        async public Task<IActionResult> Get(int id)
        {
            try
            {
                var aux = await _svc.GetServicio(id);
                if ( aux != null) return Ok(aux);
                else return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        // POST api/<ServiciosController>
        [HttpPost]
        async public Task<IActionResult> Post([FromBody] Servicio servicio)
        {
            try
            {
                if (ValidarServicio(servicio))
                {
                    if ( (await _svc.Agregar(servicio)) == true) return Ok();
                    else return NotFound();
                }
                else return BadRequest();
                
                
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        // PUT api/<ServiciosController>/5
        [HttpPut]
        async public Task<IActionResult> Put([FromBody] Servicio servicio)
        {
            try
            {
                if (ValidarServicio(servicio))
                {
                    if ( (await _svc.Modificar(servicio)) == true) return Ok();
                    else return NotFound();
                }
                else return BadRequest();
                

            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete]
        async public Task<IActionResult> Delete( [FromQuery] string motivo, [FromQuery] int id)
        {
            try
            {
                if(ValidarBaja(motivo))
                {
                    if ( (await _svc.Cancelar(id, motivo)) == true) return Ok();
                    else return NotFound();
                }
                return BadRequest();
                

            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("costo/{costo}")]
        async public Task<IActionResult> GetByCosto(int costo)
        {
            try
            {
                return Ok(await _svc.GetServiciosCosto(costo));
            }
            catch (Exception e)
            {

                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("nombre/{nombre}")]
        async public Task<IActionResult> GetByCosto(string nombre)
        {
            try
            {
                return Ok(await _svc.GetServiciosNombre(nombre));
            }
            catch (Exception e)
            {

                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("baja/{dias}")]
        async public Task<IActionResult> GetByBaja(int dias)
        {
            try
            {
                return Ok(await _svc.GetServiciosBaja(dias));
            }
            catch (Exception e)
            {

                return StatusCode(500, "Error interno");
            }
        }

        private bool ValidarServicio(Servicio servicio)
        {
            bool aux = servicio.Id >= 0 && !string.IsNullOrEmpty(servicio.Nombre) && servicio.Costo > 0;
            return aux;
        }
        private bool ValidarBaja(string motivo)
        {
            return !string.IsNullOrEmpty(motivo);
        }
    }
}
