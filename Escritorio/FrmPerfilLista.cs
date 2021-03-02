using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Escritorio
{
    public partial class FrmPerfilLista : Form
    {
        private readonly IPerfilService perfilService;
        private readonly IAppContext2 appContext2;


        public FrmPerfilLista(IPerfilService perfilService, IAppContext2 appContext2)
        {
            this.perfilService = perfilService;
            this.appContext2 = appContext2;
            InitializeComponent();
        }

        private void FrmPerfilLista_Load(object sender, EventArgs e)
        {
            var perfiles = perfilService.GetAllAsNoTracking();
            int count = 0;
            foreach (PerfilDto perfil in perfiles)
            {
                Label PerfilName = new Label();
                PerfilName.Text = perfil.Descripcion;
                Label Horas = new Label();
                Horas.Text = perfil.ValorHorario.ToString();
                //Button Editar = new Button();
                //Editar.Margin = new Padding(0);
                //Editar.Text = "Editar";
                //Editar.Click += new System.EventHandler(this.btnEditar_Click);
                //Editar.Tag = perfil.ID;
                Button Borrar = new Button();
                Borrar.Margin = new Padding(0);
                Borrar.Text = "Borrar";
                Borrar.Tag = perfil.ID;
                Borrar.Click += new System.EventHandler(this.btnDelete_Click);


                ListaPerfilPanel1.Controls.Add(PerfilName,0,count);
                ListaPerfilPanel1.Controls.Add(Horas, 1, count);
                //ListaPerfilPanel1.Controls.Add(Editar, 2, count);
                ListaPerfilPanel1.Controls.Add(Borrar, 2, count);
                ListaPerfilPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                ListaPerfilPanel1.RowCount++;
                count++;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Reference the Button which was clicked.
            Button button = (sender as Button);
            int index = ListaPerfilPanel1.GetRow(button);
            perfilService.DeleteById((int)button.Tag);
            //ListaPerfilPanel1.SuspendLayout();
            Metodos.RemoveArbitraryRow(ListaPerfilPanel1, index);
            //ListaPerfilPanel1.ResumeLayout();
            //ListaPerfilPanel1.PerformLayout();
        }

        //private void btnEditar_Click(object sender, EventArgs e)
        //{
        //    Button button = (sender as Button);
        //    int index = ListaPerfilPanel1.GetRow(button);

        //}
    }
}
 
