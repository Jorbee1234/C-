using Domain.Entity;
using Infraestrutura.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {

        private readonly ServicoAPIPokemon _servicoPokemon;

        public PokemonController(ServicoAPIPokemon servicoCrudLoja)
        {
            _servicoPokemon = servicoCrudLoja;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            try
            {
                string produtos = await _servicoPokemon.GetPokemon();
                return Ok(produtos); // Retorna a lista de usuários no formato JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter usuários: {ex.Message}");
            }

        }
    }
}
