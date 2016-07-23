using System.Threading.Tasks;
using System;

namespace WeatherOrNot.Services
{
    public interface IWeatherServiceAgent
    {
        Task Refresh();
    }
}
