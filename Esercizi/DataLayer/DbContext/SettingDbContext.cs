using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;


namespace DataLayer.DbContext
{
    internal class SettingDbContext
    {
        List<Setting> _settings;

        internal List<Setting> Settings { get => _settings; set => _settings = value; }
    }
}
