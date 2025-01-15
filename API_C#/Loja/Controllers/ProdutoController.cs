using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ServicoCrudProduto _servicoCrudProduto;

        public ProdutoController(ServicoCrudProduto servicoCrudLoja)
        {
            _servicoCrudProduto = servicoCrudLoja;
        }

        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            try
            {
                List<Produto> produtos = _servicoCrudProduto.ObterProduto();
                return Ok(produtos); // Retorna a lista de usuários no formato JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter usuários: {ex.Message}");
            }

        }

        [HttpPost]
        public ActionResult<Produto> Post([FromBody] Produto novoProduto)
        {
            try
            {
                if (novoProduto == null)
                    return BadRequest("Dados do usuário não foram fornecidos.");

                _servicoCrudProduto.AdicionarProduto(novoProduto); // Salva no banco

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar usuário: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Produto produto = _servicoCrudProduto.ObterProdutoPorId(id);
                if (produto == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }

                _servicoCrudProduto.RemoverProduto(produto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar usuário: {ex.Message}");
            }
        }
    }
}
