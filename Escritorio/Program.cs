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
using Escritorio.Interfaces;
using Escritorio.Entities;

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

            //UnityConfig.RegisterComponents();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfile>();

            });

            UnityContainer container = new UnityContainer();
            container.RegisterType(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>));
            container.RegisterType(typeof(IDbFactory<>), typeof(DbFactory<>));
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IAppContext, TpIngSoftII.Models.AppContext>();
            container.RegisterType(typeof(IEntityAppServiceBase<,>), typeof(EntityAppServiceBase<,>));
            container.RegisterType<IEmpleadoService, EmpleadoService>();
            container.RegisterType<IClienteService, ClienteService>();
            container.RegisterType<IReporteService, ReporteService>();
            container.RegisterType<IMainInicial, MainInicial>();
            container.RegisterType<IForms, Forms>();

            var obj = container.Resolve<IMainInicial>();

            obj.Run();
            //obj.;

            //Application.Run(new frmLogin());
            //var container = Bootstrap();
            //Application.Run(container.GetInstance<frmLogin>());

            //Application.Run(new MainInicial());
        }

        private static Container Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance:
            //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Singleton);
            container.Register<IEmpleadoService, EmpleadoService>();
            //container.Register<typeof(IEntityAppServiceBase),typeof(EntityAppServiceBase)>();

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
