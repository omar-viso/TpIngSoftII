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
    public partial class FrmInformeHsTrabPorEmpl : Form
    {
        private readonly Container container;

        public FrmInformeHsTrabPorEmpl(Container container)
        {
            this.container = container;
            InitializeComponent();
        }

        private void SolicitarButton_Click(object sender, EventArgs e)
        {
            DateTime desde = InicioDatePicker.Value;
            DateTime hasta = FinDatePicker.Value;
            var horasTrabProyecEmpleado = container.GetInstance<IProyectoService>().HorasTrabajadasPorProyectoPorPerfilPorEmpleadoTotales(desde,hasta);
            int count = 0;
            foreach (ProyectoPerfilesEmpleadosHorasDto horaTrabProyecEmpleado in horasTrabProyecEmpleado)
            {
                foreach (PerfilEmpleadosHorasDto perfilEmpleadoHoras in horaTrabProyecEmpleado.PerfilesEmpleadosHoras)
                {
                    foreach (EmpleadoHorasDto empleadoHoras in perfilEmpleadoHoras.EmpleadosHoras) {
                        Label proyecto = new Label();
                        proyecto.Text = horaTrabProyecEmpleado.ProyectoNombre;
                        proyecto.AutoSize = true;
                        proyecto.Dock = DockStyle.Fill;
                        Label Perfil = new Label();
                        Perfil.Text = perfilEmpleadoHoras.PerfilDescripcion;
                        Label empleado = new Label();
                        empleado.Text = empleadoHoras.Empleado.Nombre+ " " + empleadoHoras.Empleado.Apellido;
                        empleado.AutoSize = true;
                        empleado.Dock = DockStyle.Fill;
                        Label horasTrab = new Label();
                        horasTrab.Text = empleadoHoras.CantidadHoras.ToString();

                        ListaHsTrabajProyectPanel1.Controls.Add(proyecto, 0, count);
                        ListaHsTrabajProyectPanel1.Controls.Add(Perfil, 1, count);
                        ListaHsTrabajProyectPanel1.Controls.Add(empleado, 2, count);
                        ListaHsTrabajProyectPanel1.Controls.Add(horasTrab, 3, count);


                        ListaHsTrabajProyectPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                        //ListaHsAdeudadasPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
                        ListaHsTrabajProyectPanel1.RowCount++;
                        count++;
                    }
                }
            }
        }

        private void ReporteButton_Click(object sender, EventArgs e)
        {
            DateTime desde = InicioDatePicker.Value;
            DateTime hasta = FinDatePicker.Value;
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                Metodos.SaveStreamAsFile(fbd.SelectedPath, container.GetInstance<IProyectoService>().HorasTrabajadasPorProyectoPorPerfilPorEmpleadoTotalesReporte(desde,hasta), "Reporte de Hs Trabajadas Proyecto-Perfil-Empleado.pdf");
            }
        }
    }
}
