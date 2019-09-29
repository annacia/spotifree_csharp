using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Spotifree
{
    public abstract class List
    {
        private int id;

        private string name;

        private bool isAlbum;

        private string created;

        private string modified;

        private User user;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public bool IsAlbum { get => isAlbum; set => isAlbum = value; }
        public string Created { get => created; set => created = value; }
        public string Modified { get => modified; set => modified = value; }
        public User User { get => user; set => user = value; }
    }
}