namespace Comp_Grafica1
{
    partial class Trapecio
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
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.lblBaseMenor = new System.Windows.Forms.Label();
            this.txtBaseMenor = new System.Windows.Forms.TextBox();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblTrapecio = new System.Windows.Forms.Label();
            this.txtBaseMayor = new System.Windows.Forms.TextBox();
            this.lblBaseMayor = new System.Windows.Forms.Label();
            this.btnTrapecio = new System.Windows.Forms.Button();
            this.lblLado = new System.Windows.Forms.Label();
            this.txtLado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(455, 228);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(138, 26);
            this.txtAltura.TabIndex = 25;
            // 
            // lblBaseMenor
            // 
            this.lblBaseMenor.AutoSize = true;
            this.lblBaseMenor.Location = new System.Drawing.Point(124, 180);
            this.lblBaseMenor.Name = "lblBaseMenor";
            this.lblBaseMenor.Size = new System.Drawing.Size(290, 20);
            this.lblBaseMenor.TabIndex = 24;
            this.lblBaseMenor.Text = "Ingrese el tamaño de la base menor (b):";
            // 
            // txtBaseMenor
            // 
            this.txtBaseMenor.Location = new System.Drawing.Point(455, 174);
            this.txtBaseMenor.Name = "txtBaseMenor";
            this.txtBaseMenor.Size = new System.Drawing.Size(138, 26);
            this.txtBaseMenor.TabIndex = 23;
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(168, 234);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(246, 20);
            this.lblAltura.TabIndex = 22;
            this.lblAltura.Text = "Ingrese el tamaño de la altura (h):";
            // 
            // lblTrapecio
            // 
            this.lblTrapecio.AutoSize = true;
            this.lblTrapecio.Font = new System.Drawing.Font("Mongolian Baiti", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrapecio.Location = new System.Drawing.Point(285, 23);
            this.lblTrapecio.Name = "lblTrapecio";
            this.lblTrapecio.Size = new System.Drawing.Size(186, 46);
            this.lblTrapecio.TabIndex = 21;
            this.lblTrapecio.Text = "Trapecio";
            // 
            // txtBaseMayor
            // 
            this.txtBaseMayor.Location = new System.Drawing.Point(455, 118);
            this.txtBaseMayor.Name = "txtBaseMayor";
            this.txtBaseMayor.Size = new System.Drawing.Size(138, 26);
            this.txtBaseMayor.TabIndex = 20;
            // 
            // lblBaseMayor
            // 
            this.lblBaseMayor.AutoSize = true;
            this.lblBaseMayor.Location = new System.Drawing.Point(124, 124);
            this.lblBaseMayor.Name = "lblBaseMayor";
            this.lblBaseMayor.Size = new System.Drawing.Size(294, 20);
            this.lblBaseMayor.TabIndex = 19;
            this.lblBaseMayor.Text = "Ingrese el tamaño de la base mayor (B): ";
            // 
            // btnTrapecio
            // 
            this.btnTrapecio.Location = new System.Drawing.Point(343, 378);
            this.btnTrapecio.Name = "btnTrapecio";
            this.btnTrapecio.Size = new System.Drawing.Size(98, 46);
            this.btnTrapecio.TabIndex = 18;
            this.btnTrapecio.Text = "Calcular";
            this.btnTrapecio.UseVisualStyleBackColor = true;
            this.btnTrapecio.Click += new System.EventHandler(this.btnTrapecio_Click);
            // 
            // lblLado
            // 
            this.lblLado.AutoSize = true;
            this.lblLado.Location = new System.Drawing.Point(168, 290);
            this.lblLado.Name = "lblLado";
            this.lblLado.Size = new System.Drawing.Size(246, 20);
            this.lblLado.TabIndex = 26;
            this.lblLado.Text = "Ingrese el tamaño de los lados (l):";
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(455, 290);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(138, 26);
            this.txtLado.TabIndex = 27;
            // 
            // Trapecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLado);
            this.Controls.Add(this.lblLado);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.lblBaseMenor);
            this.Controls.Add(this.txtBaseMenor);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.lblTrapecio);
            this.Controls.Add(this.txtBaseMayor);
            this.Controls.Add(this.lblBaseMayor);
            this.Controls.Add(this.btnTrapecio);
            this.Name = "Trapecio";
            this.Text = "Trapecio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label lblBaseMenor;
        private System.Windows.Forms.TextBox txtBaseMenor;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblTrapecio;
        private System.Windows.Forms.TextBox txtBaseMayor;
        private System.Windows.Forms.Label lblBaseMayor;
        private System.Windows.Forms.Button btnTrapecio;
        private System.Windows.Forms.Label lblLado;
        private System.Windows.Forms.TextBox txtLado;
    }
}