using Autofac;
using Food.Application.Interfaces;
using Food.Persistence.EF;
using Food.Persistence.EF.Foods;

namespace Ingredient.Api.Configs
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                    .As<IUnitOfWork>()
                    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(FoodRepository).Assembly)
                    .AssignableTo<IRepository>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}
