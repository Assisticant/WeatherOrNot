using Assisticant.Fields;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WeatherOrNot.Services;

namespace WeatherOrNot.iOS
{
    class IosStorageService : IStorageService
    {
        private Observable<Exception> _lastException = new Observable<Exception>();

        public Exception LastException => _lastException;

        public List<CityMemento> LoadCities()
        {
            var fileName = GetFileName();

            if (File.Exists(fileName))
            {
                try
                {
                    using (var stream = new FileStream(
                        fileName,
                        FileMode.Open))
                    {
                        var dc = new DataContractSerializer(
                            typeof(DocumentMemento));

                        var document = (DocumentMemento)dc.ReadObject(stream);
                        _lastException.Value = null;
                        return document.Cities;
                    }
                }
                catch (Exception x)
                {
                    _lastException.Value = x;
                }
            }

            return new List<CityMemento>();
        }

        public void SaveCities(IEnumerable<CityMemento> cities)
        {
            var fileName = GetFileName();

            FileMode fileMode = File.Exists(fileName)
                ? FileMode.Truncate
                : FileMode.CreateNew;

            using (var stream = new FileStream(
                fileName,
                fileMode))
            {
                var dc = new DataContractSerializer(
                    typeof(DocumentMemento));

                dc.WriteObject(stream, new DocumentMemento
                {
                    Cities = cities.ToList()
                });
            }


        }

        public List<ForecastMemento> LoadForecasts(string cityName)
        {
            return new List<ForecastMemento>();
        }

        public void SaveForecasts(string cityName, IEnumerable<ForecastMemento> forecasts)
        {
        }

        private static string GetFileName()
        {
            var documents = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments);
            return Path.Combine(documents, "cities.xml");
        }
    }
}
