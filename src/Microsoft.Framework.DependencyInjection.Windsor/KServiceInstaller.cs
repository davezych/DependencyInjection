using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Collections.Generic;

namespace Microsoft.Framework.DependencyInjection.Windsor
{
    public class KServiceInstaller : IWindsorInstaller
    {
        private IEnumerable<IServiceDescriptor> _services;

        public KServiceInstaller(IEnumerable<IServiceDescriptor> services)
	    {
            _services = services;
	    }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            throw new NotImplementedException();
        }
    }
}