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
                    cfg.AddProfile<FollowUpMappingProfile>();
                    cfg.AddProfile<StatusMappingProfile>();
                    cfg.AddProfile<LeadSourceMappingProfile>();
                    cfg.AddProfile<CustomerMappingProfile>();
                    cfg.AddProfile<RoleMappingProfile>();
                    cfg.AddProfile<UserMappingProfile>();
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

            builder.RegisterType<FollowUpService>()
                .As<IFollowUpService>()
                .InstancePerRequest();

            builder.RegisterType<StatusService>()
                .As<IStatusService>()
                .InstancePerRequest();

            builder.RegisterType<LeadSourceService>()
                .As<ILeadSourceService>()
                .InstancePerRequest();

            builder.RegisterType<CustomerService>()
                .As<ICustomerService>()
                .InstancePerRequest();

            builder.RegisterType<AuthService>()
                .As<IAuthService>()
                .InstancePerRequest();

            builder.RegisterType<RoleService>()
                .As<IRoleService>()
                .InstancePerRequest();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerRequest();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
