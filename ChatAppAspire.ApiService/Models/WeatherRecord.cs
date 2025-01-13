using ChatAppAspire.ApiService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace ChatAppAspire.ApiService.Models
{
    public class WeatherRecord
    {
        public int Id { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}
