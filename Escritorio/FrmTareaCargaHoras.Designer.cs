namespace Escritorio
{
    partial class FrmTareaCargaHoras
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
            this.TareacomboBox = new System.Windows.Forms.ComboBox();
            this.HsTrabajadNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CargarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HsTrabajadNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // TareacomboBox
            // 
            this.TareacomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TareacomboBox.FormattingEnabled = true;
            this.TareacomboBox.Location = new System.Drawing.Point(27, 35);
            this.TareacomboBox.Name = "TareacomboBox";
            this.TareacomboBox.Size = new System.Drawing.Size(166, 21);
            this.TareacomboBox.TabIndex = 0;
            this.TareacomboBox.Text = "Elija la tarea a la que le carga";
            this.TareacomboBox.SelectedIndexChanged += new System.EventHandler(this.TareacomboBox_SelectedIndexChanged);
            // 
            // HsTrabajadNumeric
            // 
            this.HsTrabajadNumeric.DecimalPlaces = 2;
            this.HsTrabajadNumeric.Location = new System.Drawing.Point(229, 35);
            this.HsTrabajadNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HsTrabajadNumeric.Name = "HsTrabajadNumeric";
            this.HsTrabajadNumeric.Size = new System.Drawing.Size(120, 20);
            this.HsTrabajadNumeric.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Horas Trabajadas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tarea";
            // 
            // CargarButton
            // 
            this.CargarButton.BackColor = System.Drawing.Color.MediumBlue;
            this.CargarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CargarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargarButton.ForeColor = System.Drawing.SystemColors.Window;
            this.CargarButton.Location = new System.Drawing.Point(156, 80);
            this.CargarButton.Name = "CargarButton";
            this.CargarButton.Size = new System.Drawing.Size(75, 28);
            this.CargarButton.TabIndex = 6;
            this.CargarButton.Text = "Cargar";
            this.CargarButton.UseVisualStyleBackColor = false;
            this.CargarButton.Click += new System.EventHandler(this.CargarButton_Click);
            // 
            // FrmTareaCargaHoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 138);
            this.Controls.Add(this.CargarButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HsTrabajadNumeric);
            this.Controls.Add(this.TareacomboBox);
            this.Name = "FrmTareaCargaHoras";
            this.Text = "FrmTareaCargaHoras";
            this.Load += new System.EventHandler(this.FrmTareaCargaHoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HsTrabajadNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TareacomboBox;
        private System.Windows.Forms.NumericUpDown HsTrabajadNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CargarButton;
    }
}