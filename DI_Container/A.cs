using System;

namespace DI_Container
{
    public class A : IA
    {
        public A(IB b) {}
        
        public void print()
        {
            Console.WriteLine("A : IA");
        }
    }
}