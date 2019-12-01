using Spotifree.DAO;
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
        private string music_path = "~/Data/Musicas/";
        private HttpPostedFile postedFile;
        private IDictionary<string, object> json;

        // GET: api/Music
        //public IEnumerable<string> Get()
        //{
         //   return new string[] { "value1", "value2" };
        //}

        // GET: api/Music/5
        public IHttpActionResult Get(int id)
        {
            DAO_Music select = new DAO_Music();
            Music retorno = (Music) select.SearchById(id);

            return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
        }

        // POST: api/Music
        public async Task<IHttpActionResult> PostAsync()
        {
            try
            {
                FileValidate();

                var jsonRequest = await Request.Content.ReadAsMultipartAsync();
                var json_serializer = new JavaScriptSerializer();
                this.json = (IDictionary<string, object>)json_serializer.DeserializeObject(await jsonRequest.Contents[0].ReadAsStringAsync());

                Mapper_Music mapper = new Mapper_Music();
                Music musica = new Music();
                DAO_User user = new DAO_User();
                DAO_Category category = new DAO_Category();

                musica.Name = postedFile.FileName;
                musica.User = (User)user.SearchById((int)json["fk_user"]);
                musica.Category = (Category)category.SearchById((int)json["fk_category"]);
                mapper.validate(musica);
                string music_path = this.music_path + musica.User.Id + "/";
                musica.Dir_music = music_path;
                mapper.Model = musica;
                mapper.Register();

                var filePath = HttpContext.Current.Server.MapPath(music_path);
                System.IO.Directory.CreateDirectory(filePath);
                postedFile.SaveAs(filePath + postedFile.FileName);

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, mapper.Model));

            } catch (Exception e)
            {
                var retorno = new
                {
                    Erro = e.Message
                };

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
            }
        }

        // PUT: api/Music/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Music/5
        public void Delete(int id)
        {
            Mapper_Music delete = new Mapper_Music();
            delete.Model = delete.Load(id);
            delete.Delete();
        }

        private void FileValidate()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count < 1)
            {
                throw new Exception("deve ser enviado um arquivo de musica");
            }

            foreach (string file in httpRequest.Files)
            {
                this.postedFile = httpRequest.Files[file];

                if (postedFile.ContentType != "audio/mpeg") {
                    throw new Exception("Arquivo enviado deve ser uma musica"); 
                }
            }

        }
    }
}
