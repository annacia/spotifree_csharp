using System;
using System.Collections.Generic;

namespace Spotifree.Models
{
    public class MusicList : Model_Abstract
    {
        private int id;
        
        private Music music;
        private List list;

        public virtual int Id { get => id; set => id = value; }
        public virtual Music Music { get => music; set => music = value; }
        public virtual List List { get => list; set => list = value; }
    }
}