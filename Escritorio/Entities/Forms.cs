using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escritorio.Interfaces;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Services;

namespace Escritorio.Entities
{
    public class Forms : IForms
    {
        private readonly IEmpleadoService empleadoService;
        private readonly IClienteService clienteService;
        private readonly IAppContext appContext;

        public Forms(IEmpleadoService empleadoService, IClienteService clienteService, IAppContext appContext)
        {
            this.empleadoService = empleadoService;
            this.clienteService = clienteService;
            this.appContext = appContext;
        }

        public frmLogin GetFrmLogin()
        {
            return new frmLogin(this.empleadoService, this.clienteService, this.appContext);
        }

    }
}
