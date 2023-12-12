using SpotifyClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLibrary.DTOs
{
   public class PlayListDTO: CsvHelper.Configuration.ClassMap<PlayList>
    {
        private static int _nextid = 5;
        int _id;
        UserDTO _user;
        List<Media> _songs = new List<Media>();
        string _name;
        int _rating;

        public PlayListDTO()
        {
            Map(m => m.Id).Name("ID");
            mA
            Map(m => m.User.UserName).Name("USER");

        }


        public static int Nextid { get => _nextid; set => _nextid = value; }
        public int Id { get => _id; set => _id = value; }
        public UserDTO User { get => _user; set => _user = value; }
        public List<Media> Songs { get => _songs; set => _songs = value; }
        public string Name { get => _name; set => _name = value; }
        public int Rating { get => _rating; set => _rating = value; }
    }
}
