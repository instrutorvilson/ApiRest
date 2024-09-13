using AgendaApi.Models;
using AgendaApi.Repository;
using AgendaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [ApiController]
    [Route("api/v1/pessoas")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _service;
        public PessoaController(PessoaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            try
            {
                //return Ok(_service.Save(pessoa));
                return StatusCode(201,_service.Save(pessoa));
            }
            catch (Exception ex) { 
               return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
         public IActionResult Get()
         {
             return Ok(_service.GetAll());
         }

        [HttpDelete("/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return StatusCode(200, _service.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/{id}")]
        public IActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            try
            {
                _service.Update(pessoa);
                return StatusCode(200, "Pessoa alterada com sucesso" );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
