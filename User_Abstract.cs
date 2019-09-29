﻿using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Spotifree
{
    public abstract class User_Abstract
    {
        private int id;

        private string name;

        private string password;

        private string created;

        private string modified;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Created { get => created; set => created = value; }
        public string Modified { get => modified; set => modified = value; }
    }
}