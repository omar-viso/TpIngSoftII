using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escritorio.Interfaces;
using TpIngSoftII.Interfaces.Services;

namespace Escritorio.Entities
{
    public class Forms : IForms
    {
        private readonly IEmpleadoService empleadoService;
        private readonly IClienteService clienteService;

        public Forms(IEmpleadoService empleadoService, IClienteService clienteService)
        {
            this.empleadoService = empleadoService;
            this.clienteService = clienteService;
        }

        public frmLogin GetFrmLogin()
        {
            return new frmLogin(this.empleadoService, this.clienteService);
        }

    }
}
