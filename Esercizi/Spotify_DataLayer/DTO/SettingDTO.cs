using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.DTO
{
    public class SettingDTO
    {   public int Id_Setting { get; set; }
        public UserDTO User { get; set; }
        public bool LightTheme { get; set; }
        public bool GoldPlan { get; set; }
        public bool FreePlan { get; set; }
        public bool PremiumPlan { get; set; }

        public string SelectedTimeZoneId { get; set; }

        public SettingDTO() {
           
        }

        public SettingDTO(UserDTO user, bool lt,bool gp,bool fp,bool pp, string selectedtimezone)
        {
            User = user;
            LightTheme= lt;
            GoldPlan= gp;
            FreePlan= fp;
            PremiumPlan= pp;
            SelectedTimeZoneId = selectedtimezone;
        }
        

    }
}
