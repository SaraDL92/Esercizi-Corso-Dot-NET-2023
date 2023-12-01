using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Models;

namespace DataLayer.DbContext
{
    internal class DirectorDbContext
    {List <Director> _directors;

        internal List<Director> Directors { get => _directors; set => _directors = value; }
    }
}
