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
    public partial class FrmTareaLista : Form
    {
        private readonly Container container;

        public FrmTareaLista(Container container)
        {
            this.container = container;
            InitializeComponent();
        }

        private void FrmTareaLista_Load(object sender, EventArgs e)
        {
            var tareas = container.GetInstance<ITareaService>().GetAllAsNoTracking();
            int count = 0;
            foreach (TareaDto tarea in tareas)
            {
                Label tareaNombre = new Label();
                tareaNombre.Text = tarea.Nombre;
                tareaNombre.AutoSize = true;
                tareaNombre.Dock = DockStyle.Fill;
                Label empleadoNombre = new Label();
                empleadoNombre.Text = tarea.EmpleadoPerfilNombreEmplado;
                Label perfil = new Label();
                perfil.Text = tarea.EmpleadoPerfilDescripcion;
                Label proyecto = new Label();
                proyecto.Text = tarea.ProyectoNombre;
                proyecto.AutoSize = true;
                proyecto.Dock = DockStyle.Fill;
                Label horasEstimadas = new Label();
                horasEstimadas.Text = tarea.HorasEstimadas.ToString();
                Label horasOB = new Label();
                horasOB.Text = tarea.HorasOB.ToString();

                Button Borrar = new Button();
                Borrar.Margin = new Padding(0);
                Borrar.Text = "Borrar";
                Borrar.Tag = tarea.ID;
                Borrar.Click += new System.EventHandler(this.btnDelete_Click);


                ListaTareaPanel1.Controls.Add(tareaNombre, 0, count);
                ListaTareaPanel1.Controls.Add(empleadoNombre, 1, count);
                ListaTareaPanel1.Controls.Add(perfil, 2, count);
                ListaTareaPanel1.Controls.Add(proyecto, 3, count);
                ListaTareaPanel1.Controls.Add(horasEstimadas, 4, count);
                ListaTareaPanel1.Controls.Add(horasOB, 5, count);
                ListaTareaPanel1.Controls.Add(Borrar, 6, count);

                ListaTareaPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                ListaTareaPanel1.RowCount++;
                count++;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Reference the Button which was clicked.
            Button button = (sender as Button);
            int index = ListaTareaPanel1.GetRow(button);
            container.GetInstance<IClienteService>().DeleteById((int)button.Tag);
            //ListaPerfilPanel1.SuspendLayout();
            Metodos.RemoveArbitraryRow(ListaTareaPanel1, index);
            //ListaPerfilPanel1.ResumeLayout();
            //ListaPerfilPanel1.PerformLayout();
        }
    }
}
