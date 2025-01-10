using ScreenSound.Web.Response;
using System.Net.Http;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services;

public class ArtistaAPI
{
    private readonly HttpClient _httpClient;

    public ArtistaAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
    {
        try
        {
            Console.WriteLine("Iniciando chamada à API para obter artistas...");
            var response = await _httpClient.GetAsync("artistas");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Chamada à API bem-sucedida.");
                return await response.Content.ReadFromJsonAsync<ICollection<ArtistaResponse>>();
            }
            else
            {
                Console.WriteLine($"Erro na resposta da API: {response.StatusCode}");
                return null;
            }
        }
        catch (HttpRequestException ex)
        {
            // Log ou tratamento de erro
            Console.WriteLine($"Erro ao chamar a API: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            // Captura qualquer outra exceção
            Console.WriteLine($"Erro inesperado: {ex.Message}");
            return null;
        }
    }
}
