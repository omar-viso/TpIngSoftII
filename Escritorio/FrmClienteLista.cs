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
using Escritorio.Metodos_estaticos;
using TpIngSoftII.Models.Constantes;

namespace Escritorio
{
    public partial class FrmClienteLista : Form
    {
        private readonly IClienteService clienteService;
        private readonly IAppContext2 appContext2;

        public FrmClienteLista(IClienteService clienteService, IAppContext2 appContext2)
        {
            this.clienteService = clienteService;
            this.appContext2 = appContext2;
            InitializeComponent();
        }

        private void FrmClienteLista_Load(object sender, EventArgs e)
        {
            var clientes = clienteService.GetAllAsNoTracking();
            int count = 0;
            foreach (ClienteDto cliente in clientes)
            {
                Label clienteNombre = new Label();
                clienteNombre.Text = cliente.Nombre;
                Label clienteApellido  = new Label();
                clienteApellido.Text = cliente.Apellido;
                Label razonSocial= new Label();
                razonSocial.Text = cliente.RazonSocial;
                Label DNI_CUIT= new Label();
                DNI_CUIT.Text = cliente.DniCuit.ToString();
                Label direccion= new Label();
                direccion.Text = cliente.Direccion;
                Label telefono= new Label();
                telefono.Text = cliente.TelefonoContacto.ToString();
                Label email= new Label();
                email.Text = cliente.Email;
                Label tipoPersona= new Label();
                if (cliente.RazonSocial=="" || cliente.RazonSocial ==null)
                    tipoPersona.Text = "Fisica";
                else
                    tipoPersona.Text = "Juridica";
                //Button Editar = new Button();
                //Editar.Margin = new Padding(0);
                //Editar.Text = "Editar";
                //Editar.Click += new System.EventHandler(this.btnEditar_Click);
                //Editar.Tag = perfil.ID;
                Button Borrar = new Button();
                Borrar.Margin = new Padding(0);
                Borrar.Text = "Borrar";
                Borrar.Tag = cliente.ID;
                Borrar.Click += new System.EventHandler(this.btnDelete_Click);


                ListaClientePanel1.Controls.Add(clienteNombre, 0, count);
                ListaClientePanel1.Controls.Add(clienteApellido, 1, count);
                ListaClientePanel1.Controls.Add(razonSocial, 2 , count);
                ListaClientePanel1.Controls.Add(DNI_CUIT, 3, count);
                ListaClientePanel1.Controls.Add(direccion, 4, count);
                ListaClientePanel1.Controls.Add(telefono, 5 , count);
                ListaClientePanel1.Controls.Add(email, 6 , count);
                ListaClientePanel1.Controls.Add(tipoPersona, 7 , count);
                ListaClientePanel1.Controls.Add(Borrar, 8, count);

                ListaClientePanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                ListaClientePanel1.RowCount++;
                count++;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Reference the Button which was clicked.
            Button button = (sender as Button);
            int index = ListaClientePanel1.GetRow(button);
            clienteService.DeleteById((int)button.Tag);
            //ListaPerfilPanel1.SuspendLayout();
            Metodos.RemoveArbitraryRow(ListaClientePanel1, index);
            //ListaPerfilPanel1.ResumeLayout();
            //ListaPerfilPanel1.PerformLayout();
        }
    }
}
