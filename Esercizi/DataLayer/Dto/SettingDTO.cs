using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    internal class SettingDTO
    {
        int _id;
        UserDTO _user;
        bool _darkTheme;
        int _equalizerBass;
        int _equalizerHigh;
        int _equalizerVol;
        bool _premium;
        int _numberDispositives;
        List<DispositiveDTO> dispositives = new List<DispositiveDTO>();

        public int Id { get => _id; set => _id = value; }
        public bool DarkTheme { get => _darkTheme; set => _darkTheme = value; }
        public int EqualizerBass { get => _equalizerBass; set => _equalizerBass = value; }
        public int EqualizerHigh { get => _equalizerHigh; set => _equalizerHigh = value; }
        public int EqualizerVol { get => _equalizerVol; set => _equalizerVol = value; }
        public bool Premium { get => _premium; set => _premium = value; }
        public int NumberDispositives { get => _numberDispositives; set => _numberDispositives = value; }
        internal UserDTO User { get => _user; set => _user = value; }
        internal List<DispositiveDTO> Dispositives { get => dispositives; set => dispositives = value; }
    }
}
