using Spotify_DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
   public class Setting
      {public int Id_Setting { get; set;}
       public bool LightTheme { get; set; }
        public bool GoldPlan { get; set; }
        public bool FreePlan { get; set; }
        public bool PremiumPlan { get; set; }
        public UserDTO User { get; set; }
        public string SelectedTimeZoneId { get; set; }
    }
}
