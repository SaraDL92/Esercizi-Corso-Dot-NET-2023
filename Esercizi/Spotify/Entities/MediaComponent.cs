using Spotify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spotify.Entities
{
    internal class MediaComponent : IMedia
    {
        List<Song> _songlist;
        int _currentIndex;
        bool _isPlaying = false;
        bool _isPaused = false;
        int _currentSecond=0;

        public MediaComponent(List<Song> songlist, int currentIndex,bool ispaying, int currentSecond, bool isPaused)
        {
            _songlist = songlist;
            _currentIndex = currentIndex;
            _isPlaying = ispaying;
            _currentSecond = currentSecond;
            _isPaused = isPaused;
        }
        public MediaComponent() { }
        public int CurrentIndex { get => _currentIndex; set => _currentIndex = value; }
        internal List<Song> Songlist { get => _songlist; set => _songlist = value; }
        public bool IsPlaying { get => _isPlaying; set => _isPlaying = value; }
        public int CurrentSecond { get => _currentSecond; set => _currentSecond = value; }
        public bool IsPaused { get => _isPaused; set => _isPaused = value; }

        public void next()
        {
            if (Songlist.Count==0)
            {
                Console.WriteLine("There aren't disponible songs ");

            }
            if (CurrentIndex > Songlist.Count-1) 
            { CurrentIndex = 0; }
            
            CurrentIndex++;

            Console.WriteLine("Playing the next song" + Songlist[CurrentIndex]);

        }
        public void play(Song song)
        {if (IsPaused)
            {
                IsPaused = false;
                IsPlaying = true;
                Console.WriteLine($"Playing the song {song.Title} from the second {CurrentSecond} you left off! ");
                for (int i = CurrentSecond; i < song.Duration; i++)
                {
                    CurrentSecond = i;
                    Thread.Sleep(1000);
                    Console.WriteLine($"Seconds scrolling bar: {CurrentSecond} s");
                    
                }
            }
            else { IsPlaying = true;
                  
            Console.WriteLine($"Playing the song {song.Title}");
            for (int i = 0; i < song.Duration; i++) {
                CurrentSecond = i;
                 Thread.Sleep(1000);
                Console.WriteLine($"Seconds scrolling bar: {CurrentSecond} s"); } }
               







        }

        public void pause(Song song)
        {
            if (IsPlaying){
                IsPlaying = false;
                IsPaused = true;
                Console.WriteLine($"Song stopped at the second {CurrentSecond}");
            }
            else { Console.WriteLine("No songs playing"); }
            
        }

        
        public void play(Album album)
        {
            throw new NotImplementedException();
        }

        public void play(PlayList playlist)
        {
            for (int i = 0; i< playlist.Songs.Count; i++)
            {
                Console.WriteLine(playlist.Songs[i]);
            }
        }

        public void previous(Song song)
        {
            throw new NotImplementedException();
        }

        public void stop(Song song)
        {
            throw new NotImplementedException();
        }
    }
}
