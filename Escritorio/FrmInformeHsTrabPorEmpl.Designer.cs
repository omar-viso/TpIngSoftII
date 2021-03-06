namespace Escritorio
{
    partial class FrmInformeHsTrabPorEmpl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SolicitarButton = new System.Windows.Forms.Button();
            this.FinDatePicker = new System.Windows.Forms.DateTimePicker();
            this.InicioDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ListaHsTrabajProyectPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SolicitarButton);
            this.panel1.Controls.Add(this.FinDatePicker);
            this.panel1.Controls.Add(this.InicioDatePicker);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 56);
            this.panel1.TabIndex = 0;
            // 
            // SolicitarButton
            // 
            this.SolicitarButton.BackColor = System.Drawing.Color.MediumBlue;
            this.SolicitarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SolicitarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolicitarButton.ForeColor = System.Drawing.SystemColors.Window;
            this.SolicitarButton.Location = new System.Drawing.Point(492, 17);
            this.SolicitarButton.Name = "SolicitarButton";
            this.SolicitarButton.Size = new System.Drawing.Size(75, 28);
            this.SolicitarButton.TabIndex = 17;
            this.SolicitarButton.Text = "Solicitar";
            this.SolicitarButton.UseVisualStyleBackColor = false;
            this.SolicitarButton.Click += new System.EventHandler(this.SolicitarButton_Click);
            // 
            // FinDatePicker
            // 
            this.FinDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FinDatePicker.Location = new System.Drawing.Point(151, 25);
            this.FinDatePicker.Name = "FinDatePicker";
            this.FinDatePicker.Size = new System.Drawing.Size(82, 20);
            this.FinDatePicker.TabIndex = 3;
            this.FinDatePicker.Value = new System.DateTime(2021, 5, 1, 0, 0, 0, 0);
            // 
            // InicioDatePicker
            // 
            this.InicioDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.InicioDatePicker.Location = new System.Drawing.Point(30, 25);
            this.InicioDatePicker.Name = "InicioDatePicker";
            this.InicioDatePicker.Size = new System.Drawing.Size(82, 20);
            this.InicioDatePicker.TabIndex = 2;
            this.InicioDatePicker.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fin de periodo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio de periodo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(579, 42);
            this.panel2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(489, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 26);
            this.label6.TabIndex = 3;
            this.label6.Text = "Horas\r\nTrabajadas";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 26);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre\r\nEmpleado";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Perfil";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Proyecto";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.ListaHsTrabajProyectPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(579, 108);
            this.panel3.TabIndex = 8;
            // 
            // ListaHsTrabajProyectPanel1
            // 
            this.ListaHsTrabajProyectPanel1.AutoSize = true;
            this.ListaHsTrabajProyectPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ListaHsTrabajProyectPanel1.BackColor = System.Drawing.SystemColors.Menu;
            this.ListaHsTrabajProyectPanel1.ColumnCount = 4;
            this.ListaHsTrabajProyectPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.20119F));
            this.ListaHsTrabajProyectPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.79882F));
            this.ListaHsTrabajProyectPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.ListaHsTrabajProyectPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.ListaHsTrabajProyectPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.ListaHsTrabajProyectPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.ListaHsTrabajProyectPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.ListaHsTrabajProyectPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.ListaHsTrabajProyectPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.ListaHsTrabajProyectPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListaHsTrabajProyectPanel1.Location = new System.Drawing.Point(0, 0);
            this.ListaHsTrabajProyectPanel1.Name = "ListaHsTrabajProyectPanel1";
            this.ListaHsTrabajProyectPanel1.RowCount = 1;
            this.ListaHsTrabajProyectPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ListaHsTrabajProyectPanel1.Size = new System.Drawing.Size(579, 30);
            this.ListaHsTrabajProyectPanel1.TabIndex = 2;
            // 
            // FrmInformeHsTrabPorEmpl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 205);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmInformeHsTrabPorEmpl";
            this.Text = "FrmInformeHsTrabPorEmpl";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker FinDatePicker;
        private System.Windows.Forms.DateTimePicker InicioDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SolicitarButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel ListaHsTrabajProyectPanel1;
    }
}