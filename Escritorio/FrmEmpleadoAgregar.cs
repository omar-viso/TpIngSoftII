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
    public partial class FrmEmpleadoAgregar : Form
    {
    

        public FrmEmpleadoAgregar()
        {
            InitializeComponent();
        }
        private void FrmEmpleadoAgregar_Load(object sender, EventArgs e)
        {
            AgregarBotonElejirPerfil();
        }

        private void AgregarPerfilButton_Click(object sender, EventArgs e)
        {
            AgregarBotonElejirPerfil();
        }
        private void AgregarBotonElejirPerfil()
        {
            //Create the dynamic TextBox.
            ComboBox ElejirPerfil = new ComboBox();
            int count = PerfilPanel.Controls.OfType<ComboBox>().ToList().Count;
            ElejirPerfil.Location = new System.Drawing.Point(26, 25 * count);
            ElejirPerfil.Size = new System.Drawing.Size(128, 21);
            ElejirPerfil.Name = "ElejirPerfil_" + (count + 1);
            ElejirPerfil.Text = "Elija un perfil";
            ElejirPerfil.Items.Add(new Point(1, 1));
            PerfilPanel.Controls.Add(ElejirPerfil);

            //Create the dynamic Button to remove the TextBox.
            Button button = new Button();
            button.Location = new System.Drawing.Point(172, 25 * count);
            button.Size = new System.Drawing.Size(21, 25);
            button.Name = "btnDelete_" + (count + 1);
            button.ForeColor = Color.Red;
            button.BackColor = PerfilPanel.BackColor;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.BorderColor = button.BackColor;
            button.FlatStyle = FlatStyle.Flat;
            button.Text = "X";
            button.Click += new System.EventHandler(this.btnDelete_Click);
            PerfilPanel.Controls.Add(button);
        }


        private void PerfilPanel_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (PerfilPanel.Controls.OfType<ComboBox>().ToList().Count > 1)
            {
                //Reference the Button which was clicked.
                Button button = (sender as Button);

                //Determine the Index of the Button.
                int index = int.Parse(button.Name.Split('_')[1]);

                //Find the TextBox using Index and remove it.
                PerfilPanel.Controls.Remove(PerfilPanel.Controls.Find("ElejirPerfil_" + index, true)[0]);

                //Remove the Button.
                PerfilPanel.Controls.Remove(button);

                //Rearranging the Location controls.
                foreach (Button btn in PerfilPanel.Controls.OfType<Button>())
                {
                    int controlIndex = int.Parse(btn.Name.Split('_')[1]);
                    if (controlIndex > index)
                    {
                        ComboBox txt = (ComboBox)PerfilPanel.Controls.Find("ElejirPerfil_" + controlIndex, true)[0];
                        btn.Top = btn.Top - 25;
                        txt.Top = txt.Top - 25;
                    }
                }
            }
        }

        
    }

   
}
