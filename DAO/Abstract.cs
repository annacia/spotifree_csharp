using NHibernate;
using NHibernate.Cfg;
using Spotifree.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.DAO
{
    public class DAO_Abstract
    {
        private ISession session;

        public DAO_Abstract()
        {
            this.session = NHibernate_Helper.OpenSession();
        }
        public void Insert(Object model)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Save(model);
            transaction.Commit();
        }

        public void InsertObject(Object model)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Save(model);
            transaction.Commit();
        }

        public object SearchById(int id, Object model)
        {
            return session.Get<Object>(id);
        }

        public void Update(Object model)
        {
            ITransaction transaction = session.BeginTransaction();
            this.session.Merge(model);
            transaction.Commit();
        }

        public void UpdateById(int id, Object model)
        {
            Object newModel = this.SearchById(id, model);
            this.Update(model);
        }

        public void DeleteById(int id, Object model)
        {
            Object newModel = this.SearchById(id, model);
            this.Delete(newModel);
        }

        public void Delete(Object model)
        {
            ITransaction transaction = session.BeginTransaction();

            session.Delete(model);
            transaction.Commit();
        }
    }
}