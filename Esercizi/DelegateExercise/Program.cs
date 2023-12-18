using System;
using System.Security.Cryptography.X509Certificates;
using DelegateExercise;

namespace DelegateExercise
{
    using System;
    using System.Reflection.Emit;

    //Primo Esercizio
    public delegate int PrimoDelegate(int x, int y);
    public delegate void SecondoDelegate(int x, int y);
   

    

            internal class Program
        {


        static void Main(string[] args)
        {
            //Primo esercizio
            PrimoDelegate sumDelegate = new(Sum);
            SecondoDelegate eseguiprimodelegate = new(EseguiSum);
            Console.Write("Risultato primo esercizio:");
            Console.WriteLine();
            EseguiTutto(eseguiprimodelegate, 10, 20);

            //Secondo Esercizio
            Console.WriteLine("Risultato secondo esercizio:");
            Func<int, int, int> Moltiplica = delegate (int a, int b)
            {
                return a * b;
            };
            int moltiplicazione=Moltiplica(10, 10);
            int moltiplicazione2=Moltiplica(20, 2);
;
            Predicate<int> isBigger = delegate (int moltiplicazione)
            {
            return moltiplicazione > 50 ? true  : false;
            
            };
            Action<int > Message = delegate (int s) { if (isBigger(s)==true) { Console.WriteLine($"{s} è maggiore di 50"); } else { Console.WriteLine($"{s} è minore di 50"); } };


            Message(moltiplicazione);
            Message(moltiplicazione2);

            
                  
            



            //Funzioni primo esercizio
            static int Sum(int x,int y)
            {
                Console.WriteLine(x+y);
                return x + y;
            }

            static void EseguiSum(int x, int y)
            {
                Sum(x,y);
            }
           static void EseguiTutto(SecondoDelegate eseguitutto,int x, int y) {
                eseguitutto(x, y);
            }
        }
        }
    }
