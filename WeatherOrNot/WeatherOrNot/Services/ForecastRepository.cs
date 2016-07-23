using System;
using WeatherOrNot.Services;
using System.Threading.Tasks;
using WeatherOrNot.Models;
using System.Collections.Generic;

namespace WeatherOrNot.Services
{
	public class ForecastRepository
	{
		private readonly IStorageService _storageService;
		private readonly IWeatherServiceAgent _weatherServiceAgent;
		private readonly Document _document;

		public ForecastRepository(
			IStorageService storageService,
			IWeatherServiceAgent weatherServiceAgent,
			Document document)
		{
			_weatherServiceAgent = weatherServiceAgent;
			_storageService = storageService;
			_document = document;
		}

		public async Task Refresh(City city)
		{
			var forecasts = _storageService.LoadForecasts(city.Name);
			city.LoadForecasts(forecasts);

			await _weatherServiceAgent.Refresh();

			_storageService.SaveForecasts(
				city.Name, city.SaveForecasts());
		}
	}
}

