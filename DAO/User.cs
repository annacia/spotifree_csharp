using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.DAO
{
    public class DAO_User : DAO_Abstract
    {
        private User model;

        public User Model { get => model; set => model = value; }

        public override void Insert()
        {
            ITransaction transaction = Session.BeginTransaction();
            Session.Save(Model);
            transaction.Commit();
        }

        public override void SearchById(int id)
        {
            Model = Session.Get<User>(id);
        }

        public override void Update()
        {
            ITransaction transaction = Session.BeginTransaction();
            this.Session.Merge(Model);
            transaction.Commit();
        }

        public override void UpdateById(int id)
        {
            this.SearchById(id);
            this.Update();
        }

        public override void DeleteById(int id)
        {
            this.SearchById(id);
            this.Delete();
        }

        public override void Delete()
        {
            ITransaction transaction = Session.BeginTransaction();

            Session.Delete(Model);
            transaction.Commit();
        }
    }
}