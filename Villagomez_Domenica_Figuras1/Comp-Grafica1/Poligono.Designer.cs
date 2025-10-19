namespace Comp_Grafica1
{
    partial class Poligono
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
            this.txtLado = new System.Windows.Forms.TextBox();
            this.lblLado = new System.Windows.Forms.Label();
            this.lblPoligono = new System.Windows.Forms.Label();
            this.txtApotema = new System.Windows.Forms.TextBox();
            this.lblApotema = new System.Windows.Forms.Label();
            this.btnPoligono = new System.Windows.Forms.Button();
            this.txtNumLados = new System.Windows.Forms.TextBox();
            this.lblNumLados = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(427, 212);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(138, 26);
            this.txtLado.TabIndex = 21;
            // 
            // lblLado
            // 
            this.lblLado.AutoSize = true;
            this.lblLado.Location = new System.Drawing.Point(164, 218);
            this.lblLado.Name = "lblLado";
            this.lblLado.Size = new System.Drawing.Size(246, 20);
            this.lblLado.TabIndex = 20;
            this.lblLado.Text = "Ingrese el tamaño de los lados (l):";
            // 
            // lblPoligono
            // 
            this.lblPoligono.AutoSize = true;
            this.lblPoligono.Font = new System.Drawing.Font("Mongolian Baiti", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoligono.Location = new System.Drawing.Point(285, 25);
            this.lblPoligono.Name = "lblPoligono";
            this.lblPoligono.Size = new System.Drawing.Size(186, 46);
            this.lblPoligono.TabIndex = 19;
            this.lblPoligono.Text = "Poligono";
            // 
            // txtApotema
            // 
            this.txtApotema.Location = new System.Drawing.Point(427, 156);
            this.txtApotema.Name = "txtApotema";
            this.txtApotema.Size = new System.Drawing.Size(138, 26);
            this.txtApotema.TabIndex = 18;
            // 
            // lblApotema
            // 
            this.lblApotema.AutoSize = true;
            this.lblApotema.Location = new System.Drawing.Point(137, 162);
            this.lblApotema.Name = "lblApotema";
            this.lblApotema.Size = new System.Drawing.Size(273, 20);
            this.lblApotema.TabIndex = 17;
            this.lblApotema.Text = "Ingrese el tamaño de la apotema (a): ";
            // 
            // btnPoligono
            // 
            this.btnPoligono.Location = new System.Drawing.Point(344, 356);
            this.btnPoligono.Name = "btnPoligono";
            this.btnPoligono.Size = new System.Drawing.Size(98, 46);
            this.btnPoligono.TabIndex = 16;
            this.btnPoligono.Text = "Calcular";
            this.btnPoligono.UseVisualStyleBackColor = true;
            this.btnPoligono.Click += new System.EventHandler(this.btnPoligono_Click);
            // 
            // txtNumLados
            // 
            this.txtNumLados.Location = new System.Drawing.Point(427, 268);
            this.txtNumLados.Name = "txtNumLados";
            this.txtNumLados.Size = new System.Drawing.Size(138, 26);
            this.txtNumLados.TabIndex = 23;
            // 
            // lblNumLados
            // 
            this.lblNumLados.AutoSize = true;
            this.lblNumLados.Location = new System.Drawing.Point(182, 274);
            this.lblNumLados.Name = "lblNumLados";
            this.lblNumLados.Size = new System.Drawing.Size(228, 20);
            this.lblNumLados.TabIndex = 22;
            this.lblNumLados.Text = "Ingrese el número de lados (n):";
            // 
            // Poligono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNumLados);
            this.Controls.Add(this.lblNumLados);
            this.Controls.Add(this.txtLado);
            this.Controls.Add(this.lblLado);
            this.Controls.Add(this.lblPoligono);
            this.Controls.Add(this.txtApotema);
            this.Controls.Add(this.lblApotema);
            this.Controls.Add(this.btnPoligono);
            this.Name = "Poligono";
            this.Text = "Poligono";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLado;
        private System.Windows.Forms.Label lblLado;
        private System.Windows.Forms.Label lblPoligono;
        private System.Windows.Forms.TextBox txtApotema;
        private System.Windows.Forms.Label lblApotema;
        private System.Windows.Forms.Button btnPoligono;
        private System.Windows.Forms.TextBox txtNumLados;
        private System.Windows.Forms.Label lblNumLados;
    }
}