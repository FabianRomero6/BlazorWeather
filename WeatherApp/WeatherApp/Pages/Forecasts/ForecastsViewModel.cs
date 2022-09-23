using WeatherApp.Model;
using WeatherApp.Services.WeatherService;

namespace WeatherApp.Pages.Forecasts;
public class ForecastsViewModel : IForecastsViewModel
{
    private IWeatherService _weatherService;

    public WeatherForecast? forecast { get; set; }
    public Search search { get; set; } = new();
    public bool fetchError { get; set; } = false;

    public ForecastsViewModel(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task FetchForecast()
    {
        fetchError = false;
        forecast = await _weatherService.GetWeatherForecast(search.Criteria);
    }
}
