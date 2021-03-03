using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.Entities;
using TpIngSoftII.Interfaces;
using SimpleInjector;

namespace Escritorio
{
    public partial class frmLogin : Form
    {
        private readonly Container container;
        private readonly IAppContext appContext;

        public frmLogin(Container container, IAppContext appContext)
        {
            this.appContext = appContext;
            this.container = container;
            InitializeComponent();
        }
        //Connection String
        string cs = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MyDatabase.mdf;Integrated Security=True;";
        //btn_Submit Click event
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Por favor complete nombre de usuario y contraseña");
                return;
            }
            try
            {   // PASAR NO TRACKEADO!!!!
                var empleado = this.container.GetInstance<IEmpleadoService>().GetByIdAsNoTracking(this.container.GetInstance<IEmpleadoService>().ValidarCredenciales(new LoginRequest { Username = txt_UserName.Text, Password = txt_Password.Text }));

                if (empleado != null)
                {
                    MessageBox.Show("Login Exitoso!");
                    this.Hide();

                    this.appContext.SetEmpleado(empleado.ID);
                    this.appContext.SetEmpleadoRol(empleado.RolID);

                    var fm = this.container.GetInstance<frmMain>();
                    //frmMain fm = new frmMain(empleadoService, clienteService, appContext, appContext2);
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login fallido!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
    }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
