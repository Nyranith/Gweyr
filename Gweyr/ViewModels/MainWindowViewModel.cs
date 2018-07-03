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
        private readonly IRegionManager _regionManager;

        private string _title = "Gweyr";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManger)
        {
            this._regionManager = regionManger;

            NavigateCommand = new DelegateCommand<Type>(CenterNavigation);
            ApplicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
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
