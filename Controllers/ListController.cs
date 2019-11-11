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
        // GET: api/List
        //public IEnumerable<string> Get()
        //{
         //   return new string[] { "value1", "value2" };
        //}

        // GET: api/List/5
        public IHttpActionResult Get(int id)
        {

            Mapper_List mapper = new Mapper_List();
            List retorno = (List) mapper.Load(id);
            
            return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
        }

        // POST: api/List
        public IHttpActionResult Post([FromBody]List value)
        {
            try
            {
                Mapper_List mapper = new Mapper_List();
                //mapper.validate(value);
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

        // DELETE: api/List/5
        public void Delete(int id)
        {
            Mapper_List delete = new Mapper_List();
            delete.Model = delete.Load(id);
            delete.Delete();
        }
    }
}
