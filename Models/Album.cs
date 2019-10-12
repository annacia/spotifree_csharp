using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;

namespace Spotifree
{
    public class Album : List, List_Interface
    {
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
        }
    }
}