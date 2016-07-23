using System;
using WeatherOrNot.Models;
using System.Collections.Generic;
using WeatherOrNot.Services;

namespace WeatherOrNot.ViewModels
{
    public class NewCityViewModel
    {
        private readonly Document _document;
        private readonly CitySelection _selection;
		private readonly IStorageService _storageService;

        public NewCityViewModel(
			Document document,
			CitySelection selection,
			IStorageService storageService)
        {
			_storageService = storageService;
            _document = document;
            _selection = selection;
        }

        public string CityName
        {
            get
            {
                return _selection.CityName;
            }
            set
            {
                _selection.CityName = value;
            }
        }

        public void AddCity()
        {
            _document.NewCity().Name = _selection.CityName;
        }

        public bool CanAddCity
        {
            get
            {
                return !String.IsNullOrEmpty(_selection.CityName);
            }
        }
    }
}

