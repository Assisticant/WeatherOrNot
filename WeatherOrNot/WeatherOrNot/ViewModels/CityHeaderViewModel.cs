using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherOrNot.Models;

namespace WeatherOrNot.ViewModels
{
	public class CityHeaderViewModel
	{
        private readonly City _city;

        public CityHeaderViewModel(City city)
        {
            _city = city;
        }

        public City City
        {
            get
            {
                return _city;
            }
        }

        public string Name
        {
            get
            {
                return _city.Name;
            }
        }
	}

}
