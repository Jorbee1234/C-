using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Servico
{
    public class ServicoAPIPokemon
    {
        public async Task<String> GetPokemon()
        {
            string apiUrl = "https://pokeapi.co/api/v2/pokemon/?limit=100"; // Modificando o limite para 100


            // Criação de uma instância do HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Realiza a requisição GET para o endpoint da API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode(); // Lança uma exceção se o código de status não for 2xx

                    // Lê a resposta como uma string
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    return jsonResponse;
                }
                catch (HttpRequestException e)
                {
                    return (String)e.Message;
                }
            }
        }
    }
}
