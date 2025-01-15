using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ServicoCrudUsuario _servicoCrudUsuario;

        public UsuarioController(ServicoCrudUsuario servicoCrudLoja)
        {
            _servicoCrudUsuario = servicoCrudLoja;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            try
            {
                List<Usuario> usuarios = _servicoCrudUsuario.ObterUsuario();
                return Ok(usuarios); // Retorna a lista de usuários no formato JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter usuários: {ex.Message}");
            }

        }

        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario novoUsuario)
        {
            try
            {
                if (novoUsuario == null)
                    return BadRequest("Dados do usuário não foram fornecidos.");

                _servicoCrudUsuario.AdicionarUsuario(novoUsuario); // Salva no banco

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
                Usuario usuario = _servicoCrudUsuario.ObterUsuarioPorId(id);
                if (usuario == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }

                _servicoCrudUsuario.RemoverUsuario(usuario);

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar usuário: {ex.Message}");
            }
        }
    }
}
