using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace WeatherOrNot.Services
{
	[DataContract]
	public class DocumentMemento
	{
		[DataMember]
		public List<CityMemento> Cities { get; set; }
	}
}

