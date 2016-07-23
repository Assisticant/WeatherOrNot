using System;
using System.Runtime.Serialization;

namespace WeatherOrNot.Services
{
	[DataContract]
	public class CityMemento
	{
		[DataMember]
		public string Name { get; set; }
	}
}

