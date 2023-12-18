using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Interfaces
{
    public interface IUserRepository
    {
        List<User> ReadUsers();
        User ReadUserById(int Id);
        void WriteUsers(List<User> users);
    }
}

