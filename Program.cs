using NHibernate.Cfg;
using System;
using Spotifree.Helper;
using NHibernate;

namespace Spotifree
{
    public class Program
    {


        static void Main(string[] args)
        {
            Configuration cfg = NHibernate_Helper.ConfigurationRecover();
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();

            Category cate = new Category();
            cate.Name = "jrock";
            cate.Created = new DateTime();

            ITransaction transacao = session.BeginTransaction();
            session.Save(cate);
            transacao.Commit();
            session.Close();
            Console.WriteLine("Hello World!");
        }
    }
}