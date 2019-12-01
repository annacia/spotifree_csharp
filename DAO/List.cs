using NHibernate;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.DAO
{
    public class DAO_List:DAO_Abstract
    {
        private Music music;
        private User user; 
        private Category category;

        public override Model_Abstract SearchById(int id)
        {
            return Session.QueryOver<List>()
                   .JoinAlias(x => x.Musics, () => music)
                   .JoinAlias(x => x.User, () => user)
                   .JoinAlias(x => music.Category, () => category)
                   .Where(x => x.Id == id)
                   .SingleOrDefault();
        }

        public IList<Music> AddMusic(Music music, List list)
        {
            if (!list.Musics.Contains(music))
            {
                ITransaction transaction = Session.BeginTransaction();
                list.Musics.Add(music);
                this.Session.Merge(list);
                transaction.Commit();
            }

            return list.Musics;
        }
    }
}