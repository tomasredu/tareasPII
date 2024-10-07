using Microsoft.AspNetCore.Mvc;
using PeluqueriaData.DTOs;
using PeluqueriaData.Models;
using PeluqueriaData.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeluqueriaApi.Controllers
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
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok((await _svc.GetServicios()).Select(s => s.ToDto()).ToList());
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{nombre}")]
        async public Task<IActionResult> Get(string nombre)
        {
            try
            {
                return Ok((await _svc.GetServiciosNombre(nombre)).Select(s => s.ToDto()).ToList());
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
           
        }

        [HttpGet("{dias}")]
        async public Task<IActionResult> Get(int dias)
        {
            try
            {
                return Ok((await _svc.GetServiciosBaja(dias)).Select(s => s.ToDto()).ToList());
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }

        }

        // POST api/<ServiciosController>
        [HttpPost]
        async public Task<IActionResult> Post([FromBody] CreateServicioDTO servicioDTO)
        {
            try
            {
                
                if(servicioDTO.IsValid())
                {
                    TServicio servicio = new TServicio()
                    {
                        Nombre = servicioDTO.Nombre,
                        Costo = servicioDTO.Costo,
                        EnPromocion = servicioDTO.EnPromocion
                    };
                    if (await _svc.Agregar(servicio))
                    {
                        return Ok();
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        async public Task<IActionResult> Put( UpdateServicioDTO servicioDTO)
        {
            try
            {
                TServicio servicio = new TServicio()
                {
                    IdServicio = servicioDTO.IdServicio,
                    Nombre = servicioDTO.Nombre,
                    Costo = servicioDTO.Costo,
                    EnPromocion = servicioDTO.EnPromocion,
                    FechaBaja = servicioDTO.FechaBaja,
                    MotivoBaja = servicioDTO.MotivoBaja
                };
                if(await _svc.Modificar(servicio))
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete()]
        async public Task<IActionResult> Delete(int id, string motivo)
        {
            try
            {
                if(!string.IsNullOrEmpty(motivo))
                {
                    if (await _svc.Cancelar(id, motivo))
                    {
                        return Ok();
                    }
                }
                return BadRequest();
                
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
