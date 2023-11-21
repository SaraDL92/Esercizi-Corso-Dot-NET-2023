using Spotify.Entities;
using System;

namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Artist MichaelJackson = new("Michael", "Jackson", "29-08-1958", "Michael Jackson",null,null,"The gratest star of all times!",null);
           
            Console.WriteLine(MichaelJackson);
            
            MichaelJackson.CreateNewSong("Pop", "Heal the World", 110, "01-10-1991", null);
            MichaelJackson.CreateNewSong("Pop", "Dangerous", 120, "01-10-1991", null);
            MediaComponent mediacomponent = new();
            
            MichaelJackson.ShowMeSongList();
            mediacomponent.play(MichaelJackson.Songs[0]);

            Console.Read();
        }
    }
}
