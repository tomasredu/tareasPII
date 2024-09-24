using Almacen.Domain;
using Almacen.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlmacenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        AlmacenService service = new AlmacenService();
        // GET: api/<ArticulosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.GetAllArticulos());
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
        }

        // GET api/<ArticulosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(service.GetArticuloById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }

        // POST api/<ArticulosController>
        [HttpPost]
        public IActionResult Post([FromBody] Articulo a)
        {
            try
            {
                service.AddArticulo(a);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
            
        }

        // PUT api/<ArticulosController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] Articulo a)
        {
            try
            {
                service.UpdateArticulo(a);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }

        // DELETE api/<ArticulosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DeleteArticulo(id);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
        }
    }
}
