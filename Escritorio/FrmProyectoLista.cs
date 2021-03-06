﻿using System;
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
    public partial class FrmProyectoLista : Form
    {
        //private readonly IProyectoService proyectoService;
        //private readonly IAppContext2 appContext2;
        private readonly Container container;

        public FrmProyectoLista(/*IProyectoService proyectoService, IAppContext2 appContext2*/Container container)
        {
            //this.proyectoService = proyectoService;
            //this.appContext2 = appContext2;
            this.container = container;
            InitializeComponent();
        }
        private void FrmProyectoLista_Load(object sender, EventArgs e)
        {
            var proyectos = container.GetInstance<IProyectoService>().GetAllAsNoTracking();
            int count = 0;
            foreach (ProyectoDto proyecto in proyectos)
            {
                Label Nombre = new Label();
                Nombre.Text = proyecto.Nombre;
                Nombre.AutoSize = true;
                Nombre.Dock = DockStyle.Fill;
                Label EstadoProyecto = new Label();
                EstadoProyecto.Text = proyecto.ProyectoEstadoDescripcion;
                Label clienteNombre = new Label();
                clienteNombre.Text = proyecto.ClienteNombre;
                Button Borrar = new Button();
                Borrar.Margin = new Padding(0);
                Borrar.Text = "Borrar";
                Borrar.Tag = proyecto.ID;
                Borrar.Click += new System.EventHandler(this.btnDelete_Click);

                ListaProyectoPanel1.Controls.Add(Nombre, 0, count);
                ListaProyectoPanel1.Controls.Add(EstadoProyecto, 1, count);
                ListaProyectoPanel1.Controls.Add(clienteNombre, 2, count);
                ListaProyectoPanel1.Controls.Add(Borrar, 3, count);

                ListaProyectoPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                ListaProyectoPanel1.RowCount++;
                count++;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Reference the Button which was clicked.
            Button button = (sender as Button);
            int index = ListaProyectoPanel1.GetRow(button);
            container.GetInstance<IProyectoService>().DeleteById((int)button.Tag);
            //ListaPerfilPanel1.SuspendLayout();
            Metodos.RemoveArbitraryRow(ListaProyectoPanel1, index);
            //ListaPerfilPanel1.ResumeLayout();
            //ListaPerfilPanel1.PerformLayout();
        }

        private void ReporteButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                Metodos.SaveStreamAsFile(fbd.SelectedPath, container.GetInstance<IProyectoService>().ProyectosReporte(), "Reporte de Proyectos.pdf");
            }
        }
    }
}
