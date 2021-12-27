using System;
using System.Collections.Generic;

namespace DI_Container.DependencyInjection
{
    public class DiServiceCollection
    {
        private Dictionary<Type, ServiceDescriptor> _serviceDescriptors = new Dictionary<Type, ServiceDescriptor>();

        
        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singelton));
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
        }

        public DiContainer GenerateContainer()
        {
            return new DiContainer(_serviceDescriptors);
        }
    }
}