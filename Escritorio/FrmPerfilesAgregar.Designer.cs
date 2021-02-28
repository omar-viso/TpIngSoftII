namespace Escritorio
{
    partial class FrmPerfilesAgregar
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
            this.DescripcionText = new System.Windows.Forms.TextBox();
            this.AgregarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ValorHoraNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ValorHoraNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // DescripcionText
            // 
            this.DescripcionText.Location = new System.Drawing.Point(55, 50);
            this.DescripcionText.Name = "DescripcionText";
            this.DescripcionText.Size = new System.Drawing.Size(164, 20);
            this.DescripcionText.TabIndex = 0;
            // 
            // AgregarButton
            // 
            this.AgregarButton.BackColor = System.Drawing.Color.MediumBlue;
            this.AgregarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AgregarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarButton.ForeColor = System.Drawing.SystemColors.Window;
            this.AgregarButton.Location = new System.Drawing.Point(219, 89);
            this.AgregarButton.Name = "AgregarButton";
            this.AgregarButton.Size = new System.Drawing.Size(75, 28);
            this.AgregarButton.TabIndex = 5;
            this.AgregarButton.Text = "Agregar";
            this.AgregarButton.UseVisualStyleBackColor = false;
            this.AgregarButton.Click += new System.EventHandler(this.AgregarButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Decripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Valor Hora:";
            // 
            // ValorHoraNumeric
            // 
            this.ValorHoraNumeric.DecimalPlaces = 2;
            this.ValorHoraNumeric.Location = new System.Drawing.Point(277, 50);
            this.ValorHoraNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.ValorHoraNumeric.Name = "ValorHoraNumeric";
            this.ValorHoraNumeric.Size = new System.Drawing.Size(120, 20);
            this.ValorHoraNumeric.TabIndex = 8;
            // 
            // FrmPerfilesAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 141);
            this.Controls.Add(this.ValorHoraNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AgregarButton);
            this.Controls.Add(this.DescripcionText);
            this.Name = "FrmPerfilesAgregar";
            this.Text = "FrmPerfilesAgregar";
            this.Load += new System.EventHandler(this.FrmPerfilesAgregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ValorHoraNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DescripcionText;
        private System.Windows.Forms.Button AgregarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ValorHoraNumeric;
    }
}