using System;
using System.Threading;

namespace Proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = Proxy.Instance;
            Proxy proxy1 = Proxy.Instance;
            Console.WriteLine("Istanza 1:");
            proxy.randomnumb();
            Console.WriteLine("------------");
            Console.WriteLine("Istanza 2:");
            proxy1.randomnumb();

        }
    }
}
