using InternationalPublicManagement;
using RelazioniOrizzontali;
using System.Linq;
using System;

internal class Region : GeographicalArea, IUEpublicAdministration
{
    private string _name;
    private State _state;
    private Province[] _provinces = new Province[0];
    private int _maxPopulation = 1000;


    public Province[] Provinces { get { return _provinces; }set { _provinces = value; } }
    public Region(string name)
    {
        _name = name;
    }

    public int CountProvinces()
    {
        return _provinces.Count(p => p != null);
    }

    public void BuildProvince(string name)
    {
        
        

        Province prov = new Province(name, this); 
        Console.WriteLine($"La regione {_name} ha creato la provincia {prov.Name}");
        Console.WriteLine($"Capacità massima della regione: {_maxPopulation} abitanti");

        int index = Array.FindIndex(_provinces, p => p == null);

        if (index != -1)
        {
            _provinces[index] = prov;
            _maxPopulation = _maxPopulation+200; 
            
            
        }
        else
        {
            // Se l'array è completamente popolato, crea un nuovo array più grande
            Province[] newArray = new Province[_provinces.Length + 1];
            Array.Copy(_provinces, newArray, _provinces.Length);
            newArray[_provinces.Length] = prov;
            _provinces = newArray;

            _maxPopulation =_maxPopulation +200;


        }


    }



   
  
    public void ShowMeProvinces()
    {
        Console.WriteLine($"La regione {_name} ha queste province:");

        foreach (var prov in _provinces.Where(p => p != null))
        {
            Console.WriteLine(prov.Name);
        }

        if (_provinces.All(p => p == null))
        {
            Console.WriteLine($"La regione {_name} non ha province.");
        }
    }

    public void BuildCityHall(Province province, string name)
        {
            province.BuildCityHall(name);
        }
       

        
        public string Name { get { return _name; } set { _name = value; } }
        public State State { get { return _state; } set { _state=value; } }



        
      public override  string ToString() { return Name; }
       
        public void TerritoryManagement(State Claimer, State Dest)
        {
            throw new NotImplementedException();
        }

        public void Welfare()
        {
            throw new NotImplementedException();
        }

        public void HNS()
        {
            throw new NotImplementedException();
        }

        public void LawSystem()
        {
            throw new NotImplementedException();
        }

        public void EducationalSystem()
        {
            throw new NotImplementedException();
        }
    }


      
    
