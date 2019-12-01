using Newtonsoft.Json;
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
        public IHttpActionResult Get()
        {
            Mapper_List mapper = new Mapper_List();
            List retorno = (List) mapper.Load(1);

            return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
        }

    }
}