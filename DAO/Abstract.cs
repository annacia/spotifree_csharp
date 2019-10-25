using NHibernate;
using NHibernate.Cfg;
using Spotifree.Helper;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.DAO
{
    public abstract class DAO_Abstract
    {
        private ISession session;
        
        private Model_Abstract model;
        
        public ISession Session { get => session; set => session = value; }
        
        public Model_Abstract Model { get => model; set => model = value; }

        public DAO_Abstract()
        {
            this.Session = NHibernate_Helper.OpenSession();
        }

        public Model_Abstract Insert(Model_Abstract model)
        {
            ITransaction transaction = Session.BeginTransaction();
            Session.Save(model);
            transaction.Commit();

            return model;
        }

        public abstract Model_Abstract SearchById(int id);

        public Model_Abstract Update(Model_Abstract model)
        {
            ITransaction transaction = Session.BeginTransaction();
            this.Session.Merge(model);
            transaction.Commit();

            return model;
        }

        public Model_Abstract UpdateById(int id)
        {
            Model_Abstract model = this.SearchById(id);
            this.Update(model);

            return model;
        }

        public void DeleteById(int id)
        {
            Model_Abstract model = this.SearchById(id);
            this.Delete(model);
        }

        public void Delete(Model_Abstract model)
        {
            ITransaction transaction = Session.BeginTransaction();

            this.Session.Delete(model);
            transaction.Commit();
        }
    }
}