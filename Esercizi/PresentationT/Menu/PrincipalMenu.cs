using System;
using DataLayerT.Repositories;
using ServiceLayerT.Services;

namespace PresentationT.Menu
{
    internal class PrincipalMenu
    {
        SongRepository songRepository;

        public PrincipalMenu(SongRepository songrepo)
        {
            songRepository = songrepo;
        }



        public void One()
        {
            Console.WriteLine("Welcome to Spotify");
            Console.WriteLine("Choose the media, enter the number:");
            Console.WriteLine("1. Music");
            Console.WriteLine("2. Video");
            string input = Console.ReadLine();
            if (input == "1")
            {
                var songService = new SongService(songRepository);
                songService.GetAllSongs();

            }
        }
    }
}