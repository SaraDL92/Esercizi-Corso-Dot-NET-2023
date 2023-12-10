using DataLayerT.DB;
using DataLayerT.Repositories;
using PresentationT.Menu;
using ServiceLayerT.Services;
using DataLayerT.Models;
using System;
using System.Linq.Expressions;
using DataLayerT.DTO;

namespace PresentationT
{
    internal class Program
    {
        static void Main(string[] args)
        {   DataBase dataBase = new DataBase();
            SongRepository songRepository = new(dataBase);
            SongService songService = new(songRepository);
            Artist MichaelJackson = new("Michael Jackson");
            Album Dangerous = new("Dangerous", MichaelJackson);
            Song song = new("Black or White", MichaelJackson, Dangerous);
            ArtistDTO artist=new(MichaelJackson);
            AlbumDTO album = new(Dangerous);
            SongDTO song1 = new(song);



            dataBase.SongList.Add(song);
            
            PrincipalMenu principalMenu = new PrincipalMenu(songRepository);
            principalMenu.One();
        }
    }
}
