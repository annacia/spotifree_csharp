using NHibernate;
using NHibernate.Cfg;
using Spotifree.DAO;
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


            /** Exemplo de inserção e busca
                DAO_Category dao = new DAO_Category();
                DAO_Category daoCate = new DAO_Category();
                daoCate.SearchById(3);
                Category category = daoCate.Model;

                DAO_User daoUser = new DAO_User();
                daoUser.SearchById(1);
                User user = daoUser.Model;

                Music music = new Music();
                music.Name = "teste";
                music.Dir_art = "caminho_png_musica";
                music.Dir_music = "caminho_mp3_musica";
                music.Created = new DateTime();
                music.Category = category;
                music.User = user;

                DAO_Music daoMusic = new DAO_Music();
                daoMusic.Model = music;
                daoMusic.Insert();
            */

            DAO_User daoUser = new DAO_User();
            daoUser.SearchById(1);
            User user = daoUser.Model;

            //nao esta funcionando a insercao na lista
            List list = new List();
            list.Name = "playlist_teste";
            list.Is_album = 0;
            list.Created = new DateTime();
            list.User = user;

            return View();
        }
    }
}
