using Assisticant.Binding;
using CoreGraphics;
using Foundation;
using System;
using UIKit;
using WeatherOrNot.Services;
using WeatherOrNot.ViewModels;

namespace WeatherOrNot.iOS
{
    public partial class MasterViewController : UITableViewController
    {
        private MainViewModel _viewModel;
        private BindingManager _bindings = new BindingManager();

        partial void InitializeViewModelLocator(IStorageService storageService);

        public MasterViewController(IntPtr handle)
            : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Master", "Master");

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                PreferredContentSize = new CGSize(320f, 600f);
                ClearsSelectionOnViewWillAppear = false;
            }

            // Custom initialization
        }

        public DetailViewController DetailViewController
        {
            get;
            set;
        }

        void AddNewItem(object sender, EventArgs args)
        {
            PerformSegue("newCity", this);
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

            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.LeftBarButtonItem = EditButtonItem;

            var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
            NavigationItem.RightBarButtonItem = addButton;

            _bindings.Initialize(this);
            InitializeViewModelLocator(new IosStorageService());

            _viewModel = ViewModelLocator.Instance.Main;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _viewModel.SelectedCityHeader = null;

            _bindings.BindItems(
                TableView,
                () => _viewModel.CityHeaders,
                () => _viewModel.SelectedCityHeader,
                value => _viewModel.SelectedCityHeader = value,
                (cell, city, bindings) =>
                {
                    bindings.BindText(
                        cell.TextLabel,
                        () => city.Name);
                });

            _bindings.Bind(
                () => _viewModel.SelectedCityHeader,
                cityHeader => OnSelected(cityHeader));
        }

        public override void ViewDidDisappear(bool animated)
        {
            _bindings.Unbind();

            base.ViewDidDisappear(animated);
        }

        [Action("UnwindToMaster:")]
        public void UnwindToMaster(UIStoryboardSegue segue)
        {
        }

        private void OnSelected(CityHeaderViewModel cityHeader)
        {
            if (cityHeader != null)
                PerformSegue("showDetail", this);
        }
    }
}