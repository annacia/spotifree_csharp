using NHibernate;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.DAO
{
    public class DAO_Music:DAO_Abstract
    {
        public override Model_Abstract SearchById(int id)
        {
            Music model = Session.Get<Music>(id);

            return model;
        }
    }
}