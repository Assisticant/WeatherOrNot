using System;
using System.Runtime.Serialization;

namespace WeatherOrNot.Services
{
	[DataContract]
	public class ForecastMemento
	{
        [DataMember]
        public DayOfWeek DayOfWeek { get; set; }
		[DataMember]
		public int High { get; set; }
		[DataMember]
		public int Low { get; set; }
		[DataMember]
		public string Condition { get; set; }
	}
}

