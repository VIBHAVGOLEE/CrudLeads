using System.Web.Http;
using Swashbuckle.Application;

namespace CrudLeads
{
    public static class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "CrudLeads API - Lead CRUD");
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.DescribeAllEnumsAsStrings();
            })
            .EnableSwaggerUi(c =>
            {
                c.DocumentTitle("CrudLeads API");
            });
        }

        private static string GetXmlCommentsPath()
        {
            var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            var binPath = System.IO.Path.Combine(basePath, "bin", "CrudLeads.XML");
            return System.IO.File.Exists(binPath) ? binPath : System.IO.Path.Combine(basePath, "CrudLeads.XML");
        }
    }
}
