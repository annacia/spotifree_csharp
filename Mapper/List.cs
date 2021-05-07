using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spotifree.DAO;
using Spotifree.Models;

namespace Spotifree.Mapper
{
    public class Mapper_List : Mapper_Abstract, Mapper_Interface
    {
        public override void DictionaryToModel(Dictionary<string, string> data)
        {
            throw new NotImplementedException();
        }

        public Mapper_List()
        {
            Dao = new DAO_List();
            Model = new List();
        }

        public Model_Abstract Load(int id)
        {
            return Dao.SearchById(id) as List;
        }

        public List FetchOne(int id)
        {
            DAO_List dao = new DAO_List();

            return dao.FetchOne(id);
        }

        public IList<List> GetByUser(User user)
        {
            DAO_List dao = new DAO_List();

            return dao.GetByUserId(user.Id);
        }

        public bool Register()
        {
            bool status = true;
            try
            {
                List list = Model as List;
                list.Created = DateTime.Now;

                Dao.Insert(list);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }

        public void SetModelById(int id)
        {
            this.Model = this.Load(id);
        }

        public bool Update()
        {
            bool status = true;
            try
            {
                List list = Model as List;
                List listUpdate = Dao.SearchById(list.Id) as List;

                listUpdate.Modified = DateTime.Now;
                listUpdate.Name = list.Name;

                Dao.Update(listUpdate);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }

        public bool RemoveMusic(Music music)
        {
            try
            {
                List list = Model as List;
                DAO_List dao = Dao as DAO_List;
                List listcomplete = dao.FetchOne(list.Id);

                dao.RemoveMusic(music, listcomplete);
                return true;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                return false;
            }
        }

        public bool InsertMusic(Music music)
        {
            try
            {
                List list = Model as List;
                bool sameUser = music.User.Id == list.User.Id;
                bool isAlbum = list.Is_Album == 1;

                if (isAlbum)
                {
                    return this.InsertMusicAlbum(music, list);
                }

                return this.InsertMusicPlaylist(music, list);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                return false;
            }
        }

        private bool InsertMusicAlbum(Music music, List album)
        {
            try
            {
                if (music.User.Id == album.User.Id)
                {
                    DAO_List listDao = Dao as DAO_List;
                    listDao.AddMusic(music,album);
                    return true;
                }
                return false;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                return false;
            }

        }

        private bool InsertMusicPlaylist(Music music, List playlist)
        {
            try
            {
                DAO_List listDao = Dao as DAO_List;
                listDao.AddMusic(music, playlist);
                return true;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                return false;
            }
        }
    }
}