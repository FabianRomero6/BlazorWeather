using WeatherApp.Model;
using WeatherApp.Services.WeatherService;

namespace WeatherApp.Pages.Forecasts;
public interface IForecastsViewModel
{
    WeatherForecast forecast { get; set; }
    Search search { get; set; }
    bool fetchError { get; set; }
    Task FetchForecast();
}
