using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Spotifree.Helper
{
    public class NHibernate_Helper
    {
        private static ISessionFactory factory =
        NHibernate_Helper.CreateSessionFactory();

        public static Configuration ConfigurationRecover()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            return cfg;
        }

        public static ISession OpenSession()
        {
            Configuration cfg = NHibernate_Helper.ConfigurationRecover();
            ISessionFactory fabrica = cfg.BuildSessionFactory();
            return fabrica.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            Configuration cfg = NHibernate_Helper.ConfigurationRecover();
            return cfg.BuildSessionFactory();
        }

        public static ISession OpenSessionFactory()
        {
            return factory.OpenSession();
        }
    }
}