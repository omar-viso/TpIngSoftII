namespace Escritorio
{
    partial class FrmClienteAgregar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TipoPersonaCombo = new System.Windows.Forms.ComboBox();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.NombretextBox = new System.Windows.Forms.TextBox();
            this.ApellidoLabel = new System.Windows.Forms.Label();
            this.ApellidotextBox = new System.Windows.Forms.TextBox();
            this.RazonSociallabel = new System.Windows.Forms.Label();
            this.RazonSocialtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.AgregarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de persona:";
            // 
            // TipoPersonaCombo
            // 
            this.TipoPersonaCombo.FormattingEnabled = true;
            this.TipoPersonaCombo.Items.AddRange(new object[] {
            "Fisica",
            "Juridica"});
            this.TipoPersonaCombo.Location = new System.Drawing.Point(226, 48);
            this.TipoPersonaCombo.Name = "TipoPersonaCombo";
            this.TipoPersonaCombo.Size = new System.Drawing.Size(128, 21);
            this.TipoPersonaCombo.TabIndex = 1;
            this.TipoPersonaCombo.Text = "Elija el tipo de persona";
            this.TipoPersonaCombo.SelectedIndexChanged += new System.EventHandler(this.TipoPersonaCombo_SelectedIndexChanged);
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Location = new System.Drawing.Point(73, 84);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(47, 13);
            this.NombreLabel.TabIndex = 3;
            this.NombreLabel.Text = "Nombre:";
            this.NombreLabel.Visible = false;
            // 
            // NombretextBox
            // 
            this.NombretextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NombretextBox.Location = new System.Drawing.Point(76, 100);
            this.NombretextBox.Name = "NombretextBox";
            this.NombretextBox.Size = new System.Drawing.Size(140, 20);
            this.NombretextBox.TabIndex = 2;
            this.NombretextBox.Tag = "";
            this.NombretextBox.Visible = false;
            // 
            // ApellidoLabel
            // 
            this.ApellidoLabel.AutoSize = true;
            this.ApellidoLabel.Location = new System.Drawing.Point(338, 84);
            this.ApellidoLabel.Name = "ApellidoLabel";
            this.ApellidoLabel.Size = new System.Drawing.Size(47, 13);
            this.ApellidoLabel.TabIndex = 5;
            this.ApellidoLabel.Text = "Apellido:";
            this.ApellidoLabel.Visible = false;
            // 
            // ApellidotextBox
            // 
            this.ApellidotextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ApellidotextBox.Location = new System.Drawing.Point(341, 100);
            this.ApellidotextBox.Name = "ApellidotextBox";
            this.ApellidotextBox.Size = new System.Drawing.Size(140, 20);
            this.ApellidotextBox.TabIndex = 4;
            this.ApellidotextBox.Tag = "";
            this.ApellidotextBox.Visible = false;
            // 
            // RazonSociallabel
            // 
            this.RazonSociallabel.AutoSize = true;
            this.RazonSociallabel.Location = new System.Drawing.Point(212, 107);
            this.RazonSociallabel.Name = "RazonSociallabel";
            this.RazonSociallabel.Size = new System.Drawing.Size(71, 13);
            this.RazonSociallabel.TabIndex = 7;
            this.RazonSociallabel.Text = "Razon social:";
            this.RazonSociallabel.Visible = false;
            // 
            // RazonSocialtextBox
            // 
            this.RazonSocialtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RazonSocialtextBox.Location = new System.Drawing.Point(215, 123);
            this.RazonSocialtextBox.Name = "RazonSocialtextBox";
            this.RazonSocialtextBox.Size = new System.Drawing.Size(140, 20);
            this.RazonSocialtextBox.TabIndex = 6;
            this.RazonSocialtextBox.Tag = "";
            this.RazonSocialtextBox.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "DNI/CUIT:";
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Location = new System.Drawing.Point(76, 164);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(140, 20);
            this.textBox4.TabIndex = 8;
            this.textBox4.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Dirección:";
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Location = new System.Drawing.Point(351, 164);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(140, 20);
            this.textBox5.TabIndex = 10;
            this.textBox5.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Telefono de contacto:";
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Location = new System.Drawing.Point(76, 214);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(140, 20);
            this.textBox6.TabIndex = 12;
            this.textBox6.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "E-mail:";
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Location = new System.Drawing.Point(351, 214);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(140, 20);
            this.textBox7.TabIndex = 14;
            this.textBox7.Tag = "";
            // 
            // AgregarButton
            // 
            this.AgregarButton.BackColor = System.Drawing.Color.MediumBlue;
            this.AgregarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AgregarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarButton.ForeColor = System.Drawing.SystemColors.Window;
            this.AgregarButton.Location = new System.Drawing.Point(244, 251);
            this.AgregarButton.Name = "AgregarButton";
            this.AgregarButton.Size = new System.Drawing.Size(75, 28);
            this.AgregarButton.TabIndex = 16;
            this.AgregarButton.Text = "Agregar";
            this.AgregarButton.UseVisualStyleBackColor = false;
            // 
            // FrmClienteAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 291);
            this.Controls.Add(this.AgregarButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.RazonSociallabel);
            this.Controls.Add(this.RazonSocialtextBox);
            this.Controls.Add(this.ApellidoLabel);
            this.Controls.Add(this.ApellidotextBox);
            this.Controls.Add(this.NombreLabel);
            this.Controls.Add(this.NombretextBox);
            this.Controls.Add(this.TipoPersonaCombo);
            this.Controls.Add(this.label1);
            this.Name = "FrmClienteAgregar";
            this.Text = "FrmClienteAgregar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TipoPersonaCombo;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.TextBox NombretextBox;
        private System.Windows.Forms.Label ApellidoLabel;
        private System.Windows.Forms.TextBox ApellidotextBox;
        private System.Windows.Forms.Label RazonSociallabel;
        private System.Windows.Forms.TextBox RazonSocialtextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button AgregarButton;
    }
}
