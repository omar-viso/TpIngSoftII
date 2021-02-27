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
            var perfiles = perfilService.GetAll();
            int count = 0;
            foreach (PerfilDto perfil in perfiles)
            {
                Label PerfilName = new Label();
                PerfilName.Text = perfil.Descripcion;
                Label Horas = new Label();
                Horas.Text = perfil.ValorHorario.ToString();
                Button Editar = new Button();
                Editar.Text = "Editar";
                Button Borrar = new Button();
                Borrar.Text = "Borrar";
                ListaPerfilPanel1.Controls.Add(PerfilName,0,count);
                ListaPerfilPanel1.Controls.Add(Horas, 1, count);
                ListaPerfilPanel1.Controls.Add(Editar, 2, count);
                ListaPerfilPanel1.Controls.Add(Borrar, 3, count);
                ListaPerfilPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                count++;
            }

        }
    }
}
