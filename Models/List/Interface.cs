using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;

namespace Spotifree
{
    public interface List_Interface
    {
        List newList(Dictionary<string, string> data);

        List insert(Music music, List list);

        List remove(Music music, List list);
    }
}