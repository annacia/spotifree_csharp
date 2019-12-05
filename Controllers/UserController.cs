using Spotifree.Mapper;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spotifree.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        //public IEnumerable<string> GetAll()
        //{

        //}

        // GET: api/User/5
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            Mapper_User mapper = new Mapper_User();
            User retorno = (User)mapper.Load(id);

            return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]User value)
        {
            try
            {
                Mapper_User mapper = new Mapper_User();
                mapper.Validate(value);
                mapper.Model = value;
                mapper.Register();

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, mapper.Model));
            }
            catch(Exception e)
            {
                var retorno = new
                {
                    Erro = e.Message
                };

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
            }
        }

        // PUT: api/User/5
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody]User value)
        {
            try
            {
                value.Id = id;
                Mapper_User update = new Mapper_User();
                update.Validate(value);
                update.Model = value;
                update.Update();

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, value));
            }catch (Exception e)
            {
                var retorno = new
                {
                    Erro = e.Message
                };

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
            }
        }

        // DELETE: api/User/5
        [Authorize]
        public void Delete(int id)
        {
            Mapper_User delete = new Mapper_User();
            delete.Model = delete.Load(id);
            delete.Delete();
        }
    }
}
