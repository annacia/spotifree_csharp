using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using Spotifree.DAO;
using Spotifree.Helper;
using Spotifree.Mapper;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Spotifree.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            string json = @"{""name"":""cams"",""email"":""cams@cams.com"",""password"":""123456"",""password_repeat"":""123456""}";
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            Mapper_User mapper = new Mapper_User();
            mapper.DictionaryToModel(values);
            mapper.Register();


            /**insercao Many to Many
            DAO_List daoList = new DAO_List();
            List list = (List) daoList.SearchById(1);

            DAO_Music daoMusic = new DAO_Music();
            Music music = (Music) daoMusic.SearchById(1);

            daoList.AddMusic(music, list);
            **/

            /**Insercao de playlist funcionando
            Playlist playlist = new Playlist();
            playlist.Name = "playlist1";
            playlist.Created = new DateTime();
            playlist.User = (User) daoUser.SearchById(1);

            List list = playlist.PlaylistToList(playlist);
            DAO_List daoList = new DAO_List();
            daoList.Insert(list);
            **/

            /**Insercao e busca funcionando
            DAO_Category daoCate = new DAO_Category();
            Model_Abstract category = daoCate.SearchById(3);

            DAO_User daoUser = new DAO_User();
            Model_Abstract user = daoUser.SearchById(1);

            Music music = new Music();
            music.Name = "teste2";
            music.Dir_art = "caminho_png_musica2";
            music.Dir_music = "caminho_mp3_musica2";
            music.Created = new DateTime();
            music.Category = (Category) category;
            music.User = (User) user;

            DAO_Music daoMusic = new DAO_Music();
            daoMusic.Insert(music);
            **/
            return View();
        }
    }
}
