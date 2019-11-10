using Spotifree.DAO;
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
        public IHttpActionResult Get(int id)
        {
            DAO_User select = new DAO_User();
            User retorno = (User)select.SearchById(id);

            return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]User value)
        {
            try
            {
                Mapper_User mapper = new Mapper_User();
                mapper.validate(value);
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
        public IHttpActionResult Put(int id, [FromBody]User value)
        {
            try
            {
                value.Id = id;
                Mapper_User update = new Mapper_User();
                update.validate(value);
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
        public void Delete(int id)
        {
            Mapper_User delete = new Mapper_User();
            delete.Model = delete.Load(id);
            delete.Delete();
        }
    }
}
