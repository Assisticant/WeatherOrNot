using System;
using Assisticant.Fields;

namespace WeatherOrNot.Models
{
    public class CitySelection
    {
        private Observable<City> _selectedCity = new Observable<City>();
        private Observable<string> _cityName = new Observable<string>();

        public City SelectedCity
        {
            get
            {
                return _selectedCity.Value;
            }
            set
            {
                _selectedCity.Value = value;
            }
        }

        public string CityName
        {
            get
            {
                return _cityName.Value;
            }
            set
            {
                _cityName.Value = value;
            }
        }
    }
}

