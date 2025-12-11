namespace AlgoritmosU2
{
    partial class Circunferencia
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
            this.components = new System.ComponentModel.Container();
            this.grbGrafico = new System.Windows.Forms.GroupBox();
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnParametrico = new System.Windows.Forms.Button();
            this.btnBressenham = new System.Windows.Forms.Button();
            this.btnOctante = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grbGrafico.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radio)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbGrafico
            // 
            this.grbGrafico.Controls.Add(this.panelDibujo);
            this.grbGrafico.Location = new System.Drawing.Point(387, 14);
            this.grbGrafico.Name = "grbGrafico";
            this.grbGrafico.Size = new System.Drawing.Size(579, 518);
            this.grbGrafico.TabIndex = 7;
            this.grbGrafico.TabStop = false;
            this.grbGrafico.Text = "Gráfico";
            // 
            // panelDibujo
            // 
            this.panelDibujo.Location = new System.Drawing.Point(25, 39);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(531, 462);
            this.panelDibujo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnParametrico);
            this.groupBox3.Controls.Add(this.btnBressenham);
            this.groupBox3.Controls.Add(this.btnOctante);
            this.groupBox3.Location = new System.Drawing.Point(24, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 147);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Algoritmos";
            // 
            // btnParametrico
            // 
            this.btnParametrico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnParametrico.Location = new System.Drawing.Point(191, 88);
            this.btnParametrico.Name = "btnParametrico";
            this.btnParametrico.Size = new System.Drawing.Size(116, 42);
            this.btnParametrico.TabIndex = 2;
            this.btnParametrico.Text = "Paramétrico";
            this.btnParametrico.UseVisualStyleBackColor = false;
            this.btnParametrico.Click += new System.EventHandler(this.btnParametrico_Click);
            // 
            // btnBressenham
            // 
            this.btnBressenham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBressenham.Location = new System.Drawing.Point(24, 88);
            this.btnBressenham.Name = "btnBressenham";
            this.btnBressenham.Size = new System.Drawing.Size(114, 42);
            this.btnBressenham.TabIndex = 1;
            this.btnBressenham.Text = "Bressenham";
            this.btnBressenham.UseVisualStyleBackColor = false;
            this.btnBressenham.Click += new System.EventHandler(this.btnBressenham_Click);
            // 
            // btnOctante
            // 
            this.btnOctante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOctante.Location = new System.Drawing.Point(119, 34);
            this.btnOctante.Name = "btnOctante";
            this.btnOctante.Size = new System.Drawing.Size(87, 42);
            this.btnOctante.TabIndex = 0;
            this.btnOctante.Text = "Octante";
            this.btnOctante.UseVisualStyleBackColor = false;
            this.btnOctante.Click += new System.EventHandler(this.btnDibujar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 211);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Coordenadas Iniciales";
            // 
            // radio
            // 
            this.radio.Location = new System.Drawing.Point(128, 77);
            this.radio.Name = "radio";
            this.radio.Size = new System.Drawing.Size(120, 26);
            this.radio.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Radio: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLimpiar);
            this.groupBox4.Location = new System.Drawing.Point(24, 434);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(344, 98);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Acciones";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Lavender;
            this.btnLimpiar.Location = new System.Drawing.Point(91, 39);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(131, 42);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // Circunferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(978, 544);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grbGrafico);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Circunferencia";
            this.Text = "Algoritmos de Circunferencias";
            this.Load += new System.EventHandler(this.Circunferencia_Load);
            this.grbGrafico.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radio)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGrafico;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOctante;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown radio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnParametrico;
        private System.Windows.Forms.Button btnBressenham;
        private System.Windows.Forms.Timer timer1;
    }
}