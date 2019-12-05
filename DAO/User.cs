using NHibernate;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.DAO
{
    public class DAO_User:DAO_Abstract
    {
        private Music music;

        public override Model_Abstract SearchById(int id)
        {
            User model = Session.Get<User>(id);

            return model;
        }

        public User FetchOne(int id)
        {
            return Session.QueryOver<User>()
                   .JoinAlias(x => x.Musics, () => music)
                   .Where(x => x.Id == id)
                   .SingleOrDefault();
        }
    }
}