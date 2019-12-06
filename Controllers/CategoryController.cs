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
    public class CategoryController : ApiController
    {
        // GET: api/User
        public IHttpActionResult Get()
        {
            Mapper_Category mapper = new Mapper_Category();
            IList<Category> retorno = mapper.GetAll();

            return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
        }

        // GET: api/User/5
        public IHttpActionResult Get(int id)
        {
            Mapper_Category mapper = new Mapper_Category();
            Category retorno = (Category)mapper.Load(id);

            return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]Category value)
        {
            try
            {
                Mapper_Category mapper = new Mapper_Category();
                mapper.Validate(value);
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

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]Category value)
        {
            try
            {
                value.Id = id;
                Mapper_Category update = new Mapper_Category();
                update.Validate(value);
                update.Model = value;
                update.Update();

                return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, update.Model));
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

        // DELETE: api/User/5
        public void Delete(int id)
        {
            Mapper_Category delete = new Mapper_Category();
            delete.Model = delete.Load(id);
            delete.Delete();
        }
    }
}

