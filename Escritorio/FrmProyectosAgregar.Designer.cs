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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CambiarEstadocomboBox = new System.Windows.Forms.ComboBox();
            this.AgregarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(110, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "";
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
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(316, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Elija un cliente";
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
            // 
            // FrmProyectosAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 231);
            this.Controls.Add(this.AgregarButton);
            this.Controls.Add(this.CambiarEstadocomboBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmProyectosAgregar";
            this.Text = "FrmProyectosAgregar";
            this.Load += new System.EventHandler(this.FrmProyectosAgregar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox CambiarEstadocomboBox;
        private System.Windows.Forms.Button AgregarButton;
    }
}