using System;
using DI_Container.DependencyInjection;

namespace DI_Container
{
    class Program
    {
        public static void Main(string[] args)
        {
            var servicesOne = new DiServiceCollection();
            var servicesTwo = new DiServiceCollection();
            var servicesThree = new DiServiceCollection();
            
            servicesOne.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();
            servicesTwo.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();
            servicesThree.RegisterSingleton<IA, A>();
            servicesThree.RegisterTransient<IB, B>();
            
            var containerOne = servicesOne.GenerateContainer();
            var containerTwo = servicesTwo.GenerateContainer();
            var containerThree = servicesThree.GenerateContainer();
            
            var serviceSingOne = containerOne.GetService<IRandomGuidProvider>();
            var serviceSingTwo = containerOne.GetService<IRandomGuidProvider>();
            
            var serviceTransOne = containerTwo.GetService<IRandomGuidProvider>();
            var serviceTransTwo = containerTwo.GetService<IRandomGuidProvider>();
            
            
            Console.WriteLine("Singelton");
            Console.WriteLine(serviceSingOne.RandomGuid);
            Console.WriteLine(serviceSingTwo.RandomGuid);
            
            
            Console.WriteLine("\nTransient");
            Console.WriteLine(serviceTransOne.RandomGuid);
            Console.WriteLine(serviceTransTwo.RandomGuid);
            
            
            
            Console.WriteLine("\nExample of cycle detection");
            
            try
            {
                var singeltonTestFirst = containerThree.GetService<IA>();
                var singeltonTestSecond = containerThree.GetService<IB>();
                var transientTestFirst = containerThree.GetService<IA>();
                var transientTestSecond = containerThree.GetService<IB>();
            }
            catch
            {
                Console.WriteLine("Сycle detected");
            }
        }
    }
}