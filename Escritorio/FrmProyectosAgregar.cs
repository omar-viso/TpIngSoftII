using System;
using System.Collections.Generic;
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
using SimpleInjector;

namespace Escritorio
{
    public partial class FrmProyectosAgregar : Form
    {
        //private readonly IProyectoService proyectoService;
        //private readonly IClienteService clienteService;
        //private readonly IAppContext2 appContext2;
        private readonly Container container;
        private int ID = 0;
        private int ClienteID = 0;
        private int ProyectoEstadoID = 0;

        public FrmProyectosAgregar(/*IProyectoService proyectoService, IClienteService clienteService, IAppContext2 appContext2*/Container container)
        {
            //this.clienteService = clienteService;
            //this.proyectoService = proyectoService;
            //this.appContext2 = appContext2;
            this.container = container;
            InitializeComponent();
        }

        private void FrmProyectosAgregar_Load(object sender, EventArgs e)
        {
            var clientes = container.GetInstance<IClienteService>().GetAllAsNoTracking();
            foreach (ClienteDto cliente in clientes)
            {
                if (cliente.RazonSocial == null || cliente.RazonSocial == "")
                    ElejirClienteComboBox.Items.Add(cliente.Nombre + " " + cliente.Apellido);
                else
                    ElejirClienteComboBox.Items.Add(cliente.RazonSocial);
            }
            var proyectoEstados = container.GetInstance<IProyectoService>().ProyectoEstados();
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
                var proyectoAEditar = container.GetInstance<IProyectoService>().GetByIdAsNoTracking(ID);
                proyectoAEditar.Nombre = NombreTextBox.Text;
                proyectoAEditar.ClienteID = ClienteID;
                proyectoAEditar.ProyectoEstadoID = ProyectoEstadoID;
                try
                {
                    var respuesta = container.GetInstance<IProyectoService>().Update(proyectoAEditar);
                    if (respuesta != null)
                    {
                        MessageBox.Show("Proyecto editado");
                    }
                }catch(Exception ex) 
                {
                    MessageBox.Show("No se a podido editar el proyecto. "+ex.Message);
                }
                ID = 0;
                ElegirProyectocomboBox.ResetText();
                ElegirProyectocomboBox.Items.Clear();
                CargarlistaProyectos();
                container.GetInstance<IProyectoService>().Limpiar();
            }
            else
            {
                try
                {
                    var respuesta = container.GetInstance<IProyectoService>().Update(proyectoDto);
                    if (respuesta != null)
                    {
                        MessageBox.Show("Proyecto creado con exito");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo crear proyecto. "+ex.Message);
                }
                container.GetInstance<IProyectoService>().Limpiar();
            }
            NombreTextBox.Text = "";
            ElejirClienteComboBox.ResetText();
            ClienteID = 0;
            CambiarEstadocomboBox.ResetText();
            ProyectoEstadoID = 0;
        }

        private void ElejirClienteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var clientes = container.GetInstance<IClienteService>().GetAllAsNoTracking();
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
            var proyectoEstados = container.GetInstance<IProyectoService>().ProyectoEstados();
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
            var proyectos = container.GetInstance<IProyectoService>().GetAllAsNoTracking();
            foreach (ProyectoDto proyecto in proyectos)
            {
                if (ElegirProyectocomboBox.SelectedItem.ToString() == proyecto.Nombre)
                {

                    NombreTextBox.Text = proyecto.Nombre;
                    ClienteID = proyecto.ClienteID;
                    var cliente=container.GetInstance<IClienteService>().GetById(ClienteID);
                    if (cliente.RazonSocial == null || cliente.RazonSocial == "")
                        ElejirClienteComboBox.SelectedItem = cliente.Nombre + " " + cliente.Apellido;
                    else
                        ElejirClienteComboBox.SelectedItem = cliente.RazonSocial;
                    CambiarEstadocomboBox.SelectedItem = proyecto.ProyectoEstadoDescripcion;
                    ProyectoEstadoID = proyecto.ProyectoEstadoID;
                    ID = proyecto.ID;
                }
            }
            container.GetInstance<IClienteService>().Limpiar();
        }
        private void CargarlistaProyectos()
        {
            var proyectos = container.GetInstance<IProyectoService>().GetAllAsNoTracking();
            foreach (ProyectoDto proyecto in proyectos)
            {
                  ElegirProyectocomboBox.Items.Add(proyecto.Nombre);
            }
        }

        
    }
}
