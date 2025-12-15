namespace CurvasDeBezier.Bezier
{
    partial class frmBezierLineales
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAnimar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.puntosDeControl = new System.Windows.Forms.NumericUpDown();
            this.timerAnimacion = new System.Windows.Forms.Timer(this.components);
            this.grbGrafico.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.puntosDeControl)).BeginInit();
            this.SuspendLayout();
            // 
            // grbGrafico
            // 
            this.grbGrafico.Controls.Add(this.panelDibujo);
            this.grbGrafico.Location = new System.Drawing.Point(480, 21);
            this.grbGrafico.Name = "grbGrafico";
            this.grbGrafico.Size = new System.Drawing.Size(586, 501);
            this.grbGrafico.TabIndex = 15;
            this.grbGrafico.TabStop = false;
            this.grbGrafico.Text = "Gráfico";
            // 
            // panelDibujo
            // 
            this.panelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDibujo.Location = new System.Drawing.Point(17, 39);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(553, 445);
            this.panelDibujo.TabIndex = 0;
            this.panelDibujo.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDibujo_Paint);
            this.panelDibujo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelDibujo_MouseDown);
            this.panelDibujo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelDibujo_MouseMove);
            this.panelDibujo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelDibujo_MouseUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnReset);
            this.groupBox4.Controls.Add(this.btnAnimar);
            this.groupBox4.Location = new System.Drawing.Point(12, 255);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(448, 108);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Acciones";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(255, 52);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(131, 42);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Resetear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAnimar
            // 
            this.btnAnimar.Location = new System.Drawing.Point(49, 52);
            this.btnAnimar.Name = "btnAnimar";
            this.btnAnimar.Size = new System.Drawing.Size(131, 42);
            this.btnAnimar.TabIndex = 3;
            this.btnAnimar.Text = "Animación";
            this.btnAnimar.UseVisualStyleBackColor = true;
            this.btnAnimar.Click += new System.EventHandler(this.btnAnimar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAplicar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.puntosDeControl);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 228);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puntos";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(155, 163);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(131, 42);
            this.btnAplicar.TabIndex = 7;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puntos de Control:";
            // 
            // puntosDeControl
            // 
            this.puntosDeControl.Location = new System.Drawing.Point(165, 39);
            this.puntosDeControl.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.puntosDeControl.Name = "puntosDeControl";
            this.puntosDeControl.Size = new System.Drawing.Size(95, 26);
            this.puntosDeControl.TabIndex = 0;
            this.puntosDeControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.puntosDeControl.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // timerAnimacion
            // 
            this.timerAnimacion.Tick += new System.EventHandler(this.TimerAnimacion_Tick);
            // 
            // frmBezierLineales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1078, 534);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grbGrafico);
            this.Name = "frmBezierLineales";
            this.Text = "Curvas de Bézier Lineales";
            this.grbGrafico.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.puntosDeControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGrafico;
        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAnimar;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown puntosDeControl;
        private System.Windows.Forms.Timer timerAnimacion;
    }
}