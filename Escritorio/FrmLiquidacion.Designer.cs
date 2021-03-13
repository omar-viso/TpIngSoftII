namespace Escritorio
{
    partial class FrmLiquidacion
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
            this.FinDatePicker = new System.Windows.Forms.DateTimePicker();
            this.InicioDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EmpleadocomboBox = new System.Windows.Forms.ComboBox();
            this.LiquidacionButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListaEmpleadoPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.PorcentCantPerfilesLabel = new System.Windows.Forms.Label();
            this.PorcentHsTotalesLabel = new System.Windows.Forms.Label();
            this.PorcentAntigueadadLabel = new System.Windows.Forms.Label();
            this.TareasLabel = new System.Windows.Forms.Label();
            this.ProyectosLabel = new System.Windows.Forms.Label();
            this.PerfilesLabel = new System.Windows.Forms.Label();
            this.HsTotalesLabel = new System.Windows.Forms.Label();
            this.HsOBLabel = new System.Windows.Forms.Label();
            this.HsNoOBLabel = new System.Windows.Forms.Label();
            this.AntiguedadLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ReporteButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.ListaEmpleadoPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FinDatePicker
            // 
            this.FinDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FinDatePicker.Location = new System.Drawing.Point(476, 22);
            this.FinDatePicker.Name = "FinDatePicker";
            this.FinDatePicker.Size = new System.Drawing.Size(82, 20);
            this.FinDatePicker.TabIndex = 7;
            // 
            // InicioDatePicker
            // 
            this.InicioDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.InicioDatePicker.Location = new System.Drawing.Point(142, 22);
            this.InicioDatePicker.Name = "InicioDatePicker";
            this.InicioDatePicker.Size = new System.Drawing.Size(82, 20);
            this.InicioDatePicker.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fin de periodo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inicio de periodo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Empleado";
            // 
            // EmpleadocomboBox
            // 
            this.EmpleadocomboBox.FormattingEnabled = true;
            this.EmpleadocomboBox.Location = new System.Drawing.Point(88, 91);
            this.EmpleadocomboBox.Name = "EmpleadocomboBox";
            this.EmpleadocomboBox.Size = new System.Drawing.Size(121, 21);
            this.EmpleadocomboBox.TabIndex = 9;
            this.EmpleadocomboBox.SelectedIndexChanged += new System.EventHandler(this.EmpleadocomboBox_SelectedIndexChanged);
            // 
            // LiquidacionButton
            // 
            this.LiquidacionButton.BackColor = System.Drawing.Color.MediumBlue;
            this.LiquidacionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LiquidacionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LiquidacionButton.ForeColor = System.Drawing.SystemColors.Window;
            this.LiquidacionButton.Location = new System.Drawing.Point(483, 75);
            this.LiquidacionButton.Name = "LiquidacionButton";
            this.LiquidacionButton.Size = new System.Drawing.Size(101, 28);
            this.LiquidacionButton.TabIndex = 18;
            this.LiquidacionButton.Text = "Liquidacion";
            this.LiquidacionButton.UseVisualStyleBackColor = false;
            this.LiquidacionButton.Click += new System.EventHandler(this.LiquidacionButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Antigüedad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(104, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 39);
            this.label5.TabIndex = 20;
            this.label5.Text = "Hs\r\nNo\r\nOb";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(139, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 39);
            this.label6.TabIndex = 21;
            this.label6.Text = "Hs\r\nOB\r\n(50%)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(183, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 26);
            this.label7.TabIndex = 22;
            this.label7.Text = "Hs\r\nTotales";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(255, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Perfiles";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(350, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Proyectos";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(446, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Tareas";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(511, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "% Antigüedad";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(590, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 52);
            this.label12.TabIndex = 27;
            this.label12.Text = "%\r\ntotal\r\nde\r\nhoras";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(643, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 39);
            this.label13.TabIndex = 28;
            this.label13.Text = "% cant.\r\nde\r\nperfiles";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(709, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Total";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ReporteButton);
            this.panel1.Controls.Add(this.LiquidacionButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.EmpleadocomboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.FinDatePicker);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.InicioDatePicker);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 184);
            this.panel1.TabIndex = 30;
            // 
            // ListaEmpleadoPanel1
            // 
            this.ListaEmpleadoPanel1.AutoSize = true;
            this.ListaEmpleadoPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ListaEmpleadoPanel1.BackColor = System.Drawing.SystemColors.Menu;
            this.ListaEmpleadoPanel1.ColumnCount = 11;
            this.ListaEmpleadoPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.47369F));
            this.ListaEmpleadoPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.52632F));
            this.ListaEmpleadoPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.ListaEmpleadoPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.ListaEmpleadoPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.ListaEmpleadoPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.ListaEmpleadoPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.ListaEmpleadoPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.ListaEmpleadoPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.ListaEmpleadoPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.ListaEmpleadoPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.ListaEmpleadoPanel1.Controls.Add(this.TotalLabel, 10, 0);
            this.ListaEmpleadoPanel1.Controls.Add(this.PorcentCantPerfilesLabel, 9, 0);
            this.ListaEmpleadoPanel1.Controls.Add(this.PorcentHsTotalesLabel, 8, 0);
            this.ListaEmpleadoPanel1.Controls.Add(this.PorcentAntigueadadLabel, 7, 0);
            this.ListaEmpleadoPanel1.Controls.Add(this.TareasLabel, 6, 0);
            this.ListaEmpleadoPanel1.Controls.Add(this.ProyectosLabel, 5, 0);
            this.ListaEmpleadoPanel1.Controls.Add(this.PerfilesLabel, 4, 0);
            this.ListaEmpleadoPanel1.Controls.Add(this.HsTotalesLabel, 3, 0);
            this.ListaEmpleadoPanel1.Controls.Add(this.HsOBLabel, 2, 0);
            this.ListaEmpleadoPanel1.Controls.Add(this.HsNoOBLabel, 1, 0);
            this.ListaEmpleadoPanel1.Controls.Add(this.AntiguedadLabel, 0, 0);
            this.ListaEmpleadoPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListaEmpleadoPanel1.Location = new System.Drawing.Point(0, 0);
            this.ListaEmpleadoPanel1.Name = "ListaEmpleadoPanel1";
            this.ListaEmpleadoPanel1.RowCount = 1;
            this.ListaEmpleadoPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ListaEmpleadoPanel1.Size = new System.Drawing.Size(753, 30);
            this.ListaEmpleadoPanel1.TabIndex = 2;
            // 
            // TotalLabel
            // 
            this.TotalLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(724, 8);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(13, 13);
            this.TotalLabel.TabIndex = 42;
            this.TotalLabel.Text = "0";
            this.TotalLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PorcentCantPerfilesLabel
            // 
            this.PorcentCantPerfilesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PorcentCantPerfilesLabel.AutoSize = true;
            this.PorcentCantPerfilesLabel.Location = new System.Drawing.Point(667, 8);
            this.PorcentCantPerfilesLabel.Name = "PorcentCantPerfilesLabel";
            this.PorcentCantPerfilesLabel.Size = new System.Drawing.Size(13, 13);
            this.PorcentCantPerfilesLabel.TabIndex = 41;
            this.PorcentCantPerfilesLabel.Text = "0";
            this.PorcentCantPerfilesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PorcentHsTotalesLabel
            // 
            this.PorcentHsTotalesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PorcentHsTotalesLabel.AutoSize = true;
            this.PorcentHsTotalesLabel.Location = new System.Drawing.Point(606, 8);
            this.PorcentHsTotalesLabel.Name = "PorcentHsTotalesLabel";
            this.PorcentHsTotalesLabel.Size = new System.Drawing.Size(13, 13);
            this.PorcentHsTotalesLabel.TabIndex = 40;
            this.PorcentHsTotalesLabel.Text = "0";
            this.PorcentHsTotalesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PorcentAntigueadadLabel
            // 
            this.PorcentAntigueadadLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PorcentAntigueadadLabel.AutoSize = true;
            this.PorcentAntigueadadLabel.Location = new System.Drawing.Point(544, 8);
            this.PorcentAntigueadadLabel.Name = "PorcentAntigueadadLabel";
            this.PorcentAntigueadadLabel.Size = new System.Drawing.Size(13, 13);
            this.PorcentAntigueadadLabel.TabIndex = 39;
            this.PorcentAntigueadadLabel.Text = "0";
            this.PorcentAntigueadadLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TareasLabel
            // 
            this.TareasLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TareasLabel.AutoSize = true;
            this.TareasLabel.Location = new System.Drawing.Point(463, 8);
            this.TareasLabel.Name = "TareasLabel";
            this.TareasLabel.Size = new System.Drawing.Size(13, 13);
            this.TareasLabel.TabIndex = 38;
            this.TareasLabel.Text = "0";
            this.TareasLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ProyectosLabel
            // 
            this.ProyectosLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProyectosLabel.AutoSize = true;
            this.ProyectosLabel.Location = new System.Drawing.Point(372, 8);
            this.ProyectosLabel.Name = "ProyectosLabel";
            this.ProyectosLabel.Size = new System.Drawing.Size(13, 13);
            this.ProyectosLabel.TabIndex = 37;
            this.ProyectosLabel.Text = "0";
            this.ProyectosLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PerfilesLabel
            // 
            this.PerfilesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PerfilesLabel.AutoSize = true;
            this.PerfilesLabel.Location = new System.Drawing.Point(278, 8);
            this.PerfilesLabel.Name = "PerfilesLabel";
            this.PerfilesLabel.Size = new System.Drawing.Size(13, 13);
            this.PerfilesLabel.TabIndex = 36;
            this.PerfilesLabel.Text = "0";
            this.PerfilesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HsTotalesLabel
            // 
            this.HsTotalesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HsTotalesLabel.AutoSize = true;
            this.HsTotalesLabel.Location = new System.Drawing.Point(203, 8);
            this.HsTotalesLabel.Name = "HsTotalesLabel";
            this.HsTotalesLabel.Size = new System.Drawing.Size(13, 13);
            this.HsTotalesLabel.TabIndex = 35;
            this.HsTotalesLabel.Text = "0";
            this.HsTotalesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HsOBLabel
            // 
            this.HsOBLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HsOBLabel.AutoSize = true;
            this.HsOBLabel.Location = new System.Drawing.Point(148, 8);
            this.HsOBLabel.Name = "HsOBLabel";
            this.HsOBLabel.Size = new System.Drawing.Size(13, 13);
            this.HsOBLabel.TabIndex = 34;
            this.HsOBLabel.Text = "0";
            this.HsOBLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HsNoOBLabel
            // 
            this.HsNoOBLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HsNoOBLabel.AutoSize = true;
            this.HsNoOBLabel.Location = new System.Drawing.Point(98, 8);
            this.HsNoOBLabel.Name = "HsNoOBLabel";
            this.HsNoOBLabel.Size = new System.Drawing.Size(13, 13);
            this.HsNoOBLabel.TabIndex = 33;
            this.HsNoOBLabel.Text = "0";
            this.HsNoOBLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AntiguedadLabel
            // 
            this.AntiguedadLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AntiguedadLabel.AutoSize = true;
            this.AntiguedadLabel.Location = new System.Drawing.Point(34, 8);
            this.AntiguedadLabel.Name = "AntiguedadLabel";
            this.AntiguedadLabel.Size = new System.Drawing.Size(13, 13);
            this.AntiguedadLabel.TabIndex = 32;
            this.AntiguedadLabel.Text = "0";
            this.AntiguedadLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.panel2.Controls.Add(this.ListaEmpleadoPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(753, 41);
            this.panel2.TabIndex = 31;
            // 
            // ReporteButton
            // 
            this.ReporteButton.Location = new System.Drawing.Point(677, 6);
            this.ReporteButton.Name = "ReporteButton";
            this.ReporteButton.Size = new System.Drawing.Size(68, 23);
            this.ReporteButton.TabIndex = 32;
            this.ReporteButton.Text = "Reporte";
            this.ReporteButton.UseVisualStyleBackColor = true;
            this.ReporteButton.Click += new System.EventHandler(this.ReporteButton_Click);
            // 
            // FrmLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 224);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmLiquidacion";
            this.Text = "FrmLiquidacion";
            this.Load += new System.EventHandler(this.FrmLiquidacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ListaEmpleadoPanel1.ResumeLayout(false);
            this.ListaEmpleadoPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FinDatePicker;
        private System.Windows.Forms.DateTimePicker InicioDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox EmpleadocomboBox;
        private System.Windows.Forms.Button LiquidacionButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel ListaEmpleadoPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.Label PorcentCantPerfilesLabel;
        private System.Windows.Forms.Label PorcentHsTotalesLabel;
        private System.Windows.Forms.Label PorcentAntigueadadLabel;
        private System.Windows.Forms.Label TareasLabel;
        private System.Windows.Forms.Label ProyectosLabel;
        private System.Windows.Forms.Label PerfilesLabel;
        private System.Windows.Forms.Label HsTotalesLabel;
        private System.Windows.Forms.Label HsOBLabel;
        private System.Windows.Forms.Label HsNoOBLabel;
        private System.Windows.Forms.Label AntiguedadLabel;
        private System.Windows.Forms.Button ReporteButton;
    }
}