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
                isPausedByUser = false; 
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
                            case 'Q':
                                Console.WriteLine("You pressed Q. SONG STOP!");
                                isPlaying = false;
                                currentSecond = 0;
                                break;
                            case 'n':
                            case 'N':
                                Console.WriteLine("You pressed N. NEXT SONG!");
                                currentSecond = 0;
                                currentSongIndex++;
                                if (currentSongIndex >= playlist.Count)
                                {
                                    currentSongIndex = 0;
                                }

                                Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");
                                break;
                            case 'b':
                            case 'B':
                                Console.WriteLine("You pressed B. PREVIOUS SONG!");
                                currentSecond = 0;
                                currentSongIndex--;
                                if (currentSongIndex < 0)
                                {
                                    currentSongIndex = playlist.Count - 1;
                                }

                                Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");
                                break;
                            case 'p':
                            case 'P':
                                Console.WriteLine("You pressed P. PAUSED SONG!");
                                isPaused = true;
                                isPausedByUser = true;
                                break;
                            case 't':
                            case 'T':
                                Console.WriteLine("You pressed T. CONTINUE SONG!");

                                isPaused = false;
                                if (isPausedByUser)
                                {
                                   
                                    Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");
                                    isPausedByUser = false; 
                                }
                                break;
                        }
                    }

                    pauseEvent.Wait(); 
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
            Thread.Sleep(1000); 
        }


    }
}
