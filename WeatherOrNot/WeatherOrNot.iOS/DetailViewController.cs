using Assisticant.Binding;
using Foundation;
using System;
using UIKit;
using WeatherOrNot.ViewModels;

namespace WeatherOrNot.iOS
{
    public partial class DetailViewController : UITableViewController
    {
        private CityViewModel _viewModel;
        private BindingManager _bindings = new BindingManager();

        public DetailViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _bindings.Initialize(this);
            _viewModel = ViewModelLocator.Instance.City;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _viewModel.Refresh();

            _bindings.Bind(
                () => _viewModel.Name,
                value => this.Title = value);

            _bindings.BindItems(
                TableView,
                () => _viewModel.Forecasts,
                (cell, forecast, bindings) =>
                {
                    bindings.BindText(
                        cell.TextLabel,
                        () => forecast.Text);
                    if (cell.DetailTextLabel != null)
                        bindings.BindText(
                            cell.DetailTextLabel,
                            () => forecast.Description);
                });
        }

        public override void ViewDidDisappear(bool animated)
        {
            _bindings.Unbind();

            base.ViewDidDisappear(animated);
        }
    }
}