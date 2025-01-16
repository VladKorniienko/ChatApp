using System.Net.Http;

namespace ChatAppAspire.Web;

public class WeatherApiClient(HttpClient httpClient)
{
    public async Task<WeatherForecast[]> GetWeatherAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<WeatherForecast>? forecasts = null;

        await foreach (var forecast in httpClient.GetFromJsonAsAsyncEnumerable<WeatherForecast>("/api/weather", cancellationToken))
        {
            if (forecasts?.Count >= maxItems)
            {
                break;
            }
            if (forecast is not null)
            {
                forecasts ??= [];
                forecasts.Add(forecast);
            }
        }

        return forecasts?.ToArray() ?? [];
    }
    public async Task<bool> AddWeatherRecordAsync(WeatherForecast newRecord, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/api/weather", newRecord, cancellationToken);
        return response.IsSuccessStatusCode;
    }
}

public record WeatherForecast(int id, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
