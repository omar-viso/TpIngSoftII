using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class FrmClienteAgregar : Form
    {
        public FrmClienteAgregar()
        {
            InitializeComponent();
        }

        private void TipoPersonaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (TipoPersonaCombo.SelectedItem.Equals("Fisica"))
            {
                NombreLabel.Visible = true;
                NombretextBox.Visible = true;
                ApellidoLabel.Visible = true;
                ApellidotextBox.Visible = true;

                RazonSociallabel.Visible = false;
                RazonSocialtextBox.Visible = false;
            }
            else
            {
                RazonSociallabel.Visible = true;
                RazonSocialtextBox.Visible = true;

                NombreLabel.Visible = false;
                NombretextBox.Visible = false;
                ApellidoLabel.Visible = false;
                ApellidotextBox.Visible = false;
            }
        }
    }
}
