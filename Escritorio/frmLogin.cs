using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.Entities;
using Escritorio.Interfaces;
using TpIngSoftII.Interfaces;

namespace Escritorio
{
    public partial class frmLogin : Form
    {
        private readonly IEmpleadoService empleadoService;
        private readonly IClienteService clienteService;
        private readonly IAppContext appContext;

        public frmLogin(IEmpleadoService empleadoService,
                        IClienteService clienteService, IAppContext appContext)
        {
            this.empleadoService = empleadoService;
            this.clienteService = clienteService;
            this.appContext = appContext;
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
                var empleado = this.empleadoService.GetById(empleadoService.ValidarCredenciales(new LoginRequest { Username = txt_UserName.Text, Password = txt_Password.Text }));
                var cliente = this.clienteService.GetById(4);

                //Create SqlConnection
                //SqlConnection con = new SqlConnection(cs);
                //SqlCommand cmd = new SqlCommand("Select * from tbl_Login where UserName=@username and Password=@password", con);
                //cmd.Parameters.AddWithValue("@username", txt_UserName.Text);
                //cmd.Parameters.AddWithValue("@password", txt_Password.Text);
                //con.Open();
                //SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //adapt.Fill(ds);
                //con.Close();
                //int count = ds.Tables[0].Rows.Count;
                int count =0;
                //if (txt_UserName.Text == "julimanesi94" && txt_Password.Text == "1234")
                //    count = 1;
                //If count is equal to 1, than show frmMain form
                if (empleado != null)
                {
                    MessageBox.Show("Login Exitoso!");
                    this.Hide();
                    // PASAR COMO INYECCION DE DEPENDENCIAS!!!!(Mirar Ej.: MainInicial.cs)
                    this.appContext.SetEmpleado(empleado.ID);
                    this.appContext.SetEmpleadoRol(empleado.RolID);

                    frmMain fm = new frmMain(empleadoService, clienteService, appContext);
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
    }
}
