using ApiMatutino.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMatutino.Controllers
{
    [ApiController]
    [Route("api/v1/pessoas")]
    public class PessoaController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>()
        {
           new Pessoa(){Id=1, Nome="maria", Email="maria@gmail.com", Fone="(47)9090-7080"},
           new Pessoa(){Id=2, Nome="João", Email="joao@gmail.com", Fone="(47)9090-7080"}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(pessoas);
        }

        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            var pessoaExistente = pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoaExistente != null)
            {
                return Ok(pessoaExistente);
            }
            return NotFound();
        }

        [HttpDelete("/{id}")]
        public IActionResult Delete(int id)
        {
            var pessoaExistente = pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoaExistente != null)
            {
                try
                {
                    pessoas.Remove(pessoaExistente);
                    return NoContent();
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }                    
            }
            return NotFound();
        }

        [HttpPut("/{id}")]
        public IActionResult Update(int id, [FromBody] Pessoa pessoa)
        {
            var pessoaExistente = pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoaExistente != null)
            {
                pessoaExistente.Nome = pessoa.Nome;
                pessoaExistente.Email = pessoa.Email;
                pessoaExistente.Fone = pessoa.Fone;
                
                return Ok(pessoaExistente);
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            pessoa.Id = pessoas.Count + 1;
            pessoas.Add(pessoa);
            return StatusCode(201, pessoa);
        }
        /*
           controller -> recebe as requisições

           service -> recebe a requisição do controller e processa regras de negocio

           repositorio -> acesso a persistencia
         
         */
    }
}
