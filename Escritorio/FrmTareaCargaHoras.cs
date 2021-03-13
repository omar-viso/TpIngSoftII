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
    public partial class FrmTareaCargaHoras : Form
    {
        private readonly Container container;
        private int tareaID = 0;

        public FrmTareaCargaHoras(Container container)
        {
            this.container = container;
            InitializeComponent();
        }

        private void FrmTareaCargaHoras_Load(object sender, EventArgs e)
        {
            CargarListaTareas();
        }
        private void CargarButton_Click(object sender, EventArgs e)
        {
            HorasTrabajadasDto horasTrabajadasDto = new HorasTrabajadasDto();
            if (tareaID == 0)
            {
                MessageBox.Show("Por favor la elija la tarea");
                return;
            }
            horasTrabajadasDto.ProyectoID= container.GetInstance<ITareaService>().GetByIdAsNoTracking(tareaID).ProyectoID;
            horasTrabajadasDto.TareaID = tareaID;
            container.GetInstance<ITareaService>().Limpiar();

            if (HsTrabajadNumeric.Value==0)
            {
                MessageBox.Show("Por favor agregue horas a la tarea");
                return;
            }
            horasTrabajadasDto.CantHoras = HsTrabajadNumeric.Value;
            horasTrabajadasDto.HorasTrabajadasEstadoID = Const.HoraTrabajadaEstado.Adeudada;

            try
            {
                decimal cantHSOB = container.GetInstance<IHorasTrabajadasService>().CantidadHsOB(horasTrabajadasDto);
                if (cantHSOB > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Las horas por cargar se cargaran como horas over Budget. Desea continuar", "Horas Over Budget", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No || dialogResult == DialogResult.Cancel)
                    {
                        HsTrabajadNumeric.Value = 0;
                        TareacomboBox.ResetText();
                        tareaID = 0;
                        return;
                    }
                }
                var respuesta = container.GetInstance<IHorasTrabajadasService>().Update(horasTrabajadasDto);
                if (respuesta != null)
                {
                    MessageBox.Show("Horas cargadas");
                    container.GetInstance<IHorasTrabajadasService>().Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se a podido cargar las horas para esa tarea. " + ex.Message);
            }
            HsTrabajadNumeric.Value=0;
            TareacomboBox.ResetText();
            tareaID = 0;
        }

        private void CargarListaTareas()
        {
            var tareas = container.GetInstance<ITareaService>().GetAllAsNoTracking();
            foreach (TareaDto tarea in tareas)
            {
                TareacomboBox.Items.Add(tarea.Nombre);
            }
        }

        private void TareacomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tareas = container.GetInstance<ITareaService>().GetAllAsNoTracking();
            foreach (TareaDto tarea in tareas)
            {
                if (TareacomboBox.SelectedItem.ToString() == tarea.Nombre)
                {
                    tareaID = tarea.ID;
                }
            }
        }
    }
}
