﻿using NHibernate.Criterion;
using Spotifree.Models;
using System.Collections.Generic;

namespace Spotifree.DAO
{
    public class DAO_Music:DAO_Abstract
    {
        private User user;
        private Category category;

        public override Model_Abstract SearchById(int id)
        {
            Music model = Session.Get<Music>(id);

            return model;
        }

        public Music FetchOneById(int id)
        {
            return Session.QueryOver<Music>()
                    .JoinAlias(x => x.User, () => user)
                    .Where(x => x.Id == id)
                    .SingleOrDefault();
        }

        public IList<Music> FetchByName(string name)
        {
            return Session.QueryOver<Music>()
                    .JoinAlias(x => x.User, () => user)
                    .WhereRestrictionOn(x => x.Name).IsLike(name, MatchMode.Anywhere)
                    .List();
        }

        public IList<Music> GetByUserId(int id)
        {
            return Session.QueryOver<Music>()
                    .JoinAlias(x => x.User, () => user)
                    .Where(x => x.User.Id == id)
                    .List();
        }
    }
}