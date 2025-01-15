using Domain.Entity;
using Infraestrutura.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ServicoCrudCategoria _servicoCrudCategoria;

        public CategoriaController(ServicoCrudCategoria servicoCrudLoja)
        {
            _servicoCrudCategoria = servicoCrudLoja;
        }

        [HttpGet]
        public ActionResult<List<Categoria>> Get()
        {
            try
            {
                List<Categoria> categorias = _servicoCrudCategoria.ObterCategoria();
                return Ok(categorias); // Retorna a lista de categoria no formato JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter categoria: {ex.Message}");
            }

        }

        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] Categoria novoCategoria)
        {
            try
            {
                if (novoCategoria == null)
                    return BadRequest("Dados do categoria não foram fornecidos.");

                _servicoCrudCategoria.AdicionarCategoria(novoCategoria); // Salva no banco

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar categoria: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Categoria categoria = _servicoCrudCategoria.ObterCategoriaPorId(id);
                if (categoria == null)
                {
                    return NotFound($"Categoria com ID {id} não encontrado.");
                }

                _servicoCrudCategoria.RemoverCategoria(categoria);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar categoria: {ex.Message}");
            }
        }
    }
}
