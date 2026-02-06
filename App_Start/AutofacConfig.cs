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
                    cfg.AddProfile<BrokerMappingProfile>();
                    cfg.AddProfile<LeadMappingProfile>();
                    cfg.AddProfile<ActivityTypeMappingProfile>();
                });
                return config.CreateMapper();
            }).As<IMapper>().SingleInstance();

            builder.RegisterType<BrokerService>()
                .As<IBrokerService>()
                .InstancePerRequest();

            builder.RegisterType<LeadService>()
                .As<ILeadService>()
                .InstancePerRequest();

            builder.RegisterType<ActivityTypeService>()
                .As<IActivityTypeService>()
                .InstancePerRequest();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
