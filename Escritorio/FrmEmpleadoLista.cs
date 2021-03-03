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
    public partial class FrmEmpleadoLista : Form
    {
        private readonly Container container;

        public FrmEmpleadoLista(Container container)
        {
            this.container = container;
            InitializeComponent();
        }

        private void FrmEmpleadoLista_Load(object sender, EventArgs e)
        {
            var empleados = container.GetInstance<IEmpleadoService>().GetAllAsNoTracking();
            int count = 0;
            foreach (EmpleadoDto empleado in empleados)
            {
                Label empleadoNombre = new Label();
                empleadoNombre.Text = empleado.Nombre;
                Label empleadoApellido = new Label();
                empleadoApellido.Text = empleado.Apellido;
                Label DNI = new Label();
                DNI.Text = empleado.Dni.ToString();
                Label fecha = new Label();
                fecha.Text = empleado.FechaIngreso.ToShortDateString();
                Label perfiles = new Label();
                perfiles.Text = empleado.Perfiles.Count.ToString();
                
                Button Borrar = new Button();
                Borrar.Margin = new Padding(0);
                Borrar.Text = "Borrar";
                Borrar.Tag = empleado.ID;
                Borrar.Click += new System.EventHandler(this.btnDelete_Click);


                ListaEmpleadoPanel1.Controls.Add(empleadoNombre, 0, count);
                ListaEmpleadoPanel1.Controls.Add(empleadoApellido, 1, count);
                ListaEmpleadoPanel1.Controls.Add(DNI, 2, count);
                ListaEmpleadoPanel1.Controls.Add(fecha, 3, count);
                ListaEmpleadoPanel1.Controls.Add(perfiles, 4, count);
                ListaEmpleadoPanel1.Controls.Add(Borrar, 5, count);

                ListaEmpleadoPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                ListaEmpleadoPanel1.RowCount++;
                count++;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Reference the Button which was clicked.
            Button button = (sender as Button);
            int index = ListaEmpleadoPanel1.GetRow(button);
            container.GetInstance<IEmpleadoService>().DeleteById((int)button.Tag);
            //ListaPerfilPanel1.SuspendLayout();
            Metodos.RemoveArbitraryRow(ListaEmpleadoPanel1, index);
            //ListaPerfilPanel1.ResumeLayout();
            //ListaPerfilPanel1.PerformLayout();
        }
    }
}
