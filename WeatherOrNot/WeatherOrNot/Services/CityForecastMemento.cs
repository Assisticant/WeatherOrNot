using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace WeatherOrNot.Services
{
	[DataContract]
	public class CityForecastMemento
	{
		[DataMember]
		public List<ForecastMemento> Forecasts { get; set; }
	}
}

