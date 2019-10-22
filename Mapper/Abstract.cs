﻿using Spotifree.DAO;
using Spotifree.Helper;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.Mapper
{
    public abstract class Mapper_Abstract
    {
        private Model_Abstract model;
        private DAO_Abstract dao;
        private Dictionary dicHelper;

        public Dictionary DicHelper { get => dicHelper; set => dicHelper = value; }
        public Model_Abstract Model { get => model; set => model = value; }
        public DAO_Abstract Dao { get => dao; set => dao = value; }

        public abstract void DictionaryToModel(Dictionary<string, string> dic);

        public Mapper_Abstract()
        {
            DicHelper = new Dictionary();
        }
    }
}