using System;
using System.Web;
using System.ComponentModel;
using Spotifree.Helper;
using System.Collections.Generic;

namespace Spotifree
{
    public class Music : Music_Abstract
    {
        private Dictionary dicHelper;

        public Dictionary DicHelper { get => dicHelper; set => dicHelper = value; }

        private Music dictionaryToModel(Dictionary<string, string> data)
        {
            Music newMusic = new Music();
            string category = this.dicHelper.getString("idCategory", data);
            //newMusic.Category = this.Category.getById(category);

            string user = this.dicHelper.getString("idUser", data);
            //newMusic.User = this.User.getById(user);

            newMusic.Dir_art = this.dicHelper.getString("art", data);
            newMusic.Dir_music = this.dicHelper.getString("music", data);
            newMusic.Name = this.dicHelper.getString("name", data);

            newMusic.Id = Int32.Parse(
                this.dicHelper.getString("id", data)
            );

            return newMusic;
            
        }

        public bool upload(Dictionary<string, string> data)
        {
            bool status = true; 
            try
            {
                Music newMusic = this.dictionaryToModel(data);
                int musicId = newMusic.Id;

                DateTime datetime = new DateTime();
                string date = datetime.ToString();

                if (musicId > 0)
                {
                    newMusic.Modified = date;
                    //this.DaoMusic.update(newMusic);

                    return status;
                }

                newMusic.Created = date;
                //this.DaoMusic.insert(newMusic);
            } 
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }

        public bool delete()
        {
            bool status = true;
            try
            {
               // this.DaoMusic.remove(this.Id);
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