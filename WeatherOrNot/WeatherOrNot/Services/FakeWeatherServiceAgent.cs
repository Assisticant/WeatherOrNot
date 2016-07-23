using System;
using System.Threading.Tasks;
using WeatherOrNot.Models;

namespace WeatherOrNot.Services
{
    public class FakeWeatherServiceAgent : IWeatherServiceAgent
    {
        private Random _random = new Random();

        private readonly Document _document;

        public FakeWeatherServiceAgent(Document document)
        {
            _document = document;
        }

        private string[] Conditions =
        {
            "Mostly sunny",
            "Partly cloudy",
            "Chance of showers",
            "Rain",
            "Severe thunderstorms",
            "Texas"
        };

        public async Task Refresh()
        {
            await Task.Delay(2000);

            foreach (var city in _document.Cities)
            {
                city.ClearForecasts();
                for (int day = 0; day < 7; day++)
                {
                    var forecast = city.NewForecast();
                    forecast.Condition = Conditions[_random.Next(Conditions.Length)];
                    forecast.DayOfWeek = (DayOfWeek)(((int)DateTime.Today.DayOfWeek + day) % 7);
                    int first = _random.Next(40) + 60;
                    int second = _random.Next(40) + 60;
                    forecast.High = Math.Max(first, second);
                    forecast.Low = Math.Min(first, second);
                }
            }
        }
    }
}
