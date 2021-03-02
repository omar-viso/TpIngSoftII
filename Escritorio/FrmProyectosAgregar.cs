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
    public partial class FrmProyectosAgregar : Form
    {
        private readonly IProyectoService proyectoService;
        private readonly IClienteService clienteService;
        private readonly IAppContext2 appContext2;
        private int ID = 0;
        private int ClienteID = 0;
        private int ProyectoEstadoID = 0;

        public FrmProyectosAgregar(IProyectoService proyectoService, IClienteService clienteService, IAppContext2 appContext2)
        {
            this.clienteService = clienteService;
            this.proyectoService = proyectoService;
            this.appContext2 = appContext2;
            InitializeComponent();
        }

        private void FrmProyectosAgregar_Load(object sender, EventArgs e)
        {
            var clientes = clienteService.GetAllAsNoTracking();
            foreach (ClienteDto cliente in clientes)
            {
                if (cliente.RazonSocial == null || cliente.RazonSocial == "")
                    ElejirClienteComboBox.Items.Add(cliente.Nombre + " " + cliente.Apellido);
                else
                    ElejirClienteComboBox.Items.Add(cliente.RazonSocial);
            }
            var proyectoEstados = proyectoService.ProyectoEstados();
            foreach (ProyectoEstadoDto proyectoEstado in proyectoEstados)
            {
                CambiarEstadocomboBox.Items.Add(proyectoEstado.Descripcion);
            }
            CargarlistaProyectos();
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            ProyectoDto proyectoDto = new ProyectoDto();
            if (NombreTextBox.Text == "")
            {
                MessageBox.Show("Por favor complete el nombre");
                return;
            }
            proyectoDto.Nombre = NombreTextBox.Text;
            if (ClienteID == 0)
            {
                MessageBox.Show("Por favor elija el cliente");
                return;
            }
            proyectoDto.ClienteID = ClienteID;
            if (ProyectoEstadoID == 0)
            {
                MessageBox.Show("Por favor elija el estado del proyecto");
                return;
            }
            proyectoDto.ProyectoEstadoID = ProyectoEstadoID;
            if (ID != 0)
            {
                var proyectoAEditar = proyectoService.GetByIdAsNoTracking(ID);
                proyectoAEditar.Nombre = NombreTextBox.Text;
                proyectoAEditar.ClienteID = ClienteID;
                proyectoAEditar.ProyectoEstadoID = ProyectoEstadoID;
                var respuesta = proyectoService.Update(proyectoAEditar);
                if (respuesta != null)
                {
                    MessageBox.Show("Proyecto editado");
                }
                else
                {
                    MessageBox.Show("No se a podido editar el proyecto");
                }
                ID = 0;
                ElegirProyectocomboBox.ResetText();
                ElegirProyectocomboBox.Items.Clear();
                CargarlistaProyectos();
                this.Close();
            }
            else
            {
                var respuesta = proyectoService.Update(proyectoDto);
                if (respuesta != null)
                {
                    MessageBox.Show("Proyecto creado con exito");
                }
                else
                {
                    MessageBox.Show("No se pudo crear proyecto");
                }
            }
            NombreTextBox.Text = "";
            ElejirClienteComboBox.ResetText();
            ClienteID = 0;
            CambiarEstadocomboBox.ResetText();
            ProyectoEstadoID = 0;
        }

        private void ElejirClienteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var clientes = clienteService.GetAllAsNoTracking();
            foreach (ClienteDto cliente in clientes)
            {
                if (ElejirClienteComboBox.SelectedItem.ToString() == cliente.Nombre + " " + cliente.Apellido || ElejirClienteComboBox.SelectedItem.ToString() == cliente.RazonSocial)
                {
                    ClienteID = cliente.ID;
                }
            }
        }

        private void CambiarEstadocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var proyectoEstados = proyectoService.ProyectoEstados();
            foreach (ProyectoEstadoDto proyectoEstado in proyectoEstados)
            {
                if (CambiarEstadocomboBox.SelectedItem.ToString() ==proyectoEstado.Descripcion)
                {
                    ProyectoEstadoID = proyectoEstado.ID;
                }
            }
        }

        private void ElegirProyectocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var proyectos = proyectoService.GetAllAsNoTracking();
            foreach (ProyectoDto proyecto in proyectos)
            {
                if (ElegirProyectocomboBox.SelectedItem.ToString() == proyecto.Nombre)
                {

                    NombreTextBox.Text = proyecto.Nombre;
                    ElejirClienteComboBox.SelectedItem = proyecto.ClienteNombre;
                    ClienteID = proyecto.ClienteID;
                    CambiarEstadocomboBox.SelectedItem = proyecto.ProyectoEstadoDescripcion;
                    ProyectoEstadoID = proyecto.ProyectoEstadoID;
                    ID = proyecto.ID;
                }
            }
        }
        private void CargarlistaProyectos()
        {
            var proyectos = proyectoService.GetAllAsNoTracking();
            foreach (ProyectoDto proyecto in proyectos)
            {
                  ElegirProyectocomboBox.Items.Add(proyecto.Nombre);
            }
        }

        
    }
}
