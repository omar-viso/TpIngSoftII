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
    public partial class FrmClienteAgregar : Form
    {
        private readonly IClienteService clienteService;
        private readonly IAppContext2 appContext2;
        private int ID = 0;

        public FrmClienteAgregar(IClienteService clienteService ,IAppContext2 appContext2)
        {
            this.clienteService = clienteService;
            this.appContext2 = appContext2;
            InitializeComponent();
        }

        private void FrmClienteAgregar_Load(object sender, EventArgs e)
        {
            CargarlistaClientes();
        }

        private void TipoPersonaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (TipoPersonaCombo.SelectedItem.Equals("Fisica"))
            {
                NombreLabel.Visible = true;
                NombreTextBox.Visible = true;
                ApellidoLabel.Visible = true;
                ApellidoTextBox.Visible = true;

                RazonSociallabel.Visible = false;
                RazonSocialtextBox.Visible = false;
            }
            else
            {
                RazonSociallabel.Visible = true;
                RazonSocialtextBox.Visible = true;

                NombreLabel.Visible = false;
                NombreTextBox.Visible = false;
                ApellidoLabel.Visible = false;
                ApellidoTextBox.Visible = false;
            }
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            ClienteDto cliente = new ClienteDto();
            int tipoPerson=0; 
            if (TipoPersonaCombo.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione el tipo de persona");
                return;
            }
            if (TipoPersonaCombo.SelectedItem.Equals("Fisica"))
            {
                if (NombreTextBox.Text == "" || ApellidoTextBox.Text == "")
                {
                    MessageBox.Show("Por favor complete el nombre y el apellido");
                    return;
                }
                cliente.Nombre = NombreTextBox.Text;
                cliente.Apellido = ApellidoTextBox.Text;
                tipoPerson = Const.TipoPersona.Fisica;
            }
            if (TipoPersonaCombo.SelectedItem.Equals("Juridica"))
            {
                if (RazonSocialtextBox.Text == "")
                {
                    MessageBox.Show("Por favor complete la razón social");
                    return;
                }
                cliente.RazonSocial = RazonSocialtextBox.Text;
                tipoPerson = Const.TipoPersona.Juridica;
            }
            if (DireccionTextBox.Text == "" || DNI_CUIT_numeric.Value == 0)
            {
                MessageBox.Show("Por favor complete la direccion y el DNI");
                return;
            }

            cliente.Direccion = DireccionTextBox.Text;
            cliente.DniCuit = (long)DNI_CUIT_numeric.Value;

            if (TelefonoNumeric.Value != 0)
            {
                cliente.TelefonoContacto = (long)TelefonoNumeric.Value;
            }
            if (EMailTexbox.Text != "")
            {
                cliente.Email = EMailTexbox.Text;
            }

            cliente.TipoPersona = tipoPerson;
            if (ID != 0)
            {
                var clienteAEditar = clienteService.GetByIdAsNoTracking(ID);
                if (TipoPersonaCombo.SelectedItem.Equals("Fisica"))
                {
                    clienteAEditar.Nombre = NombreTextBox.Text;
                    clienteAEditar.Apellido = ApellidoTextBox.Text;
                }
                else
                {
                    clienteAEditar.RazonSocial = RazonSocialtextBox.Text;
                }
                clienteAEditar.TipoPersona = tipoPerson;
                clienteAEditar.Direccion = DireccionTextBox.Text;
                clienteAEditar.DniCuit = (long)DNI_CUIT_numeric.Value;
                if (TelefonoNumeric.Value != 0)
                {
                    clienteAEditar.TelefonoContacto = (long)TelefonoNumeric.Value;
                }
                if (EMailTexbox.Text != "")
                {
                    clienteAEditar.Email = EMailTexbox.Text;
                }
                var respuesta = clienteService.Update(clienteAEditar);
                if (respuesta != null)
                {
                    MessageBox.Show("Cliente editado");
                }
                else
                {
                    MessageBox.Show("No se a podido editar el cliente");
                }
                ID =0;
                ElejirClienteComboBox.ResetText();
                ElejirClienteComboBox.Items.Clear();
                CargarlistaClientes();
                this.Close();
            }
            else
            {
                var respuesta = clienteService.Update(cliente);
                if (respuesta != null)
                {
                    MessageBox.Show("Cliente creado con exito");
                }
                else
                {
                    MessageBox.Show("No se pudo crear cliente");
                }
            }
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            TipoPersonaCombo.ResetText();
            DireccionTextBox.Text = "";
            DNI_CUIT_numeric.Value = 0;
            TelefonoNumeric.Value = 0;
            EMailTexbox.Text = "";
        }

        private void ElejirClienteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var clientes = clienteService.GetAllAsNoTracking();
            foreach (ClienteDto cliente in clientes)
            {
                if (ElejirClienteComboBox.SelectedItem.ToString() == cliente.Nombre+ " "+cliente.Apellido || ElejirClienteComboBox.SelectedItem.ToString() == cliente.RazonSocial)
                {
                    NombreTextBox.Text = cliente.Nombre;
                    ApellidoTextBox.Text = cliente.Apellido;
                    if (cliente.RazonSocial == "" || cliente.RazonSocial == null)
                    {
                        TipoPersonaCombo.SelectedItem = "Fisica";
                    }
                    else
                    {
                        TipoPersonaCombo.SelectedItem = "Juridica";
                    }
                    RazonSocialtextBox.Text = cliente.RazonSocial;
                    DireccionTextBox.Text = cliente.Direccion;
                    DNI_CUIT_numeric.Value = cliente.DniCuit;
                    if(cliente.TelefonoContacto!=null)
                        TelefonoNumeric.Value =(decimal)cliente.TelefonoContacto;
                    EMailTexbox.Text=cliente.Email;
                    ID = cliente.ID;
                }
            }
        }
        private void CargarlistaClientes()
        {
            var clientes = clienteService.GetAllAsNoTracking();
            foreach (ClienteDto cliente in clientes)
            {
                if (cliente.RazonSocial == null || cliente.RazonSocial == "")
                    ElejirClienteComboBox.Items.Add(cliente.Nombre + " " + cliente.Apellido);
                else
                    ElejirClienteComboBox.Items.Add(cliente.RazonSocial);
            }
        }
    }
}
