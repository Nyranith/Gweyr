using Gweyr.Commands;
using Gweyr.Names;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;

namespace Gweyr.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<Type> NavigateCommand { get; private set; }
        public DelegateCommand<string> OnDoubleClickCommand { get; private set; }

        private readonly IRegionManager _regionManager;

        private string _title = "Gweyr";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private WindowState _windowState;

        public WindowState WindowState
        {
            get
            {
                return _windowState;
            }
            set
            {
                SetProperty(ref this._windowState, value);
            }
        }

        private Visibility _visibility = Visibility.Visible;

        public Visibility Visibility
        {
            get
            {
                return this._visibility;
            }
            set
            {
                SetProperty(ref this._visibility, value);
            }
        }

        public MainWindowViewModel(IRegionManager regionManger)
        {
            this._regionManager = regionManger;

            NavigateCommand = new DelegateCommand<Type>(CenterNavigation);
            ApplicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);

            OnDoubleClickCommand = new DelegateCommand<string>(OnDoubleClick); 

        }

        public void OnDoubleClick(string value)
        {
            Console.WriteLine(value); 
        }

        public void CenterNavigation(Type viewObt)
        {
            if (viewObt != null)
            {
                _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, viewObt);
            }
        }

        public void ContentRegionInitialized(object sender, RoutedEventArgs e)
        {
            //this.CenterNavigation(typeof(ViewLogin));
        }

    }
}
