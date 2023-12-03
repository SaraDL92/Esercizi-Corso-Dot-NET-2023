using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repositories;

namespace Presentation.Menu
{
    internal class PrincipalMenu
    {
        
        public  void menu()
        {
            bool esci = false;
            while(esci!=true) {
            Console.WriteLine("Welcome, choose the type of media you want to play!");
            Console.WriteLine("1. VIDEO");
            Console.WriteLine("2.AUDIO");
            string input=Console.ReadLine();
            if (input=="1")
            {
                    esci = true;
            }else if(input=="2")
            {
                    esci = true;
            }
            else { esci = false; } }
        }

    }
}
