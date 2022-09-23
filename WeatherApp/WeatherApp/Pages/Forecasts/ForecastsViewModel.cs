using WeatherApp.Model;
using WeatherApp.Services.WeatherService;

namespace WeatherApp.Pages.Forecasts;
public class ForecastsViewModel : IForecastsViewModel
{
    private IWeatherService _weatherService;

    public Forecast firstForecast { get; set; }
    public WeatherForecast? forecast { get; set; }
    public Search search { get; set; } = new();
    public IEnumerable<Zones> zones { get; set; }
    public Zones zone { get; set; }
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
        zone = zones.FirstOrDefault(z => z.Properties.Id == search.Criteria);
    }

    public async Task FetchZones()
    {
        ZoneCollection response = await _weatherService.GetZones();
        zones = response.Features;
    }
}
