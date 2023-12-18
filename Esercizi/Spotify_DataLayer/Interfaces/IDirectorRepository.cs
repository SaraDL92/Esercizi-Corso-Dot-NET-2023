using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Interfaces
{
    public interface IDirectorRepository
    {
        List<Director> ReadDirectors();
        void WriteDirectors(List<Director> directors);
        Director ReadDirectorById(int Id);
    }
}
