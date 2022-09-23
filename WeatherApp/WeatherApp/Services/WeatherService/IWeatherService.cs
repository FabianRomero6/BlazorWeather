using System.Net.Http.Json;
using WeatherApp.Model;

namespace WeatherApp.Services.WeatherService;
public interface IWeatherService
{
    Task<WeatherForecast> GetWeatherForecast(string criteria);
}
