using ApiRest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Produto A", Preco = 10.00M, Quantidade = 100 },
            new Produto { Id = 2, Nome = "Produto B", Preco = 20.00M, Quantidade = 200 }
        };

        // GET: api/produtos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(produtos);
        }

        // GET: api/produtos/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // POST: api/produtos
        [HttpPost]
        public IActionResult Post([FromBody] Produto novoProduto)
        {
            if (novoProduto == null)
                return BadRequest();

            // Gerar um novo ID
            novoProduto.Id = produtos.Max(p => p.Id) + 1;
            produtos.Add(novoProduto);

            return CreatedAtAction(nameof(Get), new { id = novoProduto.Id }, novoProduto);
        }

        // PUT: api/produtos/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produtoAtualizado)
        {
            if (produtoAtualizado == null || produtoAtualizado.Id != id)
                return BadRequest();

            var produtoExistente = produtos.FirstOrDefault(p => p.Id == id);
            if (produtoExistente == null)
                return NotFound();

            produtoExistente.Nome = produtoAtualizado.Nome;
            produtoExistente.Preco = produtoAtualizado.Preco;
            produtoExistente.Quantidade = produtoAtualizado.Quantidade;

            return NoContent();
        }

        // DELETE: api/produtos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();

            produtos.Remove(produto);
            return NoContent();
        }
    }
}

