using Microsoft.AspNetCore.Mvc;
using PeluqueriaData.DTOs;
using PeluqueriaData.Models;
using PeluqueriaData.Repositories;
using PeluqueriaData.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeluqueriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnoService _svc;
        public TurnosController(ITurnoService svc)
        {
            _svc = svc;
        }
        // GET: api/<TurnosController>
        [HttpGet]
        async public Task<IActionResult> Get()
        {
            try
            {
                List<TurnoDTO> lst = (await _svc.RecuperarTurnos()).Select(t => t.ToDto()).ToList();
                return Ok(lst);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpGet("cliente/{nombre}")]
        async public Task<IActionResult> Get(string nombre)
        {
            try
            {
                List<TurnoDTO> lst = (await _svc.RecuperarTurnosPorCliente(nombre)).Select(t => t.ToDto()).ToList();
                return Ok(lst);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpGet("fecha")]
        async public Task<IActionResult> Get([FromQuery] DateTime fecha)
        {
            try
            {
                List<TurnoDTO> lst = (await _svc.RecuperarTurnosPorFecha(fecha)).Select(t => t.ToDto()).ToList();
                return Ok(lst);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }



        // POST api/<TurnosController>
        [HttpPost]
        async public Task<IActionResult> Post([FromBody] CreateTurnoDTO turnoDto)
        {
            try
            {
                if (turnoDto.IsValid())
                {
                    
                    TTurno turno = new TTurno()
                    {
                        Fecha = turnoDto.Fecha,
                        Cliente = turnoDto.Cliente


                    };
                    foreach (CreateDetalleTurnoDTO det in turnoDto.Detalles)
                    {
                        TDetalleTurno detalle = new TDetalleTurno()
                        {
                            IdServicio = det.IdServicio,
                            Observaciones = det.Observaciones
                        };
                        turno.TDetallesTurnos.Add(detalle);
                    }
                    if (await _svc.AgregarTurno(turno))
                    {
                        return Ok();
                    }
                    else return BadRequest("Ya hay un turno ese dia a esa hora.");
                }
                else return BadRequest("El turno no es valido.");
                
                
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpPut]
        async public Task<IActionResult> Put([FromBody] UpdateTurnoDTO turnoDto)
        {
            try
            {
                if (turnoDto.IsValid())
                {
                    TTurno turno = new TTurno()
                    {
                        IdTurno = turnoDto.IdTurno,
                        Fecha = turnoDto.Fecha,
                        Cliente = turnoDto.Cliente,
                        FechaBaja = turnoDto.FechaBaja,
                        MotivoBaja = turnoDto.MotivoBaja

                    };
                    foreach (UpdateDetalleTurnoDTO det in turnoDto.Detalles)
                    {
                        TDetalleTurno detalle = new TDetalleTurno()
                        {
                            IdTurno = turno.IdTurno,
                            IdServicio = det.IdServicio,
                            Observaciones = det.Observaciones
                        };
                        turno.TDetallesTurnos.Add(detalle);
                    }
                    if (await _svc.EditarTurno(turno))
                    {
                        return Ok();
                    }
                    else return BadRequest("Ya hay un turno ese dia a esa hora.");
                }
                else return BadRequest("El turno no es valido.");
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }

        }
        [HttpDelete]
        async public Task<IActionResult> Delete([FromQuery] int id, [FromQuery] string motivo)
        {
            try
            {
                if (await _svc.CancelarTurno(id, motivo))
                {
                    return Ok();
                }
                else return BadRequest();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        
    }
}
