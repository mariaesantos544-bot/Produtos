
using Microsoft.AspNetCore.Mvc;
using Produtos.Interfaces;
using Produtos.Models;
using Produtos.Repositories;

namespace Produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProduto _produto;

        public ProdutosController(IProduto produto)
        {
            _produto = produto;
        }

        // Cadastrar produto
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] Produto produto)
        {
            try
            {
                await _produto.Cadastrar(produto);

                return StatusCode(201, produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(
            int id,
            [FromBody] Produto produto)
        {
            try
            {
                var produtoBuscado = await _produto.BuscarPorId(id);

                if (produtoBuscado == null)
                {
                    return NotFound("Produto não encontrado.");
                }

                await _produto.Atualizar(id, produto);

                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var produtoBuscado = await _produto.BuscarPorId(id);

            if (produtoBuscado == null)
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok(produtoBuscado);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var produtos = await _produto.ListarTodos();

                return Ok(produtos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var produtoBuscado = await _produto.BuscarPorId(id);

            if (produtoBuscado == null)
            {
                return NotFound("Produto não encontrado.");
            }

            await _produto.Deletar(id);

            return NoContent();
        }
    }
}