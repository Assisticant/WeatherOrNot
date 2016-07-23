using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherOrNot.Models;

namespace WeatherOrNot.ViewModels
{
    public class ForecastViewModel
    {
        private readonly Forecast _forecast;

        public ForecastViewModel(Forecast forecast)
        {
            _forecast = forecast;
        }

        public string Text
        {
            get { return String.Format("{0}: {1:0.} - {2:0.}", _forecast.DayOfWeek, _forecast.High, _forecast.Low); }
        }

        public string Description
        {
            get { return _forecast.Condition; }
        }
    }
}
