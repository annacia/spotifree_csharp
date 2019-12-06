using Spotifree.DAO;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.Mapper
{
    public class Mapper_Category : Mapper_Abstract, Mapper_Interface
    {
        public Mapper_Category()
        {
            Dao = new DAO_Category();
            Model = new Category();
        }

        public override void DictionaryToModel(Dictionary<string, string> data)
        {
            Category newCategory = new Category();
            newCategory.Name = this.DicHelper.GetString("name", data);
            
            string id = this.DicHelper.GetString("id", data);

            if (id != "")
            {
                newCategory.Id = Int32.Parse(id);
            }

            this.Model = newCategory;
        }

        public bool Register()
        {
            bool status = true;
            try
            {
                Category category = Model as Category;
                category.Created = DateTime.Now;
                Model = category;
                Dao.Insert(category);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }

        public bool Update()
        {
            bool status = true;
            try
            {
                Category category = Model as Category;
                Category categoryUpdate = Dao.SearchById(category.Id) as Category;

                categoryUpdate.Modified = DateTime.Now;
                categoryUpdate.Name = category.Name;
                Model = categoryUpdate;

                Dao.Update(categoryUpdate);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                status = false;
            }

            return status;
        }

        public Model_Abstract Load(int id)
        {
            return Dao.SearchById(id) as Category;
        }
        public void SetModelById(int id)
        {
            this.Model = this.Load(id);
        }

        public IList<Category> GetAll()
        {
            DAO_Category select = new DAO_Category();
            return select.FetchAll();
        }

        public void Validate(Category categoria)
        {
            if (string.IsNullOrEmpty(categoria.Name) || (categoria.Name.Length == 0))
            {
                throw new Exception("Nome é obrigatório");
            }
        }

    }
}