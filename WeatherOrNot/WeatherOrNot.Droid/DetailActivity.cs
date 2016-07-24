using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using WeatherOrNot.ViewModels;
using Assisticant.Binding;

namespace WeatherOrNot.Droid
{
	[Activity(Label = "WeatherApp.Detail")]
	public class DetailActivity : Activity
	{
        private CityViewModel _viewModel;
        private BindingManager _bindings = new BindingManager();

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Detail);

            _bindings.Initialize(this);
            ViewModelLocator.Initialize(
                Resources.GetString(Resource.String.MashapeKey),
                new AndroidStorageService());

            _viewModel = ViewModelLocator.Instance.City;

            _bindings.BindText(
                FindViewById<TextView>(Resource.Id.cityNameText),
                () => _viewModel.Name);
            _bindings.BindItems(
                FindViewById<ListView>(Resource.Id.forecastList),
                () => _viewModel.Forecasts,
                Android.Resource.Layout.SimpleListItem2,
                (row, forecast, bindings) =>
                {
                    bindings.BindText(
                        row.FindViewById<TextView>(Android.Resource.Id.Text1),
                        () => forecast.Text);
                    bindings.BindText(
                        row.FindViewById<TextView>(Android.Resource.Id.Text2),
                        () => forecast.Description);
                });

            _viewModel.Refresh();
		}

        protected override void OnDestroy()
        {
            _bindings.Unbind();

            base.OnDestroy();
        }
	}
}


