using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;

namespace Spotifree.Models
{
    public class Album : List
    {
        public Album()
        {
            this.Is_Album = 1;
        }

        public List AlbumToList(Album album)
        {
            List list = new List();
            list.Id = album.Id;
            list.Created = album.Created;
            list.Modified = album.Modified;
            list.Is_Album = album.Is_Album;
            list.Name = album.Name;
            list.User = album.User;

            return list;
        }
        /**
        public List newList(Dictionary<string, string> data)
        {
            data["IsAlbum"] = "1";

            base.insertList(data, this);
            return this;
        }

        public List insert(Music music, List list)
        {
            int userMusicId = music.User.Id;
            int listUserId = list.User.Id;

            if (userMusicId == listUserId)
            {
                return base.addMusic(music, list);
            }

            return list;
        }

        public List remove(Music music, List list)
        {
            return base.removeMusic(music, list);
        }*/
    }
}