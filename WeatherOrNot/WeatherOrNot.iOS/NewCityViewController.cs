using Assisticant.Binding;
using Foundation;
using System;
using UIKit;
using WeatherOrNot.ViewModels;

namespace WeatherOrNot.iOS
{
    public partial class NewCityViewController : UIViewController
    {
        private NewCityViewModel _viewModel;
        private BindingManager _bindings = new BindingManager();

        public NewCityViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _bindings.Initialize(this);
            _viewModel = ViewModelLocator.Instance.NewCity;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _viewModel.CityName = null;

            _bindings.BindText(
                CityName,
                () => _viewModel.CityName,
                value => _viewModel.CityName = value);

            _bindings.BindCommand(
                OkButton,
                () => _viewModel.AddCity(),
                () => _viewModel.CanAddCity);
        }
    }
}