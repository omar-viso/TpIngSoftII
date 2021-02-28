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
    public partial class FrmPerfilesAgregar : Form
    {
        private readonly IPerfilService perfilService;
        private readonly IAppContext2 appContext2;

        public FrmPerfilesAgregar(IPerfilService perfilService, IAppContext2 appContext2)
        {
            this.perfilService = perfilService;
            this.appContext2 = appContext2;
            InitializeComponent();
        }

        private void FrmPerfilesAgregar_Load(object sender, EventArgs e)
        {

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
            var respuesta= perfilService.Update(perfilDto);
            if (respuesta != null)
            {
                MessageBox.Show("Perfil creado");
            }
            else
            {
                MessageBox.Show("No se a podido crear el perfil");
            }
            DescripcionText.Text = "";
            ValorHoraNumeric.Value = 0;
        }
    }
}
