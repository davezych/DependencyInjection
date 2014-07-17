using System;
using System.Collections.Generic;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace Microsoft.Framework.DependencyInjection.Windsor
{
    public static class WindsorRegistration
    {
        public static void Populate(IWindsorContainer container, IEnumerable<IServiceDescriptor> services, IServiceProvider fallbackProvider)
        {
            container.Register(Component.For<IWindsorContainer>().Instance(container));
            container.Register(Component.For<IServiceProvider>().ImplementedBy<WindsorServiceProvider>());
        }

        public class WindsorServiceProvider : IServiceProvider
        {
            private IWindsorContainer _container;

            public WindsorServiceProvider(IWindsorContainer container)
            {
                _container = container;
            }

            public object GetService(Type serviceType)
            {
                return _container.Resolve(serviceType);
            }
        }
    }
}