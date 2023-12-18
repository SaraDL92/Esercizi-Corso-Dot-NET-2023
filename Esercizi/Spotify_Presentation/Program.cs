using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Spotify_Service.Interfaces;

using Spotify_Service.Configuration;

namespace Spotify_Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                var serviceProvider = new ServiceCollection()
                .AddCaching() // Utilizza il tuo metodo di estensione
                .BuildServiceProvider();

                // Ottieni l'istanza del servizio
                var musicService = serviceProvider.GetRequiredService<IMusicService>();
                var movieService = serviceProvider.GetRequiredService<IMovieService>();
                var userService = serviceProvider.GetRequiredService<IUserService>();


                // Crea l'istanza dell'interfaccia utente
                var consoleInterface = new ConsoleInterface(musicService,movieService,userService);

                // Esegui l'interfaccia utente della console
                consoleInterface.Execute();




               
          
            }
        }
    }
}
