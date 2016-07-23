using Assisticant.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherOrNot.Models;
using WeatherOrNot.Services;

namespace WeatherOrNot.ViewModels
{
    public class CityViewModel
    {
        private readonly City _city;
		private readonly ForecastRepository _forecastRepository;

        private Observable<Exception> _lastError = new Observable<Exception>();
        
		public CityViewModel(City city, ForecastRepository forecastRepository)
        {
            _city = city;
            _forecastRepository = forecastRepository;
        }

        public string Name
        {
            get { return _city.Name; }
        }

        public IEnumerable<ForecastViewModel> Forecasts
        {
            get
            {
                return
                    from forecast in _city.Forecasts
                    select new ForecastViewModel(forecast);
            }
        }

        public async void Refresh()
        {
            try
            {
                _lastError.Value = null;
                await _forecastRepository.Refresh(_city);
            }
            catch (Exception ex)
            {
                _lastError.Value = ex;
            }
        }
    }
}
