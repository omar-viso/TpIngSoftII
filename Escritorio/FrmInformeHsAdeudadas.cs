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
    public partial class FrmInformeHsAdeudadas : Form
    {
        private readonly Container container;

        public FrmInformeHsAdeudadas(Container container)
        {
            this.container = container;
            InitializeComponent();
        }

        private void FrmInformeHsAdeudadas_Load(object sender, EventArgs e)
        {
            var horasAdeudadasDtos= container.GetInstance<IProyectoService>().HorasAdeudadasPorProyectoPorEmpleadoTotales();
            int count = 0;
            foreach (ProyectoEmpleadoHorasAdeudadasDto proyectoEmpleadoHorasAdeudadas in horasAdeudadasDtos)
            {
                foreach (EmpleadoNombreHorasDto empleadoHoras in proyectoEmpleadoHorasAdeudadas.EmpleadoHoras)
                {
                    Label proyecto = new Label();
                    proyecto.Text = proyectoEmpleadoHorasAdeudadas.ProyectoNombre;
                    proyecto.AutoSize = true;
                    proyecto.Dock = DockStyle.Fill;
                    //proyecto.AutoEllipsis = true;
                    Label empleadoNombre = new Label();
                    empleadoNombre.Text = empleadoHoras.EmpleadoNombre+" "+ empleadoHoras.EmpleadoApellido;
                    Label HorasAdeudadaesLabel = new Label();
                    HorasAdeudadaesLabel.Text = empleadoHoras.CantidadHorasAdeudadas.ToString();

                    ListaHsAdeudadasPanel1.Controls.Add(proyecto, 0, count);
                    ListaHsAdeudadasPanel1.Controls.Add(empleadoNombre, 1, count);
                    ListaHsAdeudadasPanel1.Controls.Add(HorasAdeudadaesLabel, 2, count);


                    ListaHsAdeudadasPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                    //ListaHsAdeudadasPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
                    ListaHsAdeudadasPanel1.RowCount++;
                    count++;
                }
            }
        }
    }
}
