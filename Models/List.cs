using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;
using Spotifree.Helper;
using Spotifree.Models;

namespace Spotifree.Models
{
    public class List:Model_Abstract
    {
        private int id;

        private string name;

        private int is_album;

        private DateTime created;

        private DateTime modified;

        private User user;

        public virtual int Id { get => id; set => id = value; }
        public virtual string Name { get => name; set => name = value; }
        public virtual DateTime Created { get => created; set => created = value; }
        public virtual DateTime Modified { get => modified; set => modified = value; }
        public virtual User User { get => user; set => user = value; }
        public virtual int Is_Album { get => is_album; set => is_album = value; }

        public virtual IList<Music> Musics { get; set; }
    }


}