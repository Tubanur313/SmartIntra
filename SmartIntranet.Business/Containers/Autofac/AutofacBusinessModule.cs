using Autofac;
using SmartIntranet.Business.Concrete;
using SmartIntranet.Business.DependencyResolvers.Automapper;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using SmartIntranet.DataAccess.Interfaces;
using System.Reflection;
using Module = Autofac.Module;

namespace SmartIntranet.Business.Containers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mvcAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(IntranetContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterGeneric(typeof(EfGenericRepository<>)).As(typeof(IGenericDal<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericManager<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(mvcAssembly, repoAssembly, serviceAssembly).Where(x=>x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(mvcAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Manager"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
