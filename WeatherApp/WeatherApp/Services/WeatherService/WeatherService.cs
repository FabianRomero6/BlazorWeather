using System.Net.Http.Json;
using WeatherApp.Model;

namespace WeatherApp.Services.WeatherService;
public class WeatherService : IWeatherService
{
    private readonly HttpClient _http;

	public WeatherService(HttpClient http)
	{
		_http = http;
	}

	public async Task<WeatherForecast> GetWeatherForecast(string criteria)
	{
		return await _http.GetFromJsonAsync<WeatherForecast>($"https://api.weather.gov/zones/public/{criteria}/forecast");
    }
}
