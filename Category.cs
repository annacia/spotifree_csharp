using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Spotifree
{
    public class Category
    {
        private int id;

        private string name;

        private string created;

        private string modified;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Created { get => created; set => created = value; }
        public string Modified { get => modified; set => modified = value; }

        public Array fetchAll()
        {
            int[] all = new int[1];

            return all;
        }
    }
}