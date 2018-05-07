using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;

namespace JeffsSample
{
    public class AutofacAdapter : IServiceProvider, IRegisteredObject
    {
        private IContainer _container;
        private Func<Type, object> CreateNonPublicInstance =
                    (serviceType) => Activator.CreateInstance(
                        serviceType,
                        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.CreateInstance,
                        null,
                        null,
                        null);

        public AutofacAdapter(IContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (_container.IsRegistered(serviceType))
            {
                return _container.Resolve(serviceType);
            }
            else
            {
                return CreateNonPublicInstance(serviceType);
            }
        }

        public void Stop(bool immediate)
        {
            _container.Dispose();

            HostingEnvironment.UnregisterObject(this);
        }
    }
}