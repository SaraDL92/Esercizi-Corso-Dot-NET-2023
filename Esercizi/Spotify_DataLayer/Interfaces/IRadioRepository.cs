using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotify_DataLayer.Models;

namespace Spotify_DataLayer.Interfaces
{
    public interface IRadioRepository
    {
        List<Radio> ReadRadios();
        void WriteRadios(List<Radio> radios); 
       Radio ReadRadioById(int radioId);
    }
   
}
