using System;

namespace DI_Container.DependencyInjection
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; }
        
        public Type ImplementationType { get; }
        
        public object Implementation { get; internal set; }
        
        public ServiceLifetime Lifetime { get; }

        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime) 
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
            ImplementationType = implementationType;
        }
    }
}