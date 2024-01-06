using System;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            PrepareCoffe();
            PreapareToast();
            Console.Read();
        }

        static async Task PrepareCoffe()
        {
            Console.WriteLine("Accendo la macchinetta del caffè");
            await Task.Delay(7000);
            Console.WriteLine("Caffè pronto");

        }
        static async Task PreapareToast()
        {
            Console.WriteLine("Accendo la piastra");
            await Task.Delay(2000);
            Console.WriteLine("Piastra riscaldata");
            Console.WriteLine("Inserisco il pane");
            await Task.Delay(5000);
            Console.WriteLine("Pane tostato");

        }
    }
}
