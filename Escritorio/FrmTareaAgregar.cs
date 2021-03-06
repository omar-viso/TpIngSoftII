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
    public partial class FrmTareaAgregar : Form
    {
        private readonly Container container;
        private int empleadoID = 0;
        private int perfilID = 0;
        private int proyectoID = 0;

        public FrmTareaAgregar(Container container)
        {
            this.container = container;
            InitializeComponent();
        }

        private void FrmTareaAgregar_Load(object sender, EventArgs e)
        {
            CargarlistaEmpleados();
            CargarListaPerfiles();
            CargarlistaProyectos();
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            TareaDto tareaDto = new TareaDto();
            if (NombreTextBox.Text == "")
            {
                MessageBox.Show("Por favor complete el nombre");
                return;
            }
            tareaDto.Nombre = NombreTextBox.Text;

            if (proyectoID == 0)
            {
                MessageBox.Show("Por favor elija el proyecto");
                return;
            }
            tareaDto.ProyectoID = proyectoID;

            if (empleadoID == 0)
            {
                MessageBox.Show("Por favor elija el proyecto");
                return;
            }

            if (perfilID == 0)
            {
                MessageBox.Show("Por favor elija el perfil");
                return;
            }
            int empleadoPerfilID= container.GetInstance<IEmpleadoService>().GetEmpleadoPerfilID(empleadoID, perfilID);
            if (empleadoPerfilID ==0)
            {
                MessageBox.Show("El Empleado-Perfil indicado no existe.");
                return;
            }
            tareaDto.EmpleadoPerfilID = empleadoPerfilID;
            container.GetInstance<IEmpleadoService>().Limpiar();
            if (HorasEstimNumeric.Value == 0)
            {
                MessageBox.Show("El Empleado-Perfil indicado no existe.");
                return;
            }
            tareaDto.HorasEstimadas = HorasEstimNumeric.Value;

            tareaDto.HorasOB = 0;//Cuando se crea no tiene hs ob
            try
            {
                var respuesta = container.GetInstance<ITareaService>().Update(tareaDto);
                if (respuesta != null)
                {
                    MessageBox.Show("Tarea creada");
                    container.GetInstance<ITareaService>().Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se a podido crear la tarea. " + ex.Message);
            }
            NombreTextBox.Text = "";
            HorasEstimNumeric.Value = 0;
            ElegirEmpleadocomboBox.ResetText();
            empleadoID = 0;
            ElejirPerfilcomboBox.ResetText();
            perfilID = 0;
            ElegirProyectocomboBox.ResetText();
            proyectoID = 0;
        }

        private void CargarListaPerfiles()
        {
            var perfiles = container.GetInstance<IPerfilService>().GetAllAsNoTracking();
            foreach (PerfilDto perfil in perfiles)
            {
                ElejirPerfilcomboBox.Items.Add(perfil.Descripcion);
            }
        }

        private void CargarlistaProyectos()
        {
            var proyectos = container.GetInstance<IProyectoService>().GetAllAsNoTracking();
            foreach (ProyectoDto proyecto in proyectos)
            {
                ElegirProyectocomboBox.Items.Add(proyecto.Nombre);
            }
        }
        private void CargarlistaEmpleados()
        {
            var empleados = container.GetInstance<IEmpleadoService>().GetAllAsNoTracking();
            foreach (EmpleadoDto empleado in empleados)
            {
                ElegirEmpleadocomboBox.Items.Add(empleado.Nombre + " " + empleado.Apellido);
            }
        }

        private void ElejirPerfilcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var perfiles = container.GetInstance<IPerfilService>().GetAllAsNoTracking();
            foreach (PerfilDto perfil in perfiles)
            {
                if (ElejirPerfilcomboBox.SelectedItem.ToString() == perfil.Descripcion)
                {
                    perfilID = perfil.ID;
                }
            }
        }

        private void ElegirEmpleadocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var empleados = container.GetInstance<IEmpleadoService>().GetAllAsNoTracking();
            foreach (EmpleadoDto empleado in empleados)
            {
                if (ElegirEmpleadocomboBox.SelectedItem.ToString() == empleado.Nombre + " " + empleado.Apellido)
                {
                    empleadoID = empleado.ID;
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
                    proyectoID = proyecto.ID;
                }
            }
        }
    }
}
