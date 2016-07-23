using System;
using Assisticant.Fields;
using Assisticant.Collections;
using System.Collections.Generic;
using WeatherOrNot.Services;
using System.Linq;

namespace WeatherOrNot.Models
{
	public class City
	{
		private Observable<string> _name = new Observable<string>();
		private ObservableList<Forecast> _forecasts = new ObservableList<Forecast>();

		public string Name
		{
			get { return _name.Value; }
			set { _name.Value = value; }
		}

		public IEnumerable<Forecast> Forecasts
		{
			get { return _forecasts; }
		}

		public Forecast NewForecast()
		{
			var forecast = new Forecast();
			_forecasts.Add(forecast);
			return forecast;
		}

		public void ClearForecasts()
		{
			_forecasts.Clear();
		}

        public void LoadForecasts(IEnumerable<ForecastMemento> forecasts)
        {
            _forecasts.Clear();
            foreach (var forecast in forecasts)
            {
                _forecasts.Add(new Forecast
                {
                    DayOfWeek = forecast.DayOfWeek,
                    Condition = forecast.Condition,
                    High = forecast.High,
                    Low = forecast.Low
                });
            }
        }

        public List<ForecastMemento> SaveForecasts()
        {
            return _forecasts.Select(f =>
                new ForecastMemento
                {
                    DayOfWeek = f.DayOfWeek,
                    Condition = f.Condition,
                    High = (int)f.High,
                    Low = (int)f.Low
                })
                .ToList();
        }
	}
}

