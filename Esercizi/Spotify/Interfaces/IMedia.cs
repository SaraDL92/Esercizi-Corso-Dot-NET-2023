﻿using Spotify.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Interfaces
{
    internal interface IMedia
    {
        public void Play(Song song);
        public void Play(List<Song>song);
        
        public void pause(Song song);
        public void stop(Song song);
        public void next();
        public void previous(Song song);


    }
}