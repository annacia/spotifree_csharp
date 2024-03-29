﻿using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifree.Mapper
{
    interface Mapper_Interface
    {
        public bool Register();
        public bool Update();
        public Model_Abstract Load(int id);
        public void SetModelById(int id);
    }
}
