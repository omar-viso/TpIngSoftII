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
    public partial class FrmInformeHsObSemana : Form
    {
        private readonly Container container;

        public FrmInformeHsObSemana(Container container)
        {
            this.container = container;
            InitializeComponent();
        }

        private void FrmInformeHsObSemana_Load(object sender, EventArgs e)
        {
            var horasOBSemanal = container.GetInstance<IHorasTrabajadasService>().InformeSemanalHsOB();
            int count = 0;
            foreach (SubtotalHsOBDto subtotalHsOB in horasOBSemanal.TareasSubtotalesHsOB)
            {
                Label proyecto = new Label();
                proyecto.Text = subtotalHsOB.ProyectoNombre;
                proyecto.AutoSize = true;
                proyecto.Dock = DockStyle.Fill;
                Label tarea = new Label();
                tarea.Text = subtotalHsOB.TareaNombre;
                tarea.AutoSize = true;
                tarea.Dock = DockStyle.Fill;
                Label horasOB = new Label();
                horasOB.Text = subtotalHsOB.SubtotalHsOB.ToString();

                ListaHsOBSeamanPanel1.Controls.Add(proyecto, 0, count);
                ListaHsOBSeamanPanel1.Controls.Add(tarea, 1, count);
                ListaHsOBSeamanPanel1.Controls.Add(horasOB, 2, count);

                ListaHsOBSeamanPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                //ListaHsAdeudadasPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
                ListaHsOBSeamanPanel1.RowCount++;
                count++;
            }
            TotalObLabel.Text = horasOBSemanal.HsOBTotales.ToString();
        }

        private void ReporteButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                Metodos.SaveStreamAsFile(fbd.SelectedPath, container.GetInstance<IHorasTrabajadasService>().InformeSemanalHsOBReporte(), "Informe Semanal Horas OB.pdf");
            }
        }
    }
}
