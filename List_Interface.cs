using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Spotifree
{
    public interface List_Interface
    {
        List newList(string name);

        List updateList(string name);

        void delete();

        List insert(Music music);

        List remove(Music music);
    }
}