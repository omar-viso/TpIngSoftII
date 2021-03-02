using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpIngSoftII;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Mapping;
using TpIngSoftII.Services;
using Unity;

using SimpleInjector;
using SimpleInjector.Diagnostics;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Repositories;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Models;
using TpIngSoftII.Reportes;

namespace Escritorio
{
    static class Program
    {

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfile>();

            });

            var container = Bootstrap();
            var appContext = container.GetInstance<IAppContext2>();
            appContext.SetContenedor(container);

            Application.Run(container.GetInstance<frmLogin>());

        }

        private static Container Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance:
            container.Register<IEmpleadoService, EmpleadoService>(Lifestyle.Transient);
            container.Register<IClienteService, ClienteService>(Lifestyle.Transient);
            container.Register<ITareaService, TareaService>(Lifestyle.Transient);
            container.Register<IHorasTrabajadasService, HorasTrabajadasService>(Lifestyle.Transient);
            container.Register<IProyectoService, ProyectoService>(Lifestyle.Transient);
            container.Register<IPerfilService, PerfilService>(Lifestyle.Transient);
            container.Register<IReporteService, ReporteService>(Lifestyle.Transient);
            container.Register(typeof(IEntityAppServiceBase<,>), typeof(EntityAppServiceBase<,>), Lifestyle.Transient);
            container.Register(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>), Lifestyle.Transient);
            container.Register(typeof(IDbFactory<>), typeof(DbFactory<>), Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Transient);
            container.Register<IAppContext, TpIngSoftII.Models.AppContext>(Lifestyle.Singleton);
            container.Register<IAppContext2, AppContext2>(Lifestyle.Singleton);
            container.Register<ISevice, Service>(Lifestyle.Transient);

            AutoRegisterWindowsForms(container);

            container.Verify();

            return container;
        }

        private static void AutoRegisterWindowsForms(Container container)
        {
            var types = container.GetTypesToRegister<Form>(typeof(Program).Assembly);

            foreach (var type in types)
            {
                var registration =
                    Lifestyle.Transient.CreateRegistration(type, container);

                registration.SuppressDiagnosticWarning(
                    DiagnosticType.DisposableTransientComponent,
                    "Forms should be disposed by app code; not by the container.");

                container.AddRegistration(type, registration);
            }
        }
    }
}
