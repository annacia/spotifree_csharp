using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Spotifree
{
    public abstract class Music_Abstract
    {
        private int id;

        private string name;

        private string dir_music;

        private string dir_art;

        private string created;

        private string modified;

        private Category category;

        private User user;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Dir_music { get => dir_music; set => dir_music = value; }
        public string Dir_art { get => dir_art; set => dir_art = value; }
        public string Created { get => created; set => created = value; }
        public string Modified { get => modified; set => modified = value; }
        public Category Category { get => category; set => category = value; }
        public User User { get => user; set => user = value; }
    }
}