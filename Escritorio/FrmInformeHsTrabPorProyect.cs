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
    public partial class FrmInformeHsTrabPorProyect : Form
    {
        private readonly Container container;
        public FrmInformeHsTrabPorProyect(Container container)
        {
            this.container = container;
            InitializeComponent();
        }

        private void FrmInformeHsTrabPorProyect_Load(object sender, EventArgs e)
        {
            var horasTrabProyecPerfil = container.GetInstance<IProyectoService>().HorasTrabajadasPorProyectoPorPerfilTotales();
            int count = 0;
            foreach (ProyectoPerfilesHorasDto horaTrabProyecPerfil in horasTrabProyecPerfil)
            {
                foreach (PerfilHorasDto perfilHoras in horaTrabProyecPerfil.PerfilesHoras) {
                    Label proyecto = new Label();
                    proyecto.Text = horaTrabProyecPerfil.ProyectoNombre;
                    proyecto.AutoSize = true;
                    proyecto.Dock = DockStyle.Fill;
                    Label Perfil = new Label();
                    Perfil.Text = perfilHoras.PerfilDescripcion;
                    Label horasTrab = new Label();
                    horasTrab.Text = perfilHoras.CantidadHoras.ToString();

                    ListaHsTrabajProyectPanel1.Controls.Add(proyecto, 0, count);
                    ListaHsTrabajProyectPanel1.Controls.Add(Perfil, 1, count);
                    ListaHsTrabajProyectPanel1.Controls.Add(horasTrab, 2, count);


                    ListaHsTrabajProyectPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                    //ListaHsAdeudadasPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
                    ListaHsTrabajProyectPanel1.RowCount++;
                    count++;
                }
            }
        }

        private void ReporteButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                Metodos.SaveStreamAsFile(fbd.SelectedPath, container.GetInstance<IProyectoService>().HsTrabajadasProyectorPerfilReporte(), "Reporte de Hs Trabajadas Proyecto-Perfil.pdf");
            }
        }
    }
}
