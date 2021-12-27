using System;
using System.Collections.Generic;
using System.Linq;

namespace DI_Container.DependencyInjection
{
    public class DiContainer
    {
        private Dictionary<Type, ServiceDescriptor> _serviceDescriptors;
        
        public DiContainer(Dictionary<Type, ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        public object GetService(Type serviceType, List<Type> dependsList)
        {
            var descriptor = _serviceDescriptors[serviceType];

            if (descriptor == null)
            {
                throw new Exception($"There is no type of {serviceType.Name}");
            }

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Can't create an instance of interfaces or abstract classes");
            }

            var constructorInfo = actualType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters();

            List<object> newParameters = new List<object>();
            
            foreach (var parameter in parameters)
            {
                if (dependsList.Contains(serviceType))
                {
                    throw new Exception($"{serviceType.Name} type is already referenced.");
                }
                
                dependsList.Add(serviceType);
                
                var newParameter = GetService(parameter.ParameterType, dependsList);
                
                dependsList.Remove(serviceType);
                newParameters.Add(newParameter);
            }

            var res = newParameters.ToArray();

            var implementation = Activator.CreateInstance(actualType, res);

            if (descriptor.Lifetime == ServiceLifetime.Singelton)
            {
                descriptor.Implementation = implementation;
            }

            return implementation;
        }

        public object GetService(Type serviceType)
        {
            List<Type> depsList = new List<Type>();

            return GetService(serviceType, depsList);
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}