using Spotifree.Helper;
using Spotifree.Mapper;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Spotifree.Controllers
{
    public class MusicController : ApiController
    {
        private HttpPostedFile postedFile;
        private IDictionary<string, object> json;
        private File file;

        public File File { get => file; set => file = value; }

        // GET: api/Music
        //public IEnumerable<string> Get()
        //{
        //   return new string[] { "value1", "value2" };
        //}

        // GET: api/Music/5
        public IHttpActionResult Get(int id)
        {
            Mapper_Music select = new Mapper_Music();
            Music retorno = (Music)select.FetchOne(id);

            return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
        }

        // POST: api/Music
        public async Task<IHttpActionResult> PostAsync()
        {
            try
            {
                File = new File();
                File.Request = HttpContext.Current.Request;
                File.Type = "audio/mpeg";
                File.FileValidate("É necessário enviar um arquivo de audio");

                var jsonRequest = await Request.Content.ReadAsMultipartAsync();
                var json_serializer = new JavaScriptSerializer();
                this.json = (IDictionary<string, object>)json_serializer.DeserializeObject(await jsonRequest.Contents[0].ReadAsStringAsync());

                Mapper_Music mapper = new Mapper_Music();
                Music music = new Music();
                Mapper_User user = new Mapper_User();
                Mapper_Category category = new Mapper_Category();

                music.Name = (string)json["music_name"];
                music.User = (User)user.Load((int)json["fk_user"]);
                music.Category = (Category)category.Load((int)json["fk_category"]);
                mapper.Validate(music);

                File.Directory.ServerPath = "~/Data/Musicas/";
                File.Directory.Path = music.User.Id + "/";
                File.ConfigurePath(music.Name);
                File.Upload();

                music.Dir_music = File.FullPath;
                mapper.Model = music;
                mapper.Register();

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, mapper.Model));

            }
            catch (Exception e)
            {
                var retorno = new
                {
                    Erro = e.Message
                };

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
            }
        }

        // PUT: api/Music/5
        public async Task<IHttpActionResult> Put(int id)
        {
            try
            {
                var jsonRequest = await Request.Content.ReadAsMultipartAsync();
                var json_serializer = new JavaScriptSerializer();
                this.json = (IDictionary<string, object>)json_serializer.DeserializeObject(await jsonRequest.Contents[0].ReadAsStringAsync());

                Mapper_Category category = new Mapper_Category();
                Mapper_Music mapper = new Mapper_Music();
                Music music = mapper.Load(id) as Music;

                music.Name = (string)json["music_name"];
                music.Category = (Category)category.Load((int)json["fk_category"]);
                
                mapper.Model = music;
                mapper.Update();

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, music));
            }
            catch (Exception e)
            {
                var retorno = new
                {
                    Erro = e.Message
                };

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
            }
        }

        // DELETE: api/Music/5
        public void Delete(int id)
        {
            Mapper_Music delete = new Mapper_Music();
            delete.Model = delete.Load(id);
            delete.Delete();
        }

    }
}
