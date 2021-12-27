using System;

namespace DI_Container
{
    public class B : IB
    {
        public B(IA a) {}

        public void newPrint()
        {
            Console.WriteLine("B : IB");
        }
    }
}