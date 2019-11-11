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

        public bool Register()
        {
            bool status = true;
            try
            {
                List list = Model as List;
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
                List user = Model as List;
                List userUpdate = Dao.SearchById(user.Id) as List;

                userUpdate.Modified = DateTime.Now;
                userUpdate.Name = user.Name;

                Dao.Update(userUpdate);
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