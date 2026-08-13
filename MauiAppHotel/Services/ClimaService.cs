using System.Text.Json;

namespace MauiAppHotel.Services;

public class ClimaService
{
    private readonly HttpClient _httpClient;

    public ClimaService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> ObterClimaAsync()
    {
        string url =
            "https://api.open-meteo.com/v1/forecast" +
            "?latitude=-22.2965" +
            "&longitude=-48.5578" +
            "&current=temperature_2m,wind_speed_10m";

        try
        {
            var resposta = await _httpClient.GetAsync(url);

            resposta.EnsureSuccessStatusCode();

            string json = await resposta.Content.ReadAsStringAsync();

            using JsonDocument documento = JsonDocument.Parse(json);

            var current = documento.RootElement.GetProperty("current");

            double temperatura =
                current.GetProperty("temperature_2m").GetDouble();

            double vento =
                current.GetProperty("wind_speed_10m").GetDouble();

            return $"Temperatura: {temperatura} °C\n" +
                   $"Vento: {vento} km/h";
        }
        catch (Exception ex)
        {
            return $"Erro ao consultar API: {ex.Message}";
        }
    }
}