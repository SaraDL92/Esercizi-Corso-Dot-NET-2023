using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.DbContext
{
    internal class DispositiveDbContext
    {List <Dispositive> _dispositives;

        internal List<Dispositive> Dispositives { get => _dispositives; set => _dispositives = value; }
    }
}
