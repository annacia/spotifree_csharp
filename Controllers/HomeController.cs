using NHibernate;
using NHibernate.Cfg;
using Spotifree.Helper;
using System;
using System.Web.Mvc;

namespace Spotifree.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //Recupera a conexao
            Configuration cfg = NHibernate_Helper.ConfigurationRecover();

            //abre a sessao
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();

            //cria uma nova categoria
            Category cate = new Category();
            cate.Name = "indie";
            cate.Created = new DateTime();

            //realiza uma transação (padrao do nhibernate)
            ITransaction transacao = session.BeginTransaction();

            //salva as alterações
            session.Save(cate);
            transacao.Commit();

            //fecha a sessao
            session.Close();

            return View();
        }
    }
}
