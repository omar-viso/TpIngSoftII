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
    public partial class FrmPerfilesAgregar : Form
    {
        //private readonly IPerfilService perfilService;
        //private readonly IAppContext2 appContext2;
        private readonly Container container;
        private int ID=0;


        public FrmPerfilesAgregar(/*IPerfilService perfilService, IAppContext2 appContext2*/Container container)
        {
            //this.perfilService = perfilService;
            //this.appContext2 = appContext2;
            this.container = container;
            InitializeComponent();
        }

        private void FrmPerfilesAgregar_Load(object sender, EventArgs e)
        {
            CargarListaPerfiles();
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            
            if(DescripcionText.Text == "" || ValorHoraNumeric.Value == 0)
            {
                MessageBox.Show("Por favor complete la descripción de su perfil y el valor horario");
                return;
            }
            PerfilDto perfilDto = new PerfilDto();
            perfilDto.Descripcion = DescripcionText.Text;
            perfilDto.ValorHorario = ValorHoraNumeric.Value;
            if (ID != 0)
            {
                var perfilAeditar = container.GetInstance<IPerfilService>().GetByIdAsNoTracking(ID);
                perfilAeditar.Descripcion = DescripcionText.Text;
                perfilAeditar.ValorHorario = ValorHoraNumeric.Value;
                var respuesta = container.GetInstance<IPerfilService>().Update(perfilAeditar);
                
                if (respuesta != null)
                {
                    MessageBox.Show("Perfil editado");
                }
                else
                {
                    MessageBox.Show("No se a podido editar el perfil");
                }
                
                ID = 0;
                ElejirPerfilcomboBox.ResetText();
                ElejirPerfilcomboBox.Items.Clear();
                CargarListaPerfiles();
                container.GetInstance<IPerfilService>().Limpiar();
            }
            else
            {
                var respuesta = container.GetInstance<IPerfilService>().Update(perfilDto);
                if (respuesta != null)
                {
                    MessageBox.Show("Perfil creado");
                }
                else
                {
                    MessageBox.Show("No se a podido crear el perfil");
                }
                container.GetInstance<IPerfilService>().Limpiar();
            }
            DescripcionText.Text = "";
            ValorHoraNumeric.Value = 0;
        }

        private void ElejirPerfilcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PerfilDto perfilElegido = null;
            var perfiles = container.GetInstance<IPerfilService>().GetAllAsNoTracking();
            foreach (PerfilDto perfil in perfiles)
            {
                if (ElejirPerfilcomboBox.SelectedItem.ToString() == perfil.Descripcion)
                {
                    DescripcionText.Text = perfil.Descripcion;
                    ValorHoraNumeric.Value = perfil.ValorHorario;
                    ID=perfil.ID;
                }
            }
            //if (perfilElegido != null)
            //{
            //    DescripcionText.Text = perfilElegido.Descripcion;
            //    ValorHoraNumeric.Value = perfilElegido.ValorHorario;
            //}
        }

        private void CargarListaPerfiles()
        {
            var perfiles = container.GetInstance<IPerfilService>().GetAllAsNoTracking();
            foreach (PerfilDto perfil in perfiles)
            {
                ElejirPerfilcomboBox.Items.Add(perfil.Descripcion);
            }
        }
    }
}
