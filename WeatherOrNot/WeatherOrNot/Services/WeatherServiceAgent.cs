using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherOrNot.Models;

namespace WeatherOrNot.Services
{
    public class WeatherServiceAgent : IWeatherServiceAgent
    {
        private readonly Document _document;
        private readonly HttpClient _httpClient;
        
        public WeatherServiceAgent(Document document, HttpClient httpClient)
        {
            _document = document;
            _httpClient = httpClient;
        }

        public async Task Refresh()
        {
            foreach (var city in _document.Cities)
            {
                var response = await _httpClient.GetStringAsync(string.Format("?location={0}", city.Name));
                var records = JsonConvert.DeserializeObject<IEnumerable<ForecastRecord>>(response);
                foreach (var record in records)
                {
                    var forecast = city.NewForecast();
                    forecast.Condition = record.condition;
                    forecast.DayOfWeek = Enum.GetValues(typeof(DayOfWeek))
                        .Cast<DayOfWeek>()
                        .FirstOrDefault(d => d.ToString().StartsWith(record.day_of_week));
                    forecast.High = record.high;
                    forecast.Low = record.low;
                }
            }
        }
    }
}
