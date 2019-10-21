using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;
using Spotifree.DAO;
using Spotifree.Models;

namespace Spotifree.Models
{
    public class Category:Model_Abstract
    {
        private int id;

        private string name;

        private DateTime created;

        private DateTime modified;

        public virtual int Id { get => id; set => id = value; }
        public virtual string Name { get => name; set => name = value; }
        public virtual DateTime Created { get => created; set => created = value; }
        public virtual DateTime Modified { get => modified; set => modified = value; }
        public virtual IList<Music> Musics { get; set; }

    }
}