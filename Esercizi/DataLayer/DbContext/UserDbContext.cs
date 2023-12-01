using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;


namespace DataLayer.DbContext
{
    internal class UserDbContext
    {List<User> _users;

        internal List<User> Users { get => _users; set => _users = value; }
    }
}
