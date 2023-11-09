using System;
using System.Runtime.CompilerServices;

namespace RdcAbstract
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // istanziamo la variabile patrizio come classe Cittadino che assume i riferimento di studente passandogli i dati di Studente
            Cittadino Patrizio = new Studente("Patrizio", "Cecio", 24, 2, 102, true, false, 96);
            // istanziato il comune di milano
            Comune Milano = new Comune("Milano", 102, "Comune");
            //all'oggetto milano passiamo i dati di patrizio per ottenere il risultato idoneo al RDC.
            Milano.Calculate(Patrizio);

            Cittadino Elena = new StudenteUniversitario("Elena", "Sussurri", 24, 2, 98, true, 96, 28, false);
            Milano.Calculate(Elena);


        }

    }
    // la creazione di una clase astratta è necessaria per creare classi "non reali"
    abstract class Person
    {
        //usare protected serve a creare variabili protette ereditabili da classi collegate
        protected string _name;
        protected string _surName;
        protected int _age;

        public string GetName()
        {
            return _name + " " + _surName;
        }

        //creiamo il costruttore di persona con i dati in input
        public Person(string Name, string surName, int age)
        {
            _name = Name;
            _surName = surName;
            _age = age;
        }
        //creiamo gli attributi leggibili all'esterno
        public string Name { get { return _name; } }
        public string SurName { get { return _surName; } }
        public int Age { get { return _age; } }

        public abstract void GetInfo();

    }

    class Cittadino : Person
    {
        protected int _figli;
        protected decimal _PilComune;
        protected bool _debt;
        protected bool _salary;

        //base ci permette di richiamare i dati della classe padre Cittadino senza doverli reinserire e dichiarare nuovamente
        public Cittadino(string Name, string surName, int age, int Figli, decimal PilComune, bool Debt, bool Salary)
               : base(Name, surName, age)

        {
            _debt = Debt;
            _figli = Figli;
            _PilComune = PilComune;
            _salary = Salary;
        }

        public int Figli { get { return _figli; } }
        public decimal PilComune { get { return _PilComune; } }
        public bool Debt { get { return _debt; } }
        public bool Salary { get { return _salary; } }

        public override void GetInfo()
        {
            Console.Write(_name + " " + _surName + " " + _age);

        }
    }

    class Studente : Cittadino
    {
        protected decimal _votoDiploma;

        public Studente(string Name, string surName, int age, int Figli, decimal PilComune, bool Debt, bool Salary, decimal votoDiploma)
               : base(Name, surName, age, Figli, PilComune, Debt, Salary)

        {
            _votoDiploma = votoDiploma;

        }

        public decimal VotoDiploma { get { return _votoDiploma; } }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.Write(" " + _votoDiploma);
        }
    }

    class StudenteUniversitario : Studente
    {
        protected decimal _votoUni;

        public StudenteUniversitario(string Name, string surName, int age, int Figli, decimal PilComune, bool Debt, decimal votoDiploma, decimal VotoUni, bool Salary)
               : base(Name, surName, age, Figli, PilComune, Debt, Salary, votoDiploma)
        {
            _votoUni = VotoUni;
        }

        public decimal VotoUniversitario { get { return _votoUni; } }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.Write(" " + _votoUni);
        }
    }

    class Militare : Cittadino
    {
        protected int _servizioAnni;

        public Militare(string Name, string surName, int age, int Figli, decimal PilComune, bool Debt, int ServizioAnni, bool Salary)
                       : base(Name, surName, age, Figli, PilComune, Debt, Salary)
        {
            _servizioAnni = ServizioAnni;
        }
        public int Servizio { get { return _servizioAnni; } }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.Write(" " + _servizioAnni);
        }
    }


}


namespace RdcAbstract
{

    abstract class Ente
    {
        protected string _NomeEnte;

        public Ente(string nomeEnte)
        {
            _NomeEnte = nomeEnte;
        }

    }
    class Comune : Ente
    {
        protected string _nomeComune;
        protected int _PilComune;

        public Comune(string nomeComune, int pilComune, string nomeEnte) : base(nomeEnte)
        {
            _nomeComune = nomeComune;
            _PilComune = pilComune;
        }
        //il metodo RDC richiama i dati da Cittadino (classe) a cittadino variabile
        public int Rdc(Cittadino cittadino)
        {
            cittadino.GetInfo();
            int count = 0;
            int inc = 5;
            //usando l'oggetto del cittadino. possiamo richiamare gli attributi assegnati alle singole classi
            if (cittadino.PilComune < 100)
            {
                count += inc;
            }

            if (cittadino.Figli > 1)
            {
                count += inc;
            }

            if (cittadino.Debt)
            {
                count += inc;
            }

            if ((cittadino.Age >= 18 && cittadino.Age <= 25) || (cittadino.Age >= 60 && !cittadino.Salary))
            {
                count += inc;
            }

            //Creazione di un Casting di Cittadino di tipo DownCasting dall'alto verso il basso per poter controllare 
            //all'interno della classe figlio Militare se il cittadino è stato militare, in maniera analoga possiamo farlo
            //per ogni classe Figlio.
            if (cittadino is Militare)
            {
                // questa riga converte i dati di cittadino in militare rendendo accessibile 
                //i dati interni a militare con una variabile di comodo  
                Militare _militare = (Militare)cittadino;

                if (_militare.Servizio > 0)
                {
                    count += inc;
                }
            }

            if (cittadino is Studente)
            {
                Studente _studente = (Studente)cittadino;
                if (_studente.VotoDiploma >= 90)
                {
                    count += inc;
                }

            }

            if (cittadino is StudenteUniversitario)
            {
                StudenteUniversitario _uni = (StudenteUniversitario)cittadino;
                if (_uni.VotoUniversitario >= 28 && (cittadino.Age >= 18 && cittadino.Age <= 25))
                {
                    count += inc;
                }
            }


            return count;

        }
        //calcolo e visualizzazione di idoneità sul risultato di cittadino per il punteggio totale.
        public void Calculate(Cittadino cittadino)
        {
            int count = Rdc(cittadino);

            if (count >= 25)
            {
                Console.WriteLine(" Il Cittadino ha diritto al RDC " + count);
            }
            else
            {
                Console.WriteLine(" Il Cittadino non ha diritto al RDC " + count);
            }

        }
    }
}