using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleInjector;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;

namespace Escritorio
{
    public partial class frmMain : Form
    {

        private readonly IAppContext appContext;
        private readonly Container container;


        public frmMain(IAppContext appContext, Container container)
        {
            this.appContext = appContext;
            this.container = container;
            InitializeComponent();
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fl = container.GetInstance<frmLogin>();
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



        #region Ver Submenues
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

        #endregion

       

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Muestra botones segun roles
            if (this.appContext.EmpleadoRolID == Constantes.Rol.Supervisor)
            {
                this.PerfilesButton.Visible = false;
                this.ClientesButton.Visible = false;
            }
            if (this.appContext.EmpleadoRolID == Constantes.Rol.Empleado)
            {
                this.ClientesButton.Visible = false;
                this.ProyectosButton.Visible = false;
                this.EmpleadosButton.Visible = false;
                this.PerfilesButton.Visible = false;
                this.InformesButton.Visible = false;
                this.LiquidacionButton.Visible = false;
            }
        }

        private Form activeForm = null;

        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            //ChildForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(ChildForm);
            panelChildForm.Tag = ChildForm;
            panelChildForm.Visible = true;
            ChildForm.Show();
        }

        #region  Acciones de los Botones del Submenu
        private void VerListaClientes_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmClienteLista>());
        }

        private void AgregarProyectosButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmProyectosAgregar>());
        }

        private void AgregarPerfilesButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmPerfilesAgregar>());
        }

        private void CargarHorasButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmTareaCargaHoras>());
        }

        private void AgregarTareasButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmTareaAgregar>());
        }

        private void AgregarClientesButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmClienteAgregar>());
        }

        private void AgregarEmpleadosButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmEmpleadoAgregar>());
        }

        private void HsObSemanaButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmInformeHsObSemana>());
        }

        private void HsTrabEmpleadoButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmInformeHsTrabPorEmpl>());
        }

        private void HsTrabProyectoButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmInformeHsTrabPorProyect>());
        }

        private void HsAdeudadasButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmInformeHsAdeudadas>());
        }

        private void LiquidarButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmLiquidacion>());
        }

        private void VerListaPerfilesButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmPerfilLista>());
        }

        private void VerListaProyectosButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmProyectoLista>());
        }

        private void VerListaTareasButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmTareaLista>());
        }

        private void VerListaEmpleadosButton_Click(object sender, EventArgs e)
        {
            openChildForm(container.GetInstance<FrmEmpleadoLista>());
        }
    }

    #endregion


}
