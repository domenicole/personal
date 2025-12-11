namespace AlgoritmosU2
{
    partial class frmAlgRelleno
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
            this.grbGrafico = new System.Windows.Forms.GroupBox();
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCirculo = new System.Windows.Forms.Button();
            this.btnDibujoLibre = new System.Windows.Forms.Button();
            this.btnCuadrado = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCoords = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnScanline = new System.Windows.Forms.Button();
            this.btnFloodfill = new System.Windows.Forms.Button();
            this.btnPatron = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grbGrafico.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbGrafico
            // 
            this.grbGrafico.Controls.Add(this.panelDibujo);
            this.grbGrafico.Location = new System.Drawing.Point(417, 23);
            this.grbGrafico.Name = "grbGrafico";
            this.grbGrafico.Size = new System.Drawing.Size(549, 561);
            this.grbGrafico.TabIndex = 8;
            this.grbGrafico.TabStop = false;
            this.grbGrafico.Text = "Gráfico";
            // 
            // panelDibujo
            // 
            this.panelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDibujo.Location = new System.Drawing.Point(23, 39);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(505, 503);
            this.panelDibujo.TabIndex = 0;
            this.panelDibujo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDibujo_Paint);
            this.panelDibujo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelDibujo_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCirculo);
            this.groupBox3.Controls.Add(this.btnDibujoLibre);
            this.groupBox3.Controls.Add(this.btnCuadrado);
            this.groupBox3.Location = new System.Drawing.Point(21, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 209);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Figuras";
            // 
            // btnCirculo
            // 
            this.btnCirculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnCirculo.Location = new System.Drawing.Point(27, 87);
            this.btnCirculo.Name = "btnCirculo";
            this.btnCirculo.Size = new System.Drawing.Size(101, 42);
            this.btnCirculo.TabIndex = 3;
            this.btnCirculo.Text = "Circulo";
            this.btnCirculo.UseVisualStyleBackColor = false;
            this.btnCirculo.Click += new System.EventHandler(this.btnCirculo_Click);
            // 
            // btnDibujoLibre
            // 
            this.btnDibujoLibre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDibujoLibre.Location = new System.Drawing.Point(16, 39);
            this.btnDibujoLibre.Name = "btnDibujoLibre";
            this.btnDibujoLibre.Size = new System.Drawing.Size(131, 42);
            this.btnDibujoLibre.TabIndex = 2;
            this.btnDibujoLibre.Text = "Dibujo Libre";
            this.btnDibujoLibre.UseVisualStyleBackColor = false;
            this.btnDibujoLibre.Click += new System.EventHandler(this.btnDibujoLibre_Click);
            // 
            // btnCuadrado
            // 
            this.btnCuadrado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCuadrado.Location = new System.Drawing.Point(27, 135);
            this.btnCuadrado.Name = "btnCuadrado";
            this.btnCuadrado.Size = new System.Drawing.Size(101, 42);
            this.btnCuadrado.TabIndex = 0;
            this.btnCuadrado.Text = "Cuadrado";
            this.btnCuadrado.UseVisualStyleBackColor = false;
            this.btnCuadrado.Click += new System.EventHandler(this.btnCuadrado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCoords);
            this.groupBox1.Location = new System.Drawing.Point(21, 355);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 229);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Coordenadas Iniciales";
            // 
            // txtCoords
            // 
            this.txtCoords.BackColor = System.Drawing.Color.Snow;
            this.txtCoords.Location = new System.Drawing.Point(17, 35);
            this.txtCoords.Multiline = true;
            this.txtCoords.Name = "txtCoords";
            this.txtCoords.ReadOnly = true;
            this.txtCoords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCoords.Size = new System.Drawing.Size(330, 175);
            this.txtCoords.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnScanline);
            this.groupBox2.Controls.Add(this.btnFloodfill);
            this.groupBox2.Controls.Add(this.btnPatron);
            this.groupBox2.Location = new System.Drawing.Point(220, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 209);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algoritmos";
            // 
            // btnScanline
            // 
            this.btnScanline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnScanline.Location = new System.Drawing.Point(27, 87);
            this.btnScanline.Name = "btnScanline";
            this.btnScanline.Size = new System.Drawing.Size(101, 42);
            this.btnScanline.TabIndex = 3;
            this.btnScanline.Text = "Scanline";
            this.btnScanline.UseVisualStyleBackColor = false;
            this.btnScanline.Click += new System.EventHandler(this.btnScanline_Click);
            // 
            // btnFloodfill
            // 
            this.btnFloodfill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFloodfill.Location = new System.Drawing.Point(16, 39);
            this.btnFloodfill.Name = "btnFloodfill";
            this.btnFloodfill.Size = new System.Drawing.Size(131, 42);
            this.btnFloodfill.TabIndex = 2;
            this.btnFloodfill.Text = "FloodFill";
            this.btnFloodfill.UseVisualStyleBackColor = false;
            this.btnFloodfill.Click += new System.EventHandler(this.btnFloodfill_Click);
            // 
            // btnPatron
            // 
            this.btnPatron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPatron.Location = new System.Drawing.Point(27, 135);
            this.btnPatron.Name = "btnPatron";
            this.btnPatron.Size = new System.Drawing.Size(101, 42);
            this.btnPatron.TabIndex = 0;
            this.btnPatron.Text = "Por Patrón";
            this.btnPatron.UseVisualStyleBackColor = false;
            this.btnPatron.Click += new System.EventHandler(this.btnPatron_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLimpiar);
            this.groupBox4.Controls.Add(this.btnCancelar);
            this.groupBox4.Location = new System.Drawing.Point(21, 247);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(365, 102);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Acciones";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Lavender;
            this.btnLimpiar.Location = new System.Drawing.Point(199, 33);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(131, 42);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnCancelar.Location = new System.Drawing.Point(35, 33);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(131, 42);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAlgRelleno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(978, 594);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbGrafico);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAlgRelleno";
            this.Text = "Algoritmos de Relleno";
            this.Load += new System.EventHandler(this.frmAlgRelleno_Load);
            this.grbGrafico.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGrafico;
        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCirculo;
        private System.Windows.Forms.Button btnDibujoLibre;
        private System.Windows.Forms.Button btnCuadrado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCoords;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnScanline;
        private System.Windows.Forms.Button btnFloodfill;
        private System.Windows.Forms.Button btnPatron;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
    }
}

