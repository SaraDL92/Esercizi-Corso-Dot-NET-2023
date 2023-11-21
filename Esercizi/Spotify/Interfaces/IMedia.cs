using Spotify.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Interfaces
{
    internal interface IMedia
    {
        public void play(Song song);
        public void play(Album album);
        public void play(PlayList playlist);
        public void pause(Song song);
        public void stop(Song song);
        public void next();
        public void previous(Song song);


    }
}
