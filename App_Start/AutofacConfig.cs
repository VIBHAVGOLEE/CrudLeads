using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using CrudLeads.Application.Interfaces;
using CrudLeads.Application.Mapping;
using CrudLeads.Domain.Interfaces;
using CrudLeads.Infrastructure.Data;
using CrudLeads.Infrastructure.Services;
using CrudLeads.Infrastructure;

namespace CrudLeads
{
    /// <summary>
    /// Autofac dependency injection configuration.
    /// </summary>
    public static class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ApplicationDbContext>()
                .AsSelf()
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();

            builder.Register(c =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<LeadMappingProfile>();
                });
                return config.CreateMapper();
            }).As<IMapper>().SingleInstance();

            builder.RegisterType<LeadService>()
                .As<ILeadService>()
                .InstancePerRequest();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
