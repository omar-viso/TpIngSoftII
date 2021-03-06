namespace Escritorio
{
    partial class FrmTareaAgregar
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
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.ElegirProyectocomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ElejirPerfilcomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ElegirEmpleadocomboBox = new System.Windows.Forms.ComboBox();
            this.HorasEstimNumeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.AgregarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HorasEstimNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre:";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NombreTextBox.Location = new System.Drawing.Point(45, 52);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(140, 20);
            this.NombreTextBox.TabIndex = 2;
            this.NombreTextBox.Tag = "";
            // 
            // ElegirProyectocomboBox
            // 
            this.ElegirProyectocomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ElegirProyectocomboBox.FormattingEnabled = true;
            this.ElegirProyectocomboBox.Location = new System.Drawing.Point(285, 51);
            this.ElegirProyectocomboBox.Name = "ElegirProyectocomboBox";
            this.ElegirProyectocomboBox.Size = new System.Drawing.Size(163, 21);
            this.ElegirProyectocomboBox.TabIndex = 4;
            this.ElegirProyectocomboBox.Text = "Elija un proyecto";
            this.ElegirProyectocomboBox.SelectedIndexChanged += new System.EventHandler(this.ElegirProyectocomboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pertenece al proyecto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Perfil para la tarea:";
            // 
            // ElejirPerfilcomboBox
            // 
            this.ElejirPerfilcomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ElejirPerfilcomboBox.FormattingEnabled = true;
            this.ElejirPerfilcomboBox.Location = new System.Drawing.Point(45, 130);
            this.ElejirPerfilcomboBox.Name = "ElejirPerfilcomboBox";
            this.ElejirPerfilcomboBox.Size = new System.Drawing.Size(163, 21);
            this.ElejirPerfilcomboBox.TabIndex = 7;
            this.ElejirPerfilcomboBox.Text = "Elija un perfil";
            this.ElejirPerfilcomboBox.SelectedIndexChanged += new System.EventHandler(this.ElejirPerfilcomboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Pertenece al empleado:";
            // 
            // ElegirEmpleadocomboBox
            // 
            this.ElegirEmpleadocomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ElegirEmpleadocomboBox.FormattingEnabled = true;
            this.ElegirEmpleadocomboBox.Location = new System.Drawing.Point(285, 124);
            this.ElegirEmpleadocomboBox.Name = "ElegirEmpleadocomboBox";
            this.ElegirEmpleadocomboBox.Size = new System.Drawing.Size(163, 21);
            this.ElegirEmpleadocomboBox.TabIndex = 8;
            this.ElegirEmpleadocomboBox.Text = "Elija un empleado";
            this.ElegirEmpleadocomboBox.SelectedIndexChanged += new System.EventHandler(this.ElegirEmpleadocomboBox_SelectedIndexChanged);
            // 
            // HorasEstimNumeric
            // 
            this.HorasEstimNumeric.DecimalPlaces = 2;
            this.HorasEstimNumeric.Location = new System.Drawing.Point(179, 203);
            this.HorasEstimNumeric.Name = "HorasEstimNumeric";
            this.HorasEstimNumeric.Size = new System.Drawing.Size(120, 20);
            this.HorasEstimNumeric.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Horas estimadas:";
            // 
            // AgregarButton
            // 
            this.AgregarButton.BackColor = System.Drawing.Color.MediumBlue;
            this.AgregarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AgregarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarButton.ForeColor = System.Drawing.SystemColors.Window;
            this.AgregarButton.Location = new System.Drawing.Point(189, 239);
            this.AgregarButton.Name = "AgregarButton";
            this.AgregarButton.Size = new System.Drawing.Size(75, 28);
            this.AgregarButton.TabIndex = 12;
            this.AgregarButton.Text = "Agregar";
            this.AgregarButton.UseVisualStyleBackColor = false;
            this.AgregarButton.Click += new System.EventHandler(this.AgregarButton_Click);
            // 
            // FrmTareaAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 293);
            this.Controls.Add(this.AgregarButton);
            this.Controls.Add(this.HorasEstimNumeric);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ElegirEmpleadocomboBox);
            this.Controls.Add(this.ElejirPerfilcomboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ElegirProyectocomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NombreTextBox);
            this.Name = "FrmTareaAgregar";
            this.Text = "FrmTareaAgregar";
            this.Load += new System.EventHandler(this.FrmTareaAgregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HorasEstimNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.ComboBox ElegirProyectocomboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ElejirPerfilcomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ElegirEmpleadocomboBox;
        private System.Windows.Forms.NumericUpDown HorasEstimNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AgregarButton;
    }
}