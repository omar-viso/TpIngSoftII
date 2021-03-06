﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models;
using TpIngSoftII.Repositories;
using TpIngSoftII.Services;
using Unity;
using Unity.Lifetime;

namespace Escritorio
{
    class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProyectoService, ProyectoService>(new PerResolveLifetimeManager());
            container.RegisterType<IEmpleadoService, EmpleadoService>(new PerResolveLifetimeManager());
            container.RegisterType<ITareaService, TareaService>(new PerResolveLifetimeManager());
            container.RegisterType<IPerfilService, PerfilService>(new PerResolveLifetimeManager());
            container.RegisterType<IHorasTrabajadasService, HorasTrabajadasService>(new PerResolveLifetimeManager());
            container.RegisterType<IClienteService, ClienteService>(new PerResolveLifetimeManager());
            container.RegisterType<IReporteService, ReporteService>(new PerResolveLifetimeManager());

            container.RegisterType(typeof(IEntityAppServiceBase<,>), typeof(EntityAppServiceBase<,>), new PerResolveLifetimeManager());
            container.RegisterType(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>), new PerResolveLifetimeManager());
            container.RegisterType(typeof(IDbFactory<>), typeof(DbFactory<>), new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());
            //container.RegisterType<DbContext, DBGestionDeProyectosContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IAppContext, TpIngSoftII.Models.AppContext>(new HierarchicalLifetimeManager());

            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}
