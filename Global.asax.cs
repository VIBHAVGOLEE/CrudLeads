using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using CrudLeads.Infrastructure.Data;
using CrudLeads.Migrations;

namespace CrudLeads
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            AutofacConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
