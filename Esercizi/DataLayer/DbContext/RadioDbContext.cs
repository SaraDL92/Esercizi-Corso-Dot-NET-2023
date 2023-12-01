using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;


namespace DataLayer.DbContext
{
    internal class RadioDbContext
    {List <Radio> _radioList;

        internal List<Radio> RadioList { get => _radioList; set => _radioList = value; }
    }
}
