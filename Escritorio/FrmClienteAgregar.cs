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

        public FrmClienteAgregar(IClienteService clienteService, IAppContext2 appContext2)
        {
            this.clienteService = clienteService;
            this.appContext2 = appContext2;
            InitializeComponent();
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

        private void FrmClienteAgregar_Load(object sender, EventArgs e)
        {
        }
    }
}
