using NHibernate;
using NHibernate.Cfg;
using Spotifree.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.DAO
{
    public abstract class DAO_Abstract
    {
        private ISession session;
        public ISession Session { get => session; set => session = value; }

        public DAO_Abstract()
        {
            this.Session = NHibernate_Helper.OpenSession();
        }

        public abstract void Insert();

        public abstract void SearchById(int id);

        public abstract void Update();

        public abstract void UpdateById(int id);

        public abstract void DeleteById(int id);

        public abstract void Delete();
    }
}