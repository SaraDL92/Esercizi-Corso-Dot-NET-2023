using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class Region : Territory
    {
        string _name;
        State _state;
        List<Province> _provinces;


       

        public Region(string name)
        {
            _name = name;
           
        }

        
        public string Name { get { return _name; } set { _name = value; } }
        public State State { get { return _state; } set { _state=value; } }
        public List<Province> Province { get { return _provinces; }
            set { _provinces = value; } }
        

      public void AddProvinceToRegion()
        {
            //aggiungere Provincia alla lista province
        }

        public void RemoveProvinceFromRegion()
        {
            //rimuovere provincia dalla lista
        }

        public string TellMeTheState() { return $"The region {Name} is part of the State {State}"; }

        public override string ToString()
        {
            return Name;
        }



    }
      
    }
   
