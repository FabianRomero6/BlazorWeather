using WeatherApp.Model;
using WeatherApp.Services.WeatherService;

namespace WeatherApp.Pages.Forecasts;
public class ForecastsViewModel : IForecastsViewModel
{
    private IWeatherService _weatherService;

    public Forecast firstForecast { get; set; }
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
        firstForecast = forecast.Properties.Periods.Take(1).First();
        forecast.Properties.Periods = forecast.Properties.Periods.Skip(1).ToList();
    }
}
