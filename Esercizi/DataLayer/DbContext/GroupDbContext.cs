using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.DbContext
{
    internal class GroupDbContext
    {
        List<Group> _groups;

        internal List<Group> Groups { get => _groups; set => _groups = value; }
    }
}
