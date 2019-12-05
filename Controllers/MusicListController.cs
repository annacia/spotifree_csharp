using Newtonsoft.Json.Linq;
using Spotifree.Mapper;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spotifree.Controllers
{
    public class MusicListController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] JObject data)
        {
            try
            {
                int addMusic = Int32.Parse(data.GetValue("add_music").ToString());
                int idMusic = Int32.Parse(data.GetValue("id_music").ToString());
                int idList = Int32.Parse(data.GetValue("id_list").ToString());

                Mapper_List mapper = new Mapper_List();
                Mapper_Music mapperMusic = new Mapper_Music();
                Music music = mapperMusic.Load(idMusic) as Music;
                mapper.SetModelById(idList);
                
                if (addMusic == 0)
                {
                    mapper.RemoveMusic(music);
                    return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, mapper.Model));
                }
                
                mapper.InsertMusic(music);
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

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}