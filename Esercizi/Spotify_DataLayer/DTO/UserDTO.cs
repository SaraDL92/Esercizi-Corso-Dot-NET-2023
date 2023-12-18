using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.DTO
{
    public class UserDTO
    {   public int Id_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public SettingDTO Setting { get; set; }

        public UserDTO() { }

        public UserDTO(string username, string password, string email,SettingDTO setting)
        { Username=username; Password = password; Email = email;Setting = setting;
       
        }
    }
}
