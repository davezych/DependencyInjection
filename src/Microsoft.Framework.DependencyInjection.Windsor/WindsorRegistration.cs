using System;
using System.Collections.Generic;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Lifestyle;

namespace Microsoft.Framework.DependencyInjection.Windsor
{
    public static class WindsorRegistration
    {
        public static void Populate(IWindsorContainer container, IEnumerable<IServiceDescriptor> services, IServiceProvider fallbackProvider)
        {
            container.Register(Component.For<IWindsorContainer>().Instance(container));
            container.Register(Component.For<IServiceProvider>().ImplementedBy<WindsorServiceProvider>());
            container.Register(Component.For<IServiceScopeFactory>().ImplementedBy<WindsorServiceScopeFactory>());

            container.Install(new KServiceInstaller(services));
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

        private class WindsorServiceScopeFactory : IServiceScopeFactory
        {
            private readonly IWindsorContainer _container;

            public WindsorServiceScopeFactory(IWindsorContainer container)
            {
                _container = container;
            }

            public IServiceScope CreateScope()
            {
                return new WindsorServiceScope(_container);
            }
        }

        private class WindsorServiceScope : IServiceScope
        {
            private readonly IWindsorContainer _container;
            private readonly IServiceProvider _serviceProvider;

            public WindsorServiceScope(IWindsorContainer container)
            {
                _container = container;
                _serviceProvider = _container.Resolve<IServiceProvider>();
            }

            public IServiceProvider ServiceProvider
            {
                get { return _serviceProvider; }
            }

            public void Dispose()
            {
            }
        }
        
        public static ComponentRegistration<object> ConfigureLifeCycle(this ComponentRegistration<object> registration, LifecycleKind kind)
        {
            switch (kind)
            {
                case LifecycleKind.Scoped:
                    registration.LifestyleScoped();
                    break;
                case LifecycleKind.Singleton:
                    registration.LifestyleSingleton();
                    break;
                case LifecycleKind.Transient:
                    registration.LifestyleTransient();
                    break;
            }

            return registration;
        }
    }
}