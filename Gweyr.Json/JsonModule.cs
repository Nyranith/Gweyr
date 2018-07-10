using Gweyr.Json.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace Gweyr.Json
{
    public class JsonModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public JsonModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ViewA>();
        }
    }
}