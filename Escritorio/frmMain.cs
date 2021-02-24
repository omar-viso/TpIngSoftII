using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fl = new frmLogin();
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

        private void Menu_lateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
