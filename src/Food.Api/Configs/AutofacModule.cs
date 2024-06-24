using Autofac;
using Food.Application.Interfaces;
using Food.Persistence.EF;

namespace Ingredient.Api.Configs
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                    .As<IUnitOfWork>()
                    .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(UnitRepository).Assembly)
            //        .AssignableTo<IRepository>()
            //        .AsImplementedInterfaces()
            //        .InstancePerLifetimeScope();
        }
    }
}
