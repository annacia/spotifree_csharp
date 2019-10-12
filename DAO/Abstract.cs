using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Spotifree.DAO
{
    public class DAO_Abstract
    {
        private string table;
        private string model;
        private Dictionary<string, string> data;

        public string Table { get => table; set => table = value; }
        public string Model { get => model; set => model = value; }
        public Dictionary<string, string> Data { get => data; set => data = value; }
    }
}