﻿using System;
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

        private void VerListaClientes_Click(object sender, EventArgs e)
        {
            
        }

        private void AgregarProyectosButton_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmProyectosAgregar());
        }
    }


}
