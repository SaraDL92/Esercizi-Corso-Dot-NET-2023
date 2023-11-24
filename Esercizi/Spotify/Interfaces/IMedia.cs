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
        public void Play(List<Song> playlist, int startIndex);


    }
}
