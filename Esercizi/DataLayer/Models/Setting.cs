using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Setting
    {
        int _id;
        User _user;
        bool _darkTheme;
        int _equalizerBass;
        int _equalizerHigh;
        int _equalizerVol;
        bool _premium;
        int _numberDispositives;
        List<Dispositive> dispositives = new List<Dispositive>();

        internal bool DarkTheme { get => _darkTheme; set => _darkTheme = value; }
        internal int EqualizerBass { get => _equalizerBass; set => _equalizerBass = value; }
        internal int EqualizerHigh { get => _equalizerHigh; set => _equalizerHigh = value; }
        internal int EqualizerVol { get => _equalizerVol; set => _equalizerVol = value; }
       internal bool Premium { get => _premium; set => _premium = value; }
        internal int NumberDispositives { get => _numberDispositives; set => _numberDispositives = value; }
        internal int Id { get => _id; set => _id = value; }
        internal User User { get => _user; set => _user = value; }
        internal List<Dispositive> Dispositives { get => dispositives; set => dispositives = value; }
    }
}
