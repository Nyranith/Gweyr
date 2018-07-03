using Gweyr.Views;
using System.Windows;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Gweyr.PropertyWriter;
using Gweyr.Common;
using Gweyr.Views.Content;
using Gweyr.Names;
using Prism.Regions;
using System;
using Gweyr.PropertyWriter.Views;

namespace Gweyr
{
    class Bootstrapper : UnityBootstrapper
    {

        private IRegionManager regionManager;

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();

            this.regionManager = Container.TryResolve<Prism.Regions.IRegionManager>();


            this.regionManager.RegisterViewWithRegion(RegionNames.LeftSideRegion, typeof(Menu));
            this.regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ViewPropertyWriter)); 

        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterViewType<Menu>();
            Container.RegisterTypeForNavigation<Menu>();

        }


        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;

            moduleCatalog.AddModule(typeof(PropertyWriterModule));

            //moduleCatalog.AddModule(typeof(YOUR_MODULE));
        }
    }
}
