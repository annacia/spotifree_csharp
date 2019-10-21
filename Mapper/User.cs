using Spotifree.DAO;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.Mapper
{
    public class User:Mapper_Abstract
    {
        public User()
        {
            Dao = new DAO_User();
            Model = new Spotifree.Models.User();
        }

    }
}