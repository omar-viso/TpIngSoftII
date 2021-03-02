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
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.ApellidoLabel = new System.Windows.Forms.Label();
            this.ApellidoTextBox = new System.Windows.Forms.TextBox();
            this.RazonSociallabel = new System.Windows.Forms.Label();
            this.RazonSocialtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DireccionTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.EMailTexbox = new System.Windows.Forms.TextBox();
            this.AgregarButton = new System.Windows.Forms.Button();
            this.DNI_CUIT_numeric = new System.Windows.Forms.NumericUpDown();
            this.TelefonoNumeric = new System.Windows.Forms.NumericUpDown();
            this.ElejirClienteComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DNI_CUIT_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TelefonoNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 19);
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
            this.TipoPersonaCombo.Location = new System.Drawing.Point(74, 45);
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
            // NombreTextBox
            // 
            this.NombreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NombreTextBox.Location = new System.Drawing.Point(76, 100);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(140, 20);
            this.NombreTextBox.TabIndex = 2;
            this.NombreTextBox.Tag = "";
            this.NombreTextBox.Visible = false;
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
            // ApellidoTextBox
            // 
            this.ApellidoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ApellidoTextBox.Location = new System.Drawing.Point(341, 100);
            this.ApellidoTextBox.Name = "ApellidoTextBox";
            this.ApellidoTextBox.Size = new System.Drawing.Size(140, 20);
            this.ApellidoTextBox.TabIndex = 4;
            this.ApellidoTextBox.Tag = "";
            this.ApellidoTextBox.Visible = false;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Dirección:";
            // 
            // DireccionTextBox
            // 
            this.DireccionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DireccionTextBox.Location = new System.Drawing.Point(351, 164);
            this.DireccionTextBox.Name = "DireccionTextBox";
            this.DireccionTextBox.Size = new System.Drawing.Size(140, 20);
            this.DireccionTextBox.TabIndex = 10;
            this.DireccionTextBox.Tag = "";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "E-mail:";
            // 
            // EMailTexbox
            // 
            this.EMailTexbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EMailTexbox.Location = new System.Drawing.Point(351, 214);
            this.EMailTexbox.Name = "EMailTexbox";
            this.EMailTexbox.Size = new System.Drawing.Size(140, 20);
            this.EMailTexbox.TabIndex = 14;
            this.EMailTexbox.Tag = "";
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
            this.AgregarButton.Text = "Aceptar";
            this.AgregarButton.UseVisualStyleBackColor = false;
            this.AgregarButton.Click += new System.EventHandler(this.AgregarButton_Click);
            // 
            // DNI_CUIT_numeric
            // 
            this.DNI_CUIT_numeric.Location = new System.Drawing.Point(76, 164);
            this.DNI_CUIT_numeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.DNI_CUIT_numeric.Name = "DNI_CUIT_numeric";
            this.DNI_CUIT_numeric.Size = new System.Drawing.Size(120, 20);
            this.DNI_CUIT_numeric.TabIndex = 17;
            // 
            // TelefonoNumeric
            // 
            this.TelefonoNumeric.Location = new System.Drawing.Point(76, 214);
            this.TelefonoNumeric.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.TelefonoNumeric.Name = "TelefonoNumeric";
            this.TelefonoNumeric.Size = new System.Drawing.Size(120, 20);
            this.TelefonoNumeric.TabIndex = 18;
            // 
            // ElejirClienteComboBox
            // 
            this.ElejirClienteComboBox.FormattingEnabled = true;
            this.ElejirClienteComboBox.Location = new System.Drawing.Point(215, 45);
            this.ElejirClienteComboBox.Name = "ElejirClienteComboBox";
            this.ElejirClienteComboBox.Size = new System.Drawing.Size(160, 21);
            this.ElejirClienteComboBox.TabIndex = 19;
            this.ElejirClienteComboBox.Text = "Cliente a cambiar...";
            this.ElejirClienteComboBox.SelectedIndexChanged += new System.EventHandler(this.ElejirClienteComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Si no elige cliente se creara uno nuevo";
            // 
            // FrmClienteAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 291);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ElejirClienteComboBox);
            this.Controls.Add(this.TelefonoNumeric);
            this.Controls.Add(this.DNI_CUIT_numeric);
            this.Controls.Add(this.AgregarButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.EMailTexbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DireccionTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RazonSociallabel);
            this.Controls.Add(this.RazonSocialtextBox);
            this.Controls.Add(this.ApellidoLabel);
            this.Controls.Add(this.ApellidoTextBox);
            this.Controls.Add(this.NombreLabel);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.TipoPersonaCombo);
            this.Controls.Add(this.label1);
            this.Name = "FrmClienteAgregar";
            this.Text = "FrmClienteAgregar";
            this.Load += new System.EventHandler(this.FrmClienteAgregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DNI_CUIT_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TelefonoNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TipoPersonaCombo;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label ApellidoLabel;
        private System.Windows.Forms.TextBox ApellidoTextBox;
        private System.Windows.Forms.Label RazonSociallabel;
        private System.Windows.Forms.TextBox RazonSocialtextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DireccionTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox EMailTexbox;
        private System.Windows.Forms.Button AgregarButton;
        private System.Windows.Forms.NumericUpDown DNI_CUIT_numeric;
        private System.Windows.Forms.NumericUpDown TelefonoNumeric;
        private System.Windows.Forms.ComboBox ElejirClienteComboBox;
        private System.Windows.Forms.Label label2;
    }
}
