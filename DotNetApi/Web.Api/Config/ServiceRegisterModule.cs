using Autofac;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Infrastructure.Repository;
using Web.Api.Service.Services;

namespace Web.Api.Config
{
    public class ServiceRegisterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserTestRepository>().As<IUserTestRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
          
        }
    }
}