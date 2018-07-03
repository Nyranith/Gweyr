using Gweyr.PropertyWriter.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Gweyr.Common;
using System.Collections.Generic;

namespace Gweyr.PropertyWriter
{
    public class PropertyWriterModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public PropertyWriterModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }


        public void Initialize()
        {
            //_container.RegisterTypeForNavigation<ViewA>();

            _container.RegisterType<ViewPropertyWriter>();
            _container.RegisterTypeForNavigation<ViewPropertyWriter>();
        }
    }
}