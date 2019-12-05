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
            List model = Session.Get<List>(id);

            return model;
        }

        public List FetchOne(int id)
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

        public IList<Music> RemoveMusic(Music music, List list)
        {
            int indexOfMusic = this.IndexOfMusicInList(list.Musics, music);

            if (indexOfMusic != -1)
            {
                ITransaction transaction = Session.BeginTransaction();
                list.Musics.Remove(list.Musics[indexOfMusic]);
                this.Session.Merge(list);
                transaction.Commit();
            }

            return list.Musics;
        }

        private int IndexOfMusicInList(IList<Music> musics, Music music)
        {
            int length = musics.Count;

            for (int i = 0; i < length; i++)
            {
                if (musics[i].Id == music.Id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}