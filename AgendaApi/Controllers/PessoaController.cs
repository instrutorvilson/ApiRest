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
                return Ok(_service.Save(pessoa));
            }
            catch (Exception ex) { 
               return BadRequest(ex.Message);
            }
            
        }

        /* [HttpGet]
         public IActionResult Get()
         {
             return Ok(_repo.GetAll());
         }

         [HttpGet("/{id}")]
         public IActionResult Get(int id)
         {
             return Ok(_repo.Get(id));
         }



         [HttpPut("/{id}")]
         public IActionResult Put(int id, [FromBody] Pessoa pessoa)
         {
             var pessoaExiste = _repo.Get(id);
             if (pessoaExiste == null) {
                 return StatusCode(404, "Pessoa não encontrada");
             }
             _repo.Update(pessoa);
             return StatusCode(200, "Pessoa alterada com sucesso");
         }

         [HttpDelete("/{id}")]
         public IActionResult Delete(int id)
         {
             var pessoaExiste = _repo.Get(id);
             if (pessoaExiste == null)
             {
                 return StatusCode(404, "Pessoa não encontrada");
             }
             _repo.Delete(id);
             return StatusCode(200, "Pessoa alterada com sucesso");
         }*/
    }
}
