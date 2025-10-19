namespace Comp_Grafica1
{
    partial class Romboide
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
            this.lblRomboide = new System.Windows.Forms.Label();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.btnRomboide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(425, 212);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(138, 26);
            this.txtAltura.TabIndex = 23;
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(162, 218);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(246, 20);
            this.lblAltura.TabIndex = 22;
            this.lblAltura.Text = "Ingrese el tamaño de la altura (h):";
            // 
            // lblRomboide
            // 
            this.lblRomboide.AutoSize = true;
            this.lblRomboide.Font = new System.Drawing.Font("Mongolian Baiti", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRomboide.Location = new System.Drawing.Point(294, 25);
            this.lblRomboide.Name = "lblRomboide";
            this.lblRomboide.Size = new System.Drawing.Size(211, 46);
            this.lblRomboide.TabIndex = 21;
            this.lblRomboide.Text = "Romboide";
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(425, 156);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(138, 26);
            this.txtBase.TabIndex = 20;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(162, 162);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(245, 20);
            this.lblBase.TabIndex = 19;
            this.lblBase.Text = "Ingrese el tamaño de la base (b): ";
            // 
            // btnRomboide
            // 
            this.btnRomboide.Location = new System.Drawing.Point(354, 331);
            this.btnRomboide.Name = "btnRomboide";
            this.btnRomboide.Size = new System.Drawing.Size(98, 46);
            this.btnRomboide.TabIndex = 18;
            this.btnRomboide.Text = "Calcular";
            this.btnRomboide.UseVisualStyleBackColor = true;
            this.btnRomboide.Click += new System.EventHandler(this.btnRomboide_Click);
            // 
            // Romboide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.lblRomboide);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.lblBase);
            this.Controls.Add(this.btnRomboide);
            this.Name = "Romboide";
            this.Text = "Romboide";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblRomboide;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.Button btnRomboide;
    }
}