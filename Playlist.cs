using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Spotifree
{
    public class Playlist : List, Interface_List
    {
        public List newList(string name)
        {
            return this;
        }

        public List updateList(string name)
        {
            return this;
        }

        public void delete()
        {

        }

        public List insert(Music music)
        {
            return this;
        }

        public List remove(Music music)
        {
            return this;
        }


    }
}