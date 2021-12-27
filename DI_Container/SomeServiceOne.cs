using System;
using DI_Container.DependencyInjection;

namespace DI_Container
{
    public class SomeServiceOne : ISomeService
    {
        private readonly IRandomGuidProvider _randomGuidProvider;

        public SomeServiceOne(IRandomGuidProvider randomGuidProvider)
        {
            _randomGuidProvider = randomGuidProvider;
        }
        
        public void PrintSomething()
        {
            Console.WriteLine(_randomGuidProvider.RandomGuid);
        }
    }
}