using System;
using System.Web;
using System.ComponentModel;
using System.Data.Entity;

namespace Spotifree
{
    public class Category
    {
        private int id;

        private string name;

        private DateTime created;

        private DateTime modified;

        public virtual int Id { get => id; set => id = value; }
        public virtual string Name { get => name; set => name = value; }
        public virtual DateTime Created { get => created; set => created = value; }
        public virtual DateTime Modified { get => modified; set => modified = value; }
    }
}