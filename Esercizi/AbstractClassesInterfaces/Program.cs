using System;

namespace AbstractClassesInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {//I nomi degli stati sono stati messi casualmente, le informazioni riportate ovviamente non sono reali
         //fungono unicamente a scopo dimostrativo
            
            EuroCentralBank eurocentralbank = new EuroCentralBank("Euro Central Bank");
            EurozoneState statoEuroZone = new("Austria", true, true, false);
            EU statoEu = new("Francia", true, false, false);
            Onu statoOnu = new("Italia", true, true, true);
            Onu statoOnu1 = new("Germania", false, true, true);
            EuropeanCourtofHumanRights corte = new();
           

            Console.WriteLine(eurocentralbank.CalcoloSpread(statoEuroZone));
            Console.WriteLine(corte.Check(statoEu));
            Console.WriteLine(corte.Check(statoOnu));
            Console.WriteLine(corte.Check(statoOnu1));
            Console.WriteLine(corte.Check(statoEuroZone));
            Console.Read();

        }
    }
}
