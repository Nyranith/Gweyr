using Microsoft.Practices.Unity;
using Prism.Unity; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gweyr.Common
{
    public static class UnityContainerHelper
    {
        /// <summary>
        /// Register a view for navigation. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        public static void RegisterViewType<T>(this IUnityContainer container)
        {
            container.RegisterType<object, T>(typeof(T).FullName);
        }

        public static void RegisterViewType<T>(this IUnityContainer container, T type)
        {
            container.RegisterType<object, T>(typeof(T).FullName); 
        }

        public static void RegisterTypeForNavigation<T>(this IUnityContainer container, T type)
        {
            container.RegisterTypeForNavigation<T>();
        }

    }
}
