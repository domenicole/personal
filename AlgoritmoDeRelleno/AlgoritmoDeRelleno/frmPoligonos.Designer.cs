namespace AlgoritmosU2
{
    partial class frmPoligonos
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
            this.grbGrafico = new System.Windows.Forms.GroupBox();
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDibujar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPuntos = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLiangBarsky = new System.Windows.Forms.Button();
            this.btnSutherland = new System.Windows.Forms.Button();
            this.btnAtherton = new System.Windows.Forms.Button();
            this.grbGrafico.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbGrafico
            // 
            this.grbGrafico.Controls.Add(this.panelDibujo);
            this.grbGrafico.Location = new System.Drawing.Point(427, 34);
            this.grbGrafico.Name = "grbGrafico";
            this.grbGrafico.Size = new System.Drawing.Size(534, 501);
            this.grbGrafico.TabIndex = 9;
            this.grbGrafico.TabStop = false;
            this.grbGrafico.Text = "Gráfico";
            // 
            // panelDibujo
            // 
            this.panelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDibujo.Location = new System.Drawing.Point(17, 39);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(496, 445);
            this.panelDibujo.TabIndex = 0;
            this.panelDibujo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDibujo_Paint);
            this.panelDibujo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelDibujo_MouseClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDibujar);
            this.groupBox4.Controls.Add(this.btnLimpiar);
            this.groupBox4.Location = new System.Drawing.Point(27, 484);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(361, 98);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Acciones";
            // 
            // btnDibujar
            // 
            this.btnDibujar.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnDibujar.Location = new System.Drawing.Point(38, 38);
            this.btnDibujar.Name = "btnDibujar";
            this.btnDibujar.Size = new System.Drawing.Size(131, 42);
            this.btnDibujar.TabIndex = 4;
            this.btnDibujar.Text = "Dibujar";
            this.btnDibujar.UseVisualStyleBackColor = false;
            this.btnDibujar.Click += new System.EventHandler(this.btnDibujar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Lavender;
            this.btnLimpiar.Location = new System.Drawing.Point(191, 38);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(131, 42);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPuntos);
            this.groupBox3.Location = new System.Drawing.Point(27, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 286);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Puntos";
            // 
            // txtPuntos
            // 
            this.txtPuntos.BackColor = System.Drawing.Color.Snow;
            this.txtPuntos.Location = new System.Drawing.Point(19, 49);
            this.txtPuntos.Multiline = true;
            this.txtPuntos.Name = "txtPuntos";
            this.txtPuntos.ReadOnly = true;
            this.txtPuntos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPuntos.Size = new System.Drawing.Size(320, 213);
            this.txtPuntos.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLiangBarsky);
            this.groupBox1.Controls.Add(this.btnSutherland);
            this.groupBox1.Controls.Add(this.btnAtherton);
            this.groupBox1.Location = new System.Drawing.Point(27, 326);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 152);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algoritmos";
            // 
            // btnLiangBarsky
            // 
            this.btnLiangBarsky.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLiangBarsky.Location = new System.Drawing.Point(191, 95);
            this.btnLiangBarsky.Name = "btnLiangBarsky";
            this.btnLiangBarsky.Size = new System.Drawing.Size(131, 42);
            this.btnLiangBarsky.TabIndex = 5;
            this.btnLiangBarsky.Text = "Liang Barsky";
            this.btnLiangBarsky.UseVisualStyleBackColor = false;
            this.btnLiangBarsky.Click += new System.EventHandler(this.btnLiangBarsky_Click);
            // 
            // btnSutherland
            // 
            this.btnSutherland.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSutherland.Location = new System.Drawing.Point(82, 38);
            this.btnSutherland.Name = "btnSutherland";
            this.btnSutherland.Size = new System.Drawing.Size(190, 42);
            this.btnSutherland.TabIndex = 4;
            this.btnSutherland.Text = "Sutherland Hodgman";
            this.btnSutherland.UseVisualStyleBackColor = false;
            this.btnSutherland.Click += new System.EventHandler(this.btnSutherland_Click);
            // 
            // btnAtherton
            // 
            this.btnAtherton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAtherton.Location = new System.Drawing.Point(19, 95);
            this.btnAtherton.Name = "btnAtherton";
            this.btnAtherton.Size = new System.Drawing.Size(150, 42);
            this.btnAtherton.TabIndex = 3;
            this.btnAtherton.Text = "Weiler Atherton";
            this.btnAtherton.UseVisualStyleBackColor = false;
            this.btnAtherton.Click += new System.EventHandler(this.btnAtherton_Click);
            // 
            // frmPoligonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(978, 594);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grbGrafico);
            this.Name = "frmPoligonos";
            this.Text = "Algoritmos de Recorte de Polígonos";
            this.Load += new System.EventHandler(this.frmPoligonos_Load);
            this.grbGrafico.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGrafico;
        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPuntos;
        private System.Windows.Forms.Button btnDibujar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSutherland;
        private System.Windows.Forms.Button btnAtherton;
        private System.Windows.Forms.Button btnLiangBarsky;
    }
}