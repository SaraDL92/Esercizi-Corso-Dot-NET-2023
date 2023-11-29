using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{

    internal class Proxy
    {
        private static Proxy _instance;
        private static Random rnd=new Random();
        private static byte first=(byte)rnd.Next(256);
        private static byte second = (byte)rnd.Next(256);
        private static byte third = (byte)rnd.Next(256);
        private static byte fourth = (byte)rnd.Next(256);
        private static byte first1 = (byte)rnd.Next(256);
        private static byte second1 = (byte)rnd.Next(256);
        private static byte third1 = (byte)rnd.Next(256);
        private static byte fourth1 = (byte)rnd.Next(256);


        private Proxy() {
           
        }
        public void randomnumb()
        {
            Console.WriteLine($"Primo Indirizzo IP:{first}.{second}.{third}.{fourth}");
            Console.WriteLine($"Secondo Indirizzo IP:{first1}.{second1}.{third1}.{fourth1}");

        }
        public static Proxy Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Proxy();
                }
                return _instance;
            }
        }
      
    }
}






