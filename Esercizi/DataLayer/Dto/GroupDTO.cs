﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Dto
{
    internal class GroupDTO
    {
        int _id;
        string _name;
        List<ArtistDTO> _members;
        List<MediaDTO> _songs;
        List<AlbumDTO> _albums;
        string _bio;

        

        public GroupDTO(Group group)
        {
            Id = group.Id;
            Name = group.Name;
            Members= group.Members.Select(m=>new ArtistDTO(m)).ToList();
            Albums= group.Albums.Select(a=>new AlbumDTO(a)).ToList();
            Bio = group.Bio;


        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Bio { get => _bio; set => _bio = value; }
        internal List<ArtistDTO> Members { get => _members; set => _members = value; }
        internal List<MediaDTO> Songs { get => _songs; set => _songs = value; }
        internal List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
    }
}