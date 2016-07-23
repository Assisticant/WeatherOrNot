using System;
using Assisticant.Fields;

namespace WeatherOrNot.Models
{
	public class Forecast
	{
		private Observable<DayOfWeek> _dayOfWeek = new Observable<DayOfWeek>();
		private Observable<decimal> _low = new Observable<decimal>();
		private Observable<decimal> _high = new Observable<decimal>();
		private Observable<string> _condition = new Observable<string>();

		public DayOfWeek DayOfWeek
		{
			get { return _dayOfWeek.Value; }
			set { _dayOfWeek.Value = value; }
		}

		public decimal Low
		{
			get { return _low.Value; }
			set { _low.Value = value; }
		}

		public decimal High
		{
			get { return _high.Value; }
			set { _high.Value = value; }
		}

		public string Condition
		{
			get { return _condition.Value; }
			set { _condition.Value = value; }
		}
	}
}

