using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;

namespace Spotifree.Models
{
    public class Playlist:List
    {
        public Playlist()
        {
            this.Is_Album = 0;
        }

        public List PlaylistToList(Playlist playlist)
        {
            List list = new List();
            list.Id = playlist.Id;
            list.Created = playlist.Created;
            list.Modified = playlist.Modified;
            list.Is_Album = playlist.Is_Album;
            list.Name = playlist.Name;
            list.User = playlist.User;

            return list;
        }

    }
}