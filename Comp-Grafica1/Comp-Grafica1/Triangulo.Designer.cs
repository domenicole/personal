namespace Comp_Grafica1
{
    partial class Triangulo
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
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblTriangulo = new System.Windows.Forms.Label();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.btnTriangulo = new System.Windows.Forms.Button();
            this.txtLado = new System.Windows.Forms.TextBox();
            this.lblLado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(419, 211);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(138, 26);
            this.txtAltura.TabIndex = 15;
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(156, 217);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(246, 20);
            this.lblAltura.TabIndex = 14;
            this.lblAltura.Text = "Ingrese el tamaño de la altura (h):";
            // 
            // lblTriangulo
            // 
            this.lblTriangulo.AutoSize = true;
            this.lblTriangulo.Font = new System.Drawing.Font("Mongolian Baiti", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTriangulo.Location = new System.Drawing.Point(288, 24);
            this.lblTriangulo.Name = "lblTriangulo";
            this.lblTriangulo.Size = new System.Drawing.Size(203, 46);
            this.lblTriangulo.TabIndex = 13;
            this.lblTriangulo.Text = "Triangulo";
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(419, 155);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(138, 26);
            this.txtBase.TabIndex = 12;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(156, 161);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(245, 20);
            this.lblBase.TabIndex = 11;
            this.lblBase.Text = "Ingrese el tamaño de la base (b): ";
            // 
            // btnTriangulo
            // 
            this.btnTriangulo.Location = new System.Drawing.Point(347, 355);
            this.btnTriangulo.Name = "btnTriangulo";
            this.btnTriangulo.Size = new System.Drawing.Size(98, 46);
            this.btnTriangulo.TabIndex = 10;
            this.btnTriangulo.Text = "Calcular";
            this.btnTriangulo.UseVisualStyleBackColor = true;
            this.btnTriangulo.Click += new System.EventHandler(this.btnTriangulo_Click);
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(419, 271);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(138, 26);
            this.txtLado.TabIndex = 17;
            // 
            // lblLado
            // 
            this.lblLado.AutoSize = true;
            this.lblLado.Location = new System.Drawing.Point(156, 277);
            this.lblLado.Name = "lblLado";
            this.lblLado.Size = new System.Drawing.Size(246, 20);
            this.lblLado.TabIndex = 16;
            this.lblLado.Text = "Ingrese el tamaño de los lados (l):";
            // 
            // Triangulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLado);
            this.Controls.Add(this.lblLado);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.lblTriangulo);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.lblBase);
            this.Controls.Add(this.btnTriangulo);
            this.Name = "Triangulo";
            this.Text = "Triangulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblTriangulo;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.Button btnTriangulo;
        private System.Windows.Forms.TextBox txtLado;
        private System.Windows.Forms.Label lblLado;
    }
}