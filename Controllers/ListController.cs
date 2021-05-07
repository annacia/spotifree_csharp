using Newtonsoft.Json.Linq;
using Spotifree.Mapper;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spotifree.Controllers
{
    public class ListController : ApiController
    {
        // GET: api/List/
        [Authorize]
        public IHttpActionResult Get(int id)
        {

            Mapper_List mapper = new Mapper_List();
            List retorno = (List) mapper.FetchOne(id);
            
            return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
        }

        // POST: api/List
        [Authorize]
        public IHttpActionResult Post([FromBody]List value)
        {
            try
            {
                Mapper_User mapperUser = new Mapper_User();
                Mapper_List mapper = new Mapper_List();
                Model_Abstract user = mapperUser.Load(value.Fk_User);
                //mapper.Validate(value);
                value.User = user as User;
                mapper.Model = value;
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

        // PUT: api/List/5
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody]List value)
        {
            try
            {
                value.Id = id;
                Mapper_List update = new Mapper_List();
                //update.validate(value);
                update.Model = value;
                update.Update();

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, value));
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


        [HttpPost]
        [ActionName("insert_music")]
        [Route("id/{idList:int}")]
        [Authorize]
        public IHttpActionResult InsertMusic(int idList, [FromBody] JObject data)
        {
            try
            {
                int idMusic = Int32.Parse(data.GetValue("id_music").ToString());

                Mapper_List mapper = new Mapper_List();
                mapper.Model = mapper.Load(idList);

                Mapper_Music mapperMusic = new Mapper_Music();
                Music music = mapper.Load(idMusic) as Music;

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

        // DELETE: api/List/5
        [Authorize]
        public void Delete(int id)
        {
            Mapper_List delete = new Mapper_List();
            delete.Model = delete.Load(id);
            delete.Delete();
        }

        public IHttpActionResult GetByUser(int id)
        {
            Mapper_List list = new Mapper_List();
            Mapper_User mapperUser = new Mapper_User();
            User user = mapperUser.Load(id) as User;

            IList<List> retorno = list.GetByUser(user);

            return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
        }
    }
}
