using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Interfaces
{
    public interface ISettingRepository
    {
        List<Setting> ReadSettings();
        Setting ReadSettingById(int Id);
        void WriteSettings(List<Setting> settings);
    }
}