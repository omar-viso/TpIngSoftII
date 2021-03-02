namespace Escritorio
{
    partial class FrmProyectosAgregar
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
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ElejirClienteComboBox = new System.Windows.Forms.ComboBox();
            this.CambiarEstadocomboBox = new System.Windows.Forms.ComboBox();
            this.AgregarButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ElegirProyectocomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NombreTextBox.Location = new System.Drawing.Point(110, 77);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(140, 20);
            this.NombreTextBox.TabIndex = 0;
            this.NombreTextBox.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // ElejirClienteComboBox
            // 
            this.ElejirClienteComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ElejirClienteComboBox.FormattingEnabled = true;
            this.ElejirClienteComboBox.Location = new System.Drawing.Point(316, 76);
            this.ElejirClienteComboBox.Name = "ElejirClienteComboBox";
            this.ElejirClienteComboBox.Size = new System.Drawing.Size(121, 21);
            this.ElejirClienteComboBox.TabIndex = 2;
            this.ElejirClienteComboBox.Text = "Elija un cliente";
            this.ElejirClienteComboBox.SelectedIndexChanged += new System.EventHandler(this.ElejirClienteComboBox_SelectedIndexChanged);
            // 
            // CambiarEstadocomboBox
            // 
            this.CambiarEstadocomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CambiarEstadocomboBox.FormattingEnabled = true;
            this.CambiarEstadocomboBox.Location = new System.Drawing.Point(183, 120);
            this.CambiarEstadocomboBox.Name = "CambiarEstadocomboBox";
            this.CambiarEstadocomboBox.Size = new System.Drawing.Size(180, 21);
            this.CambiarEstadocomboBox.TabIndex = 3;
            this.CambiarEstadocomboBox.Text = "Cambie el estado de su proyecto";
            this.CambiarEstadocomboBox.SelectedIndexChanged += new System.EventHandler(this.CambiarEstadocomboBox_SelectedIndexChanged);
            // 
            // AgregarButton
            // 
            this.AgregarButton.BackColor = System.Drawing.Color.MediumBlue;
            this.AgregarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AgregarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarButton.ForeColor = System.Drawing.SystemColors.Window;
            this.AgregarButton.Location = new System.Drawing.Point(223, 157);
            this.AgregarButton.Name = "AgregarButton";
            this.AgregarButton.Size = new System.Drawing.Size(75, 28);
            this.AgregarButton.TabIndex = 4;
            this.AgregarButton.Text = "Agregar";
            this.AgregarButton.UseVisualStyleBackColor = false;
            this.AgregarButton.Click += new System.EventHandler(this.AgregarButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Si no elige proyecto se creara uno nuevo";
            // 
            // ElegirProyectocomboBox
            // 
            this.ElegirProyectocomboBox.FormattingEnabled = true;
            this.ElegirProyectocomboBox.Location = new System.Drawing.Point(110, 27);
            this.ElegirProyectocomboBox.Name = "ElegirProyectocomboBox";
            this.ElegirProyectocomboBox.Size = new System.Drawing.Size(160, 21);
            this.ElegirProyectocomboBox.TabIndex = 22;
            this.ElegirProyectocomboBox.Text = "Proyecto a cambiar...";
            this.ElegirProyectocomboBox.SelectedIndexChanged += new System.EventHandler(this.ElegirProyectocomboBox_SelectedIndexChanged);
            // 
            // FrmProyectosAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 231);
            this.Controls.Add(this.ElegirProyectocomboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AgregarButton);
            this.Controls.Add(this.CambiarEstadocomboBox);
            this.Controls.Add(this.ElejirClienteComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NombreTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmProyectosAgregar";
            this.Text = "FrmProyectosAgregar";
            this.Load += new System.EventHandler(this.FrmProyectosAgregar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ElejirClienteComboBox;
        private System.Windows.Forms.ComboBox CambiarEstadocomboBox;
        private System.Windows.Forms.Button AgregarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ElegirProyectocomboBox;
    }
}