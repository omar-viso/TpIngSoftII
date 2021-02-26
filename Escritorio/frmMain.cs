using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;

namespace Escritorio
{
    public partial class frmMain : Form
    {
        private readonly IEmpleadoService empleadoService;
        private readonly IClienteService clienteService;
        private readonly IAppContext appContext;
        private readonly IAppContext2 appContext2;


        public frmMain(IEmpleadoService empleadoService, IClienteService clienteService, IAppContext appContext, IAppContext2 appContext2)
        {
            this.appContext = appContext;
            this.empleadoService = empleadoService;
            this.clienteService = clienteService;
            this.appContext2 = appContext2;
            InitializeComponent();
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fl = appContext2.Contenedor.GetInstance<frmLogin>();
            fl.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }


        

        private void Clientes_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(SubMenuClientes);
        }

        private void Tareas_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(SubMenuTareas);
        }

        private void Proyectos_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(SubMenuProyectos);
        }

        private void Empleados_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(SubMenuEmpleados);
        }

        private void Perfiles_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(SubMenuPerfiles);
        }

        private void Informes_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(SubMenuInformes);
        }

        private void Liquidacion_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(SubMenuLiquidacion);
        }

        private void Menu_lateral_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VerListaClientes_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            if (this.appContext.EmpleadoRolID == Constantes.Rol.Supervisor)
            {
                this.Perfiles.Visible = false;
                this.Clientes.Visible = false;
            }
            if (this.appContext.EmpleadoRolID == Constantes.Rol.Empleado)
            {
                this.Clientes.Visible = false;
                this.Proyectos.Visible = false;
                this.Empleados.Visible = false;
                this.Perfiles.Visible = false;
                this.Informes.Visible = false;
                this.Liquidacion.Visible = false;
            }
        }

       
    }


}
