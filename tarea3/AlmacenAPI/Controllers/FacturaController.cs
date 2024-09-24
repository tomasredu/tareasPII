using Almacen.Data.Interfaces;
using Almacen.Domain;
using Almacen.Services;
using AlmacenData.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlmacenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        IAlmacenService _service = new AlmacenService();
        
        // GET: api/<FacturaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetAllFacturas());
            }
            catch (Exception e)
            {

                return StatusCode(500, e.ToString());
            }
            
        }

        // GET api/<FacturaController>/5
        [HttpGet("/filter")]
        public IActionResult Get( int? idForma, DateTime? fecha )
        {
            try
            {
                return Ok(_service.GetFacturas(idForma, fecha));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.ToString());
            }
        }

        

        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post([FromBody] Factura f)
        {
            try
            {
                _service.AddFactura(f);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.ToString());
            }
        }

        // PUT api/<FacturaController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] Factura f)
        {
            try
            {
                _service.UpdateFactura(f);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.ToString());
            }
        }

        
    }
}
