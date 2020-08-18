using System.Web.Http;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models;
using TpIngSoftII.Repositories;
using TpIngSoftII.Services;
using Unity;
using Unity.WebApi;

namespace TpIngSoftII
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProyectoService, ProyectoService>();
            container.RegisterType(typeof(IEntityAppServiceBase<,>), typeof(EntityAppServiceBase<,>));
            container.RegisterType(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>));
            container.RegisterType(typeof(IDbFactory<>), typeof(DbFactory<>));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}
