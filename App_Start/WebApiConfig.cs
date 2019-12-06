using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Spotifree
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da 
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            //config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "Music",                                           // Route name
                "api/Music/GetByName/{name}",                            // URL with parameters
                new { controller = "Music", action = "GetMusicByName" }  // Parameter defaults
            );

            config.Routes.MapHttpRoute(
                "MusicById",                                           // Route name
                "api/Music/GetById/{id}",                            // URL with parameters
                new { controller = "Music", action = "Get" }  // Parameter defaults
            );

            config.Routes.MapHttpRoute(
                "List",                                           // Route name
                "api/List/GetByUser/{id}",                        // URL with parameters
                new { controller = "List", action = "GetByUser" } // Parameter defaults
            );

            config.Routes.MapHttpRoute(
                "ListById",                                           // Route name
                "api/List/GetById/{id}",                        // URL with parameters
                new { controller = "List", action = "Get" } // Parameter defaults
            );

            config.Routes.MapHttpRoute(
                "MusicByUser",                                           // Route name
                "api/Music/GetByUser/{id}",                        // URL with parameters
                new { controller = "Music", action = "GetByUser" } // Parameter defaults
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
