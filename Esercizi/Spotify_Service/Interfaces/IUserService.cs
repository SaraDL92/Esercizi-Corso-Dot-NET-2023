using Spotify_DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Service.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetAllUsers();
        UserDTO GetUserById(int Id);
        void AddUser(UserDTO newUser);
        List<SettingDTO> GetAllSettings();
       SettingDTO GetSettingById(int Id);
        void AddSetting(SettingDTO newSetting);

    }
}
