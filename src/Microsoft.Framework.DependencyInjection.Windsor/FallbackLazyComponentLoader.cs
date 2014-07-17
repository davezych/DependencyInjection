using Castle.MicroKernel.Resolvers;
using System;
using Castle.MicroKernel.Registration;
using System.Collections;

namespace Microsoft.Framework.DependencyInjection.Windsor
{
    public class FallbackLazyComponentLoader : ILazyComponentLoader
    {
        private IServiceProvider _fallbackProvider;

        public FallbackLazyComponentLoader(IServiceProvider provider)
	    {
            _fallbackProvider = provider;
	    }

        public IRegistration Load(string name, Type service, IDictionary arguments)
        {
            throw new NotImplementedException();
        }
    }
}