    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Escritorio.Interfaces;
using TpIngSoftII.Interfaces.Services;

namespace Escritorio
{
    
    class MainInicial : IMainInicial
    {
        private readonly IEmpleadoService empleadoService;
        private readonly IClienteService clienteService;
        private readonly IReporteService reporteService;
        private readonly IForms forms;


        public MainInicial(IEmpleadoService empleadoService, IClienteService clienteService, IReporteService reporteService, IForms forms)
        {
            this.empleadoService = empleadoService;
            this.clienteService = clienteService;
            this.reporteService = reporteService;
            this.forms = forms;
        }

        public void Run()
        {
            //Application.Run(new frmLogin(empleadoService, clienteService));
            Application.Run(forms.GetFrmLogin());

        }
    }
}
