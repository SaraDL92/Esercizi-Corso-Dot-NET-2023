using SpotifyClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayerSpotify.DTO
{
    public class AlbumDTO
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string NumbOfTracks { get; set; }
        public bool LiveVersion { get; set; }
        public ArtistDTO Artist { get; set; }
        public GroupDTO Group { get; set; }
        public List<MediaDTO> TrackList { get; set; }
        public int Rating { get; set; }
       public int CalculateRating { get; set; }

        public AlbumDTO(Album album)
        {
            Title = album.Title;
            ReleaseDate = album.ReleaseDate;
            NumbOfTracks = album.NumbOfTracks;
            LiveVersion = album.LiveVersion;
            Artist = new ArtistDTO(album.Artist);
            Group = new GroupDTO(album.Group);
            TrackList = new List<MediaDTO>();
            foreach (var item in album.TrackList)
            {
                TrackList.Add(new MediaDTO(item));
            }
            Rating = album.Rating;
            CalculateRating = album.CalculateRating();


        }

       
    }
    }

