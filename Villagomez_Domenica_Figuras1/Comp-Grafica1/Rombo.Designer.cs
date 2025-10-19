namespace Comp_Grafica1
{
    partial class Rombo
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
            this.txtDiagMenor = new System.Windows.Forms.TextBox();
            this.lblDiagMenor = new System.Windows.Forms.Label();
            this.lblRombo = new System.Windows.Forms.Label();
            this.txtDiagMayor = new System.Windows.Forms.TextBox();
            this.lblDiametroMayor = new System.Windows.Forms.Label();
            this.btnRombo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(477, 266);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(138, 26);
            this.txtLado.TabIndex = 25;
            // 
            // lblLado
            // 
            this.lblLado.AutoSize = true;
            this.lblLado.Location = new System.Drawing.Point(209, 272);
            this.lblLado.Name = "lblLado";
            this.lblLado.Size = new System.Drawing.Size(246, 20);
            this.lblLado.TabIndex = 24;
            this.lblLado.Text = "Ingrese el tamaño de los lados (l):";
            // 
            // txtDiagMenor
            // 
            this.txtDiagMenor.Location = new System.Drawing.Point(477, 206);
            this.txtDiagMenor.Name = "txtDiagMenor";
            this.txtDiagMenor.Size = new System.Drawing.Size(138, 26);
            this.txtDiagMenor.TabIndex = 23;
            // 
            // lblDiagMenor
            // 
            this.lblDiagMenor.AutoSize = true;
            this.lblDiagMenor.Location = new System.Drawing.Point(140, 212);
            this.lblDiagMenor.Name = "lblDiagMenor";
            this.lblDiagMenor.Size = new System.Drawing.Size(315, 20);
            this.lblDiagMenor.TabIndex = 22;
            this.lblDiagMenor.Text = "Ingrese el tamaño de la diagonal menor (d):";
            // 
            // lblRombo
            // 
            this.lblRombo.AutoSize = true;
            this.lblRombo.Font = new System.Drawing.Font("Mongolian Baiti", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRombo.Location = new System.Drawing.Point(306, 19);
            this.lblRombo.Name = "lblRombo";
            this.lblRombo.Size = new System.Drawing.Size(154, 46);
            this.lblRombo.TabIndex = 21;
            this.lblRombo.Text = "Rombo";
            // 
            // txtDiagMayor
            // 
            this.txtDiagMayor.Location = new System.Drawing.Point(477, 150);
            this.txtDiagMayor.Name = "txtDiagMayor";
            this.txtDiagMayor.Size = new System.Drawing.Size(138, 26);
            this.txtDiagMayor.TabIndex = 20;
            // 
            // lblDiametroMayor
            // 
            this.lblDiametroMayor.AutoSize = true;
            this.lblDiametroMayor.Location = new System.Drawing.Point(140, 156);
            this.lblDiametroMayor.Name = "lblDiametroMayor";
            this.lblDiametroMayor.Size = new System.Drawing.Size(320, 20);
            this.lblDiametroMayor.TabIndex = 19;
            this.lblDiametroMayor.Text = "Ingrese el tamaño de la diagonal mayor (D): ";
            // 
            // btnRombo
            // 
            this.btnRombo.Location = new System.Drawing.Point(365, 350);
            this.btnRombo.Name = "btnRombo";
            this.btnRombo.Size = new System.Drawing.Size(98, 46);
            this.btnRombo.TabIndex = 18;
            this.btnRombo.Text = "Calcular";
            this.btnRombo.UseVisualStyleBackColor = true;
            this.btnRombo.Click += new System.EventHandler(this.btnRombo_Click);
            // 
            // Rombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLado);
            this.Controls.Add(this.lblLado);
            this.Controls.Add(this.txtDiagMenor);
            this.Controls.Add(this.lblDiagMenor);
            this.Controls.Add(this.lblRombo);
            this.Controls.Add(this.txtDiagMayor);
            this.Controls.Add(this.lblDiametroMayor);
            this.Controls.Add(this.btnRombo);
            this.Name = "Rombo";
            this.Text = "Rombo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLado;
        private System.Windows.Forms.Label lblLado;
        private System.Windows.Forms.TextBox txtDiagMenor;
        private System.Windows.Forms.Label lblDiagMenor;
        private System.Windows.Forms.Label lblRombo;
        private System.Windows.Forms.TextBox txtDiagMayor;
        private System.Windows.Forms.Label lblDiametroMayor;
        private System.Windows.Forms.Button btnRombo;
    }
}