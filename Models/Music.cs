using System;
using System.Web;
using System.ComponentModel;
using Spotifree.Helper;
using System.Collections.Generic;
using Spotifree.Models;

namespace Spotifree.Models
{
    public class Music:Model_Abstract
    {
        private int id;

        private string name;

        private string dir_music;

        private string dir_art;

        private DateTime created;

        private DateTime modified;

        private Category category;
        
        private User user;

        public virtual int Id { get => id; set => id = value; }
        public virtual string Name { get => name; set => name = value; }
        public virtual string Dir_music { get => dir_music; set => dir_music = value; }
        public virtual string Dir_art { get => dir_art; set => dir_art = value; }
        public virtual DateTime Created { get => created; set => created = value; }
        public virtual DateTime Modified { get => modified; set => modified = value; }
        public virtual Category Category { get => category; set => category = value; }
        public virtual User User { get => user; set => user = value; }
        public virtual IList<List> Lists { get; set; }

    }
}