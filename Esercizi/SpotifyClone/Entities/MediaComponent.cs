using SpotifyClone.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class MediaComponent
    {
        private List<Song> playlist;
        private static bool isPlaying = false;
        private static bool isPaused = false;
        private static int currentSongIndex = 0;
        private static int currentSecond = 0;
        bool isPausedByUser;

        internal List<Song> Playlist { get => playlist; set => playlist = value; }

        public MediaComponent() { }

        public static bool IsPlaying1 { get => isPlaying; set => isPlaying = value; }
        public static bool IsPaused1 { get => isPaused; set => isPaused = value; }
        public static int CurrentSongIndex { get => currentSongIndex; set => currentSongIndex = value; }
        public static int CurrentSecond { get => currentSecond; set => currentSecond = value; }


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
                if (isPlaying)
                {
                    playlist[currentSongIndex].Rating++;
                    Console.WriteLine($"Current rating: {playlist[currentSongIndex].Rating}"); WriteRatingToFile(playlist[currentSongIndex]);
                }

                while (isPlaying && currentSecond < playlist[currentSongIndex].Duration)
                {
                    if (!isPaused)
                    {

                        currentSecond++; Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next"); Console.ForegroundColor = ConsoleColor.White;
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
                                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("You pressed Q. SONG STOP!"); Console.ForegroundColor = ConsoleColor.White;
                                isPlaying = false;
                                currentSecond = 0;
                                break;
                            case 'n':
                            case 'N':
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You pressed N. NEXT SONG!");
                                Console.ForegroundColor = ConsoleColor.White;
                                currentSecond = 0;

                                if (currentSongIndex < playlist.Count - 1)
                                {
                                    currentSongIndex++;
                                    if (isPlaying)
                                    {
                                        playlist[currentSongIndex].Rating++;
                                        Console.WriteLine($"Current rating: {playlist[currentSongIndex].Rating}"); WriteRatingToFile(playlist[currentSongIndex]);
                                    }
                                    Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");
                                }
                                else
                                {
                                    Console.WriteLine("This is the last song. You cannot press N for the next song.");
                                }
                                break;

                            case 'b':
                            case 'B':
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You pressed B. PREVIOUS SONG!");
                                Console.ForegroundColor = ConsoleColor.White;
                                currentSecond = 0;

                                if (currentSongIndex > 0)
                                {
                                    currentSongIndex--;
                                    if (isPlaying)
                                    {
                                        playlist[currentSongIndex].Rating++;
                                        Console.WriteLine($"Current rating: {playlist[currentSongIndex].Rating}"); WriteRatingToFile(playlist[currentSongIndex]);
                                    }
                                    Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");
                                }
                                else
                                {
                                    Console.WriteLine("This is the first song. You cannot press B for the previous song.");
                                }
                                break;

                            case 'p':
                            case 'P':
                                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("You pressed P. PAUSED SONG!"); Console.ForegroundColor = ConsoleColor.White;
                                isPaused = true;
                                isPausedByUser = true;
                                break;
                            case 't':
                            case 'T':
                                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("You pressed T. CONTINUE SONG!"); Console.ForegroundColor = ConsoleColor.White;

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
            WriteRatingToFile(playlist[currentSongIndex]);
        }
      public void WriteRatingToFile(Song song)
{
    string filePath = @"C:\\Users\\sarad\\Documents\\DataBaseSpotify.csv";

    // Leggi tutte le righe dal file
    string[] lines = File.ReadAllLines(filePath);

    // Cerca la riga corrispondente alla canzone nel file
    for (int i = 1; i < lines.Length; i++) // Parti da 1 per evitare di leggere l'intestazione
    {
        string[] values = lines[i].Split(',');

        if (values.Length > 1 && values[0] == song.Id1.ToString())
        {
            // Sovrascrivi il rating nella riga corrispondente
            values[1] = song.Rating.ToString();
            lines[i] = string.Join(",", values);
            break;
        }
    }

    // Scrivi tutte le righe, inclusa quella aggiornata, nel file
    File.WriteAllLines(filePath, lines);
}

       
       



        public static void WaitForSecond()
        {
            Thread.Sleep(1000);
        }


    }
}
    

       



