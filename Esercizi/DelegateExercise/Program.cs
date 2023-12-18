using System;
using System.Security.Cryptography.X509Certificates;
using DelegateExercise;

namespace DelegateExercise
{
    using System;
    public delegate int PrimoDelegate(int x, int y);
    public delegate void SecondoDelegate(int x, int y);
            internal class Program
        {


        static void Main(string[] args)
        {

            PrimoDelegate sumDelegate = new(Sum);
            SecondoDelegate eseguiprimodelegate = new(EseguiSum);

            EseguiTutto(eseguiprimodelegate, 10, 20);
          

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
