using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entities
{
    internal class Setting
    {
        User _user;
        bool _darkTheme;
        string _equalizer;
        bool _premium;
        int _numberDispositives;

        public Setting(User user,bool darkTheme, string equalizer, bool premium, int numberDispositives)
        {
            _user = user;
            _darkTheme = darkTheme;
            _equalizer = equalizer;
            _premium = premium;
            _numberDispositives = numberDispositives;
        }

        public bool DarkTheme { get => _darkTheme; set => _darkTheme = value; }
        public string Equalizer { get => _equalizer; set => _equalizer = value; }
        public bool Premium { get => _premium; set => _premium = value; }
        public int NumberDispositives { get => _numberDispositives; set => _numberDispositives = value; }
        internal User User { get => _user; set => _user = value; }
    }
}
