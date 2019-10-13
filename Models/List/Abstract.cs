using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;
using Spotifree.Helper;

namespace Spotifree
{
    public abstract class List
    {
        private int id;

        private string name;

        private bool isAlbum;

        private string created;

        private string modified;

        private Dictionary dicHelper;

        private User user;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public bool IsAlbum { get => isAlbum; set => isAlbum = value; }
        public string Created { get => created; set => created = value; }
        public string Modified { get => modified; set => modified = value; }
        public User User { get => user; set => user = value; }
        public Dictionary DicHelper { get => dicHelper; set => dicHelper = value; }

        protected List ModelByDic(Dictionary<string, string> data, List list)
        {
            list.Name = this.DicHelper.getString("name", data);
            list.IsAlbum = bool.Parse(
                this.DicHelper.getString("album", data)
            );

            //string user = this.dicHelper.getString("idUser", data);
            //list.User = this.User.getById(user);

            //list.Id = Int32.Parse(
            //    this.dicHelper.getString("id", data)
            //);

            return list;
        }

        protected bool insertList(Dictionary<string, string> data, List list)
        {
            bool status = true;
            try
            {
                List newList = this.ModelByDic(data, list);

                DateTime datetime = new DateTime();
                string date = datetime.ToString();

                //this.DaoList.load(newList);
                int listId = newList.Id;

                if (listId > 0)
                {
                    newList.Modified = date;
                    //this.DaoList.update(newList);

                    return status;
                }

                newList.Created = date;
                //this.DaoList.insert(newList);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }

        protected List addMusic(Music music, List list)
        {
            try
            {
                //this.DaoList.relate(
                //    music,
                //    list
                //);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
            }

            return list;
        }

        protected List removeMusic(Music music, List list)
        {
            try
            {
                //this.DaoList.removeRelate(
                //    music,
                //    list
                //);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
            }

            return list;
        }
        public bool delete()
        {
            bool status = true;

            try
            {
                //this.DaoList.remove(this.Id);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }
    }

}