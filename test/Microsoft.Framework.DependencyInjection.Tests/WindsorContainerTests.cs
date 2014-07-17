using Castle.Windsor;
using Microsoft.Framework.DependencyInjection.Tests.Fakes;
using Microsoft.Framework.DependencyInjection.Windsor;
using System;

namespace Microsoft.Framework.DependencyInjection.Tests
{
    public class WindsorContainerTests : ScopingContainerTestBase
    {
        protected override IServiceProvider CreateContainer()
        {
            return CreateContainer(new FakeFallbackServiceProvider());
        }

        protected override IServiceProvider CreateContainer(IServiceProvider fallbackProvider)
        {
            var container = new WindsorContainer();
            WindsorRegistration.Populate(container, TestServices.DefaultServices(), fallbackProvider);

            return container.Resolve<IServiceProvider>();
        }
    }
}