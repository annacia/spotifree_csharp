using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace Spotifree
{
    public class Playlist : List, List_Interface
    {
        public List newList(Dictionary<string, string> data)
        {
            data["IsAlbum"] = "0";

            base.insertList(data, this);
            return this;
        }

        public List insert(Music music, List list)
        {
            return base.addMusic(music, list);
        }

        public List remove(Music music, List list)
        {
            return base.removeMusic(music, list);
        }
    }
}