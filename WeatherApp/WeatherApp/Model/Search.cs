using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Model;
public class Search
{
    [Required]
    public string? Criteria { get; set; }
}
