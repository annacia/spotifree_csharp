using NHibernate;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.DAO
{
    public class DAO_Category:DAO_Abstract
    {
        
        public override Model_Abstract SearchById(int id)
        {
            Category model = Session.Get<Category>(id);

            return model;
        }

        public IList<Category> FetchAll()
        {
            return Session.QueryOver<Category>()
                    .List();
        }

    }
}