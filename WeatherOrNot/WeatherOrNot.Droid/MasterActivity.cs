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
    [Activity(Label = "Weather", MainLauncher = true, Icon = "@drawable/icon")]
    public class MasterActivity : Activity
    {
        private MainViewModel _viewModel;
        private BindingManager _bindings = new BindingManager();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Master);

			_bindings.Initialize(this);
            ViewModelLocator.Initialize(
                Resources.GetString(Resource.String.MashapeKey),
                new AndroidStorageService());

            _viewModel = ViewModelLocator.Instance.Main;

            _viewModel.SelectedCityHeader = null;

			_bindings.BindCommand(
				FindViewById<Button>(Resource.Id.buttonAdd),
				() => StartActivity(typeof(NewCityActivity)));

            _bindings.BindItems(
                FindViewById<ListView>(Resource.Id.listCities),
                () => _viewModel.CityHeaders,
                global::Android.Resource.Layout.SimpleListItem1,
                () => _viewModel.SelectedCityHeader,
                value => _viewModel.SelectedCityHeader = value,
                (cell, city, bindings) =>
                {
                    bindings.BindText(
                        cell.FindViewById<TextView>(global::Android.Resource.Id.Text1),
                        () => city.Name);
                });

            _bindings.Bind(
                () => _viewModel.SelectedCityHeader,
                cityHeader => OnSelected(cityHeader));
        }

        protected override void OnDestroy()
        {
            _bindings.Unbind();

            base.OnDestroy();
        }

        private void OnSelected(CityHeaderViewModel cityHeader)
        {
            if (cityHeader != null)
            {
				StartActivity(typeof(DetailActivity));
            }
        }
    }
}