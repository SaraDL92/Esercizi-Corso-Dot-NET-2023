using Spotify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spotify.Entities
{
    internal class MediaComponent
    {
        private List<Song> playlist;
        private static bool isPlaying = false;
        private static bool isPaused = false;
        private static int currentSongIndex = 0;
        private static int currentSecond = 0;
        bool isPausedByUser;

        internal List<Song> Playlist { get => playlist; set => playlist = value; }


        public static bool IsPlaying1 { get => isPlaying; set => isPlaying = value; }
        public static bool IsPaused1 { get => isPaused; set => isPaused = value; }
        public static int CurrentSongIndex { get => currentSongIndex; set => currentSongIndex = value; }
        public static int CurrentSecond { get => currentSecond; set => currentSecond = value; }

        public MediaComponent()
        {

        }
        private static ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);

        public void Play(List<Song> playlist, int startIndex)
        {
            if (startIndex >= 0 && startIndex < playlist.Count)
            {
                isPlaying = true;
                isPaused = false;
                isPausedByUser = false; // Nuova variabile per gestire la pausa causata dall'utente
                currentSongIndex = startIndex;

                Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");

                while (isPlaying && currentSecond < playlist[currentSongIndex].Duration)
                {
                    if (!isPaused)
                    {
                        currentSecond++;
                        Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next");
                        Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title} - " +
                            $"Seconds scrolling bar: {currentSecond} s");
                    }

                    WaitForSecond();

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(false);

                        switch (key.KeyChar)
                        {
                            case 'q':
                                Console.WriteLine("Hai premuto 'q'. Uscita dal ciclo.");
                                isPlaying = false;
                                break;
                            case 'n':
                                Console.WriteLine("Hai premuto 'n'. Passando alla canzone successiva.");
                                currentSecond = 0;
                                currentSongIndex++;
                                if (currentSongIndex >= playlist.Count)
                                {
                                    currentSongIndex = 0;
                                }

                                Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");
                                break;
                            case 'b':
                                Console.WriteLine("Hai premuto 'b'. Passando alla canzone precedente.");
                                currentSecond = 0;
                                currentSongIndex--;
                                if (currentSongIndex < 0)
                                {
                                    currentSongIndex = playlist.Count - 1;
                                }

                                Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");
                                break;
                            case 'p':
                                Console.WriteLine("Hai premuto 'p'. Mettendo in pausa il ciclo.");
                                isPaused = true;
                                isPausedByUser = true; // Segnala che la pausa è stata causata dall'utente
                                break;
                            case 't':
                                Console.WriteLine("Hai premuto 't'. Riprendendo il ciclo.");

                                isPaused = false;
                                if (isPausedByUser)
                                {
                                    // Se la pausa è stata causata dall'utente, riprendiamo da dove eravamo rimasti
                                    Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");
                                    isPausedByUser = false; // Ripristina il flag
                                }
                                break;
                        }
                    }

                    pauseEvent.Wait(); // Attendiamo l'evento di pausa
                }

                isPlaying = false;
                isPaused = false;
                isPausedByUser = false;
            }
            else
            {
                Console.WriteLine("Invalid start index. Please provide a valid index.");
            }
        }


        public static void WaitForSecond()
        {
            Thread.Sleep(1000); // Implementa la tua logica per aspettare un secondo
        }


    }
}
