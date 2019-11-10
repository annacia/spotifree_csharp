using Newtonsoft.Json;
using Spotifree.DAO;
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
            DAO_List select = new DAO_List();
            List retorno = (List) select.SearchById(1);

            return ResponseMessage(Request.CreateResponse<Object>(HttpStatusCode.OK, retorno));
        }

    }
}