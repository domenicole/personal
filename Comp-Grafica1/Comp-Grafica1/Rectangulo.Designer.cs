namespace Comp_Grafica1
{
    partial class Rectangulo
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
            this.lblRectangulo = new System.Windows.Forms.Label();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.btnCuadrado = new System.Windows.Forms.Button();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.lblAltura = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRectangulo
            // 
            this.lblRectangulo.AutoSize = true;
            this.lblRectangulo.Font = new System.Drawing.Font("Mongolian Baiti", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRectangulo.Location = new System.Drawing.Point(286, 27);
            this.lblRectangulo.Name = "lblRectangulo";
            this.lblRectangulo.Size = new System.Drawing.Size(231, 46);
            this.lblRectangulo.TabIndex = 7;
            this.lblRectangulo.Text = "Rectangulo";
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(417, 158);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(138, 26);
            this.txtBase.TabIndex = 6;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(154, 164);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(245, 20);
            this.lblBase.TabIndex = 5;
            this.lblBase.Text = "Ingrese el tamaño de la base (b): ";
            // 
            // btnCuadrado
            // 
            this.btnCuadrado.Location = new System.Drawing.Point(346, 307);
            this.btnCuadrado.Name = "btnCuadrado";
            this.btnCuadrado.Size = new System.Drawing.Size(98, 46);
            this.btnCuadrado.TabIndex = 4;
            this.btnCuadrado.Text = "Calcular";
            this.btnCuadrado.UseVisualStyleBackColor = true;
            this.btnCuadrado.Click += new System.EventHandler(this.btnCuadrado_Click);
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(417, 214);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(138, 26);
            this.txtAltura.TabIndex = 9;
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(154, 220);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(246, 20);
            this.lblAltura.TabIndex = 8;
            this.lblAltura.Text = "Ingrese el tamaño de la altura (h):";
            // 
            // Rectangulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.lblRectangulo);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.lblBase);
            this.Controls.Add(this.btnCuadrado);
            this.Name = "Rectangulo";
            this.Text = "Rectangulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRectangulo;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.Button btnCuadrado;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label lblAltura;
    }
}