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
        public override Model_Abstract SearchById(int id)
        {
            List model = Session.Get<List>(id);

            return model;
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