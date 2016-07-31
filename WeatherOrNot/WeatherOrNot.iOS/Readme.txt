Create a file named MasterViewController.Keys.cs that looks like this:

using WeatherOrNot.Services;
using WeatherOrNot.ViewModels;

namespace WeatherOrNot.iOS
{
    public partial class MasterViewController
    {
        partial void InitializeViewModelLocator(IStorageService storageService)
        {
            ViewModelLocator.Initialize("Mashape key", storageService);
        }
    }
}

When I update the demo to use a different weather provider, this will
become the API key for that new provider. Until then, just create this
file so that the app will build. Mashape does not provide this service
anymore.