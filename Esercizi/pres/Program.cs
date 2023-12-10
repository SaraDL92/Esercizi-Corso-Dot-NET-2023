using data.DB;
using data.DTO;

using Data.Repositories;
using Services;
using System;

namespace pres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            db data = new();
            SongRepo songRepo = new(data);
            SongService songService = new(songRepo);
            //inizializzazione database
            var songDto = new data.DTO.SongDTO("bella ciao");
            var song2 = new data.DTO.SongDTO("bao bao");
            songService.AddItem(songDto, "Title");
            songService.AddItem(song2, "Title");


            songService.DisplayItems<data.Models.song>("Title");
        }
    }
}
