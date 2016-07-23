using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WeatherOrNot.ViewModels;
using Assisticant.Binding;

namespace WeatherOrNot.Droid
{
    [Activity(Label = "WeatherApp.NewCity")]
    public class NewCityActivity : Activity
    {
        NewCityViewModel _viewModel = ViewModelLocator.Instance.NewCity;
        BindingManager _bindings = new BindingManager();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.NewCity);

            _bindings.Initialize(this);

            _viewModel.CityName = null;

            _bindings.BindText(
				FindViewById<EditText>(Resource.Id.editName),
                () => _viewModel.CityName,
                value => _viewModel.CityName = value);

            _bindings.BindCommand(
				FindViewById<Button>(Resource.Id.buttonAdd),
				() => OnAdd(),
                () => _viewModel.CanAddCity);
        }

		private void OnAdd()
		{
			_viewModel.AddCity();
			Finish();
		}
    }
}