using AutoMapper;
using Spotify_DataLayer.DTO;
using Spotify_DataLayer.Interfaces;
using Spotify_DataLayer.Models;
using Spotify_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Service.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISettingRepository _settingRepository;
       

        private readonly IMapper _mapper;

        public UserService(IUserRepository uRepository, ISettingRepository settrepo,  IMapper mapper)
        {
            _userRepository = uRepository;
            _settingRepository = settrepo;
           

            _mapper = mapper;
        }
        public List<UserDTO> GetAllUsers()
        {
            var users = _userRepository.ReadUsers();
            return _mapper.Map<List<UserDTO>>(users);
        }
        public UserDTO GetUserById(int Id)
        {
            var user = _userRepository.ReadUserById(Id);

            if (user == null)
            {

                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }

        public void AddUser(UserDTO newUser)
        {
            var users = _userRepository.ReadUsers();
            int nuovoId = users.Count + 1;

            var user = _mapper.Map<User>(newUser);
            user.Id_User = nuovoId;

            users.Add(user);
            _userRepository.WriteUsers(users);

        }

        public List<SettingDTO> GetAllSettings()
        {
            var settings = _settingRepository.ReadSettings();
            return _mapper.Map<List<SettingDTO>>(settings);
        }
        public SettingDTO GetSettingById(int Id)
        {
            var setting = _settingRepository.ReadSettingById(Id);

            if (setting == null)
            {

                return null;
            }

            return _mapper.Map<SettingDTO>(setting);
        }

        public void AddSetting(SettingDTO newSetting)
        {
            var settings = _settingRepository.ReadSettings();
            int nuovoId = settings.Count + 1;

            var setting = _mapper.Map<Setting>(newSetting);
            setting.Id_Setting = nuovoId;

            settings.Add(setting);
            _settingRepository.WriteSettings(settings);

        }


    }
}
