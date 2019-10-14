using NHibernate;
using NHibernate.Cfg;
using Spotifree.Helper;
using System;
using System.Web.Mvc;
using Spotifree.Mapper;

namespace Spotifree.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";          

            return View();
        }
    }
}
