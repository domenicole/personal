namespace AlgoritmosU2
{
    partial class frmAlgLineas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yInicial = new System.Windows.Forms.NumericUpDown();
            this.xInicial = new System.Windows.Forms.NumericUpDown();
            this.Y0 = new System.Windows.Forms.Label();
            this.X0 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.yFinal = new System.Windows.Forms.NumericUpDown();
            this.xFinal = new System.Windows.Forms.NumericUpDown();
            this.Yf = new System.Windows.Forms.Label();
            this.Xf = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPuntoMedio = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDDA = new System.Windows.Forms.Button();
            this.grbGrafico = new System.Windows.Forms.GroupBox();
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xInicial)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xFinal)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.grbGrafico.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yInicial);
            this.groupBox1.Controls.Add(this.xInicial);
            this.groupBox1.Controls.Add(this.Y0);
            this.groupBox1.Controls.Add(this.X0);
            this.groupBox1.Location = new System.Drawing.Point(21, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Coordenadas Iniciales";
            // 
            // yInicial
            // 
            this.yInicial.Location = new System.Drawing.Point(108, 77);
            this.yInicial.Name = "yInicial";
            this.yInicial.Size = new System.Drawing.Size(120, 26);
            this.yInicial.TabIndex = 3;
            // 
            // xInicial
            // 
            this.xInicial.Location = new System.Drawing.Point(108, 33);
            this.xInicial.Name = "xInicial";
            this.xInicial.Size = new System.Drawing.Size(120, 26);
            this.xInicial.TabIndex = 2;
            // 
            // Y0
            // 
            this.Y0.AutoSize = true;
            this.Y0.Location = new System.Drawing.Point(25, 83);
            this.Y0.Name = "Y0";
            this.Y0.Size = new System.Drawing.Size(70, 20);
            this.Y0.TabIndex = 1;
            this.Y0.Text = "Y inicial: ";
            // 
            // X0
            // 
            this.X0.AutoSize = true;
            this.X0.Location = new System.Drawing.Point(25, 39);
            this.X0.Name = "X0";
            this.X0.Size = new System.Drawing.Size(66, 20);
            this.X0.TabIndex = 0;
            this.X0.Text = "X inicial:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.yFinal);
            this.groupBox2.Controls.Add(this.xFinal);
            this.groupBox2.Controls.Add(this.Yf);
            this.groupBox2.Controls.Add(this.Xf);
            this.groupBox2.Location = new System.Drawing.Point(21, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 118);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Coordenadas Iniciales";
            // 
            // yFinal
            // 
            this.yFinal.Location = new System.Drawing.Point(108, 77);
            this.yFinal.Name = "yFinal";
            this.yFinal.Size = new System.Drawing.Size(120, 26);
            this.yFinal.TabIndex = 5;
            // 
            // xFinal
            // 
            this.xFinal.Location = new System.Drawing.Point(108, 33);
            this.xFinal.Name = "xFinal";
            this.xFinal.Size = new System.Drawing.Size(120, 26);
            this.xFinal.TabIndex = 4;
            // 
            // Yf
            // 
            this.Yf.AutoSize = true;
            this.Yf.Location = new System.Drawing.Point(25, 83);
            this.Yf.Name = "Yf";
            this.Yf.Size = new System.Drawing.Size(61, 20);
            this.Yf.TabIndex = 1;
            this.Yf.Text = "Y final: ";
            // 
            // Xf
            // 
            this.Xf.AutoSize = true;
            this.Xf.Location = new System.Drawing.Point(25, 39);
            this.Xf.Name = "Xf";
            this.Xf.Size = new System.Drawing.Size(61, 20);
            this.Xf.TabIndex = 0;
            this.Xf.Text = "X final: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLimpiar);
            this.groupBox3.Controls.Add(this.btnPuntoMedio);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnDDA);
            this.groupBox3.Location = new System.Drawing.Point(21, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 209);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Algoritmos";
            // 
            // btnPuntoMedio
            // 
            this.btnPuntoMedio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPuntoMedio.Location = new System.Drawing.Point(54, 90);
            this.btnPuntoMedio.Name = "btnPuntoMedio";
            this.btnPuntoMedio.Size = new System.Drawing.Size(131, 42);
            this.btnPuntoMedio.TabIndex = 3;
            this.btnPuntoMedio.Text = "Punto Medio";
            this.btnPuntoMedio.UseVisualStyleBackColor = false;
            this.btnPuntoMedio.Click += new System.EventHandler(this.btnPuntoMedio_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(6, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Bresenham";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDDA
            // 
            this.btnDDA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDDA.Location = new System.Drawing.Point(143, 42);
            this.btnDDA.Name = "btnDDA";
            this.btnDDA.Size = new System.Drawing.Size(87, 42);
            this.btnDDA.TabIndex = 0;
            this.btnDDA.Text = "DDA";
            this.btnDDA.UseVisualStyleBackColor = false;
            this.btnDDA.Click += new System.EventHandler(this.btnDDA_Click);
            // 
            // grbGrafico
            // 
            this.grbGrafico.Controls.Add(this.panelDibujo);
            this.grbGrafico.Location = new System.Drawing.Point(305, 78);
            this.grbGrafico.Name = "grbGrafico";
            this.grbGrafico.Size = new System.Drawing.Size(469, 399);
            this.grbGrafico.TabIndex = 4;
            this.grbGrafico.TabStop = false;
            this.grbGrafico.Text = "Gráfico";
            // 
            // panelDibujo
            // 
            this.panelDibujo.Location = new System.Drawing.Point(17, 39);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(436, 336);
            this.panelDibujo.TabIndex = 0;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Lavender;
            this.btnLimpiar.Location = new System.Drawing.Point(54, 158);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(129, 36);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // frmAlgLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(800, 563);
            this.Controls.Add(this.grbGrafico);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAlgLineas";
            this.Text = "Algoritmos de Líneas";
            this.Load += new System.EventHandler(this.frmAlgLineas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xInicial)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xFinal)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.grbGrafico.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Y0;
        private System.Windows.Forms.Label X0;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Yf;
        private System.Windows.Forms.Label Xf;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown yInicial;
        private System.Windows.Forms.NumericUpDown xInicial;
        private System.Windows.Forms.NumericUpDown yFinal;
        private System.Windows.Forms.NumericUpDown xFinal;
        private System.Windows.Forms.Button btnDDA;
        private System.Windows.Forms.GroupBox grbGrafico;
        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.Button btnPuntoMedio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLimpiar;
    }
}

