using SpotifyClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerSpotify.DTO
{
    internal class SettingDTO
    {
        UserDTO _user;
        bool _darkTheme;
        int _equalizerBass;
        int _equalizerHigh;
        int _equalizerVol;
        bool _premium;
        int _numberDispositives;
        List<DispositiveDTO> dispositives = new List<DispositiveDTO>();

        public SettingDTO(Setting s)
        {
            User = new UserDTO(s.User);
            DarkTheme = s.DarkTheme;
            EqualizerBass = s.EqualizerBass;
            EqualizerHigh = s.EqualizerHigh;
            EqualizerVol = s.Volume;
            Premium = s.Premium;
            NumberDispositives = s.NumberDispositives;
            foreach(var d in s.Dispositives)
            {
                dispositives.Add(new DispositiveDTO(d));
            }

        }
        public UserDTO User { get => _user; set => _user = value; }
        public bool DarkTheme { get => _darkTheme; set => _darkTheme = value; }
        public int EqualizerBass { get => _equalizerBass; set => _equalizerBass = value; }
        public int EqualizerHigh { get => _equalizerHigh; set => _equalizerHigh = value; }
        public int EqualizerVol { get => _equalizerVol; set => _equalizerVol = value; }
        public bool Premium { get => _premium; set => _premium = value; }
        public int NumberDispositives { get => _numberDispositives; set => _numberDispositives = value; }
        public List<DispositiveDTO> Dispositives { get => dispositives; set => dispositives = value; }
    }
}
