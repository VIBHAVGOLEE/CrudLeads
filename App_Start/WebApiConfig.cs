using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CrudLeads
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new CrudLeads.Infrastructure.Security.JwtHandler());

            SwaggerConfig.Register(config);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
