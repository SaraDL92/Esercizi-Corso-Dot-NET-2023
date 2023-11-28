﻿using SpotifyClone.Interfaces;
using SpotifyClone.Services;
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
        DateTime pausedstart;
        DateTime pausedend;
        TimeSpan calcolopausa;
        internal List<Song> Playlist { get => playlist; set => playlist = value; }

        public MediaComponent() { }

        public static bool IsPlaying1 { get => isPlaying; set => isPlaying = value; }
        public static bool IsPaused1 { get => isPaused; set => isPaused = value; }
        public static int CurrentSongIndex { get => currentSongIndex; set => currentSongIndex = value; }
        public static int CurrentSecond { get => currentSecond; set => currentSecond = value; }


        private static ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);

        public void Play(List<Song> playlist, int startIndex,Writers writer,User user)
        {
            if (startIndex >= 0 && startIndex < playlist.Count)
            {
                isPlaying = true;
                isPaused = false;
                isPausedByUser = false;
                currentSongIndex = startIndex;
                DateTime datainizio = DateTime.Now;

                Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");
                if (isPlaying)
                {
                    
                    Console.WriteLine(datainizio);
                    writer.WriteTopRatedSongsToFile(playlist, 5);
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
                                DateTime datafine = DateTime.Now;
                                TimeSpan sessionDuration = datafine - datainizio;
                                user.SessionDuration = user.SessionDuration+sessionDuration;
                                user.SessionDuration = user.SessionDuration - calcolopausa;
                                calcolopausa = TimeSpan.Zero;

                                try
                                {
                                    Console.WriteLine($"StartTimeSong: {user.StartTimeSong}");
                                    Console.WriteLine($"EndTimeSong: {user.EndTimeSong}");

                                   

                                   writer.WriteListeningTimeToFile(user);
                                    Console.WriteLine("Your Music Listening Time:" + " " + user.SessionDuration + " " + "seconds");
                                }
                                catch (NullReferenceException ex)
                                {
                                    Console.WriteLine($"An error occurred: {ex.Message}");
                                }


                                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("You pressed Q. SONG STOP!"); Console.ForegroundColor = ConsoleColor.White;
                              
                                isPlaying = false;
                                currentSecond = 0;
                                break;
                            case 'n':
                            case 'N':
                                if (user.IsFree && user.SessionDuration.TotalSeconds > 360000)
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("You are a free user and you have reached the limit of 100 hours of listening, you can no longer skip songs.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                                if (user.IsPremium && user.SessionDuration.TotalSeconds > 3600000)
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("You are a premium user and you have reached the limit of 1000 hours of listening, you can no longer skip songs.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                                else { 
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
                                        Console.WriteLine($"Current rating: {playlist[currentSongIndex].Rating}"); WriteRatingToFile(playlist[currentSongIndex]); writer.WriteTopRatedSongsToFile(playlist, 5);
                                    }
                                    Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");
                                }
                                else
                                {
                                    Console.WriteLine("This is the last song. You cannot press N for the next song.");
                                }}
                                break;

                            case 'b':
                            case 'B':
                                if (user.IsFree && user.SessionDuration.TotalSeconds > 360000)
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("You are a free user and you have reached the limit of 100 hours of listening, you can no longer skip songs.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                                if (user.IsPremium && user.SessionDuration.TotalSeconds > 3600000)
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("You are a premium user and you have reached the limit of 1000 hours of listening, you can no longer skip songs.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                                else
                                {
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
                                            Console.WriteLine($"Current rating: {playlist[currentSongIndex].Rating}"); WriteRatingToFile(playlist[currentSongIndex]); writer.WriteTopRatedSongsToFile(playlist, 5);
                                        }
                                        Console.WriteLine($"Playing the song {playlist[currentSongIndex].Title}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("This is the first song. You cannot press B for the previous song.");
                                    }
                                }
                                break;
                               
                            case 'p':
                            case 'P':
                                pausedstart = DateTime.Now;
                                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("You pressed P. PAUSED SONG!"); Console.ForegroundColor = ConsoleColor.White;
                                isPaused = true;
                                isPausedByUser = true;
                                break;
                            case 't':
                            case 'T':
                              pausedend= DateTime.Now;
                              TimeSpan calcolotempopausa = pausedend - pausedstart ;
                                calcolopausa = calcolopausa + calcolotempopausa;
                               

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

   
    string[] lines = File.ReadAllLines(filePath);

   
    for (int i = 1; i < lines.Length; i++) 
    {
        string[] values = lines[i].Split(',');

        if (values.Length > 1 && values[0] == song.Id1.ToString())
        {
           
            values[1] = song.Rating.ToString();
            lines[i] = string.Join(",", values);
            break;
        }
    }

   
    File.WriteAllLines(filePath, lines);
}

       
       



        public static void WaitForSecond()
        {
            Thread.Sleep(1000);
        }


    }
}
    

       



