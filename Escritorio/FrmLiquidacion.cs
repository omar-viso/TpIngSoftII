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
using SimpleInjector;

namespace Escritorio
{
    public partial class FrmLiquidacion : Form
    {
        private readonly Container container;
        private int empleadoID = 0;

        public FrmLiquidacion(Container container)
        {
            this.container = container;
            InitializeComponent();
        }

        private void FrmLiquidacion_Load(object sender, EventArgs e)
        {
            CargarlistaEmpleados();
        }

        private void LiquidacionButton_Click(object sender, EventArgs e)
        {
            SolicitaLiquidacionDto solicitaLiquidacion = new SolicitaLiquidacionDto();
            if (empleadoID == 0)
            {
                MessageBox.Show("Por favor elija el empleado");
                return;
            }
            solicitaLiquidacion.EmpleadoID = empleadoID;
            solicitaLiquidacion.Desde = InicioDatePicker.Value;
            solicitaLiquidacion.Hasta = FinDatePicker.Value;

            try
            {
                var liquidacion = container.GetInstance<IProyectoService>().Liquidacion(solicitaLiquidacion);
                AntiguedadLabel.Text = liquidacion.AntiguedadEmpleado.ToString();
                HsNoOBLabel.Text = liquidacion.CantidadHsNoOBLiquidados.ToString();
                HsOBLabel.Text = liquidacion.CantidadHsOBLiquidados.ToString();
                HsTotalesLabel.Text = liquidacion.CantidadHsTotalesLiquidados.ToString();
                PerfilesLabel.Text = liquidacion.CantidadPerfiles.ToString();
                ProyectosLabel.Text = liquidacion.CantidadProyectosLiquidados.ToString();
                TareasLabel.Text = liquidacion.CantidadTareasLiquidados.ToString();
                PorcentAntigueadadLabel.Text = liquidacion.PorcentajeAplicadoAntiguedad.ToString();
                PorcentHsTotalesLabel.Text = liquidacion.PorcentajeAplicadoCantidadHoras.ToString();
                PorcentCantPerfilesLabel.Text = liquidacion.PorcentajeAplicadoCantidadPerfiles.ToString();
                TotalLabel.Text = liquidacion.TotalLiquidado.ToString();

            } catch (Exception exc)
            {
                MessageBox.Show("No se pudo hacer la liquidacion. "+exc.Message);
            }
        }

        private void CargarlistaEmpleados()
        {
            var empleados = container.GetInstance<IEmpleadoService>().GetAllAsNoTracking();
            foreach (EmpleadoDto empleado in empleados)
            {
                EmpleadocomboBox.Items.Add(empleado.Nombre + " " + empleado.Apellido);
            }
        }

        private void EmpleadocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var empleados = container.GetInstance<IEmpleadoService>().GetAllAsNoTracking();
            foreach (EmpleadoDto empleado in empleados)
            {
                if (EmpleadocomboBox.SelectedItem.ToString() == empleado.Nombre + " " + empleado.Apellido)
                {
                    empleadoID = empleado.ID;
                }
            }
        }

        private void ReporteButton_Click(object sender, EventArgs e)
        {
            SolicitaLiquidacionDto solicitaLiquidacion = new SolicitaLiquidacionDto();
            if (empleadoID == 0)
            {
                MessageBox.Show("Por favor elija el empleado");
                return;
            }
            solicitaLiquidacion.EmpleadoID = empleadoID;
            solicitaLiquidacion.Desde = InicioDatePicker.Value;
            solicitaLiquidacion.Hasta = FinDatePicker.Value;

            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                try
                {
                    Metodos.SaveStreamAsFile(fbd.SelectedPath, container.GetInstance<IProyectoService>().LiquidacionReporte(solicitaLiquidacion), "Reporte de Liquidacion.pdf");
                }
                catch (Exception exc)
                {
                    MessageBox.Show("No se pudo hacer la liquidacion. " + exc.Message);
                }
            }
        }
    }
}
