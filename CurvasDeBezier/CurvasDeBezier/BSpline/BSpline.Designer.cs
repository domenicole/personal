namespace CurvasDeBezier
{
    partial class BSpline
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCubica = new System.Windows.Forms.RadioButton();
            this.rbCuadratica = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbCerrada = new System.Windows.Forms.RadioButton();
            this.rbAbierta = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numPuntosControl = new System.Windows.Forms.NumericUpDown();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnAnimar = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTipoCurva = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntosControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDibujo
            // 
            this.panelDibujo.BackColor = System.Drawing.Color.White;
            this.panelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDibujo.Location = new System.Drawing.Point(12, 90);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(1060, 480);
            this.panelDibujo.TabIndex = 0;
            this.panelDibujo.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDibujo_Paint);
            this.panelDibujo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelDibujo_MouseDown);
            this.panelDibujo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelDibujo_MouseMove);
            this.panelDibujo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelDibujo_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCubica);
            this.groupBox1.Controls.Add(this.rbCuadratica);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grado";
            // 
            // rbCubica
            // 
            this.rbCubica.AutoSize = true;
            this.rbCubica.Checked = true;
            this.rbCubica.Location = new System.Drawing.Point(15, 42);
            this.rbCubica.Name = "rbCubica";
            this.rbCubica.Size = new System.Drawing.Size(91, 17);
            this.rbCubica.TabIndex = 1;
            this.rbCubica.TabStop = true;
            this.rbCubica.Text = "Cúbica (p=3)";
            this.rbCubica.UseVisualStyleBackColor = true;
            // 
            // rbCuadratica
            // 
            this.rbCuadratica.AutoSize = true;
            this.rbCuadratica.Location = new System.Drawing.Point(15, 19);
            this.rbCuadratica.Name = "rbCuadratica";
            this.rbCuadratica.Size = new System.Drawing.Size(112, 17);
            this.rbCuadratica.TabIndex = 0;
            this.rbCuadratica.Text = "Cuadrática (p=2)";
            this.rbCuadratica.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbCerrada);
            this.groupBox2.Controls.Add(this.rbAbierta);
            this.groupBox2.Location = new System.Drawing.Point(168, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 70);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo";
            // 
            // rbCerrada
            // 
            this.rbCerrada.AutoSize = true;
            this.rbCerrada.Location = new System.Drawing.Point(15, 42);
            this.rbCerrada.Name = "rbCerrada";
            this.rbCerrada.Size = new System.Drawing.Size(65, 17);
            this.rbCerrada.TabIndex = 1;
            this.rbCerrada.Text = "Cerrada";
            this.rbCerrada.UseVisualStyleBackColor = true;
            // 
            // rbAbierta
            // 
            this.rbAbierta.AutoSize = true;
            this.rbAbierta.Checked = true;
            this.rbAbierta.Location = new System.Drawing.Point(15, 19);
            this.rbAbierta.Name = "rbAbierta";
            this.rbAbierta.Size = new System.Drawing.Size(60, 17);
            this.rbAbierta.TabIndex = 0;
            this.rbAbierta.TabStop = true;
            this.rbAbierta.Text = "Abierta";
            this.rbAbierta.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Puntos de Control:";
            // 
            // numPuntosControl
            // 
            this.numPuntosControl.Location = new System.Drawing.Point(327, 50);
            this.numPuntosControl.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numPuntosControl.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            this.numPuntosControl.Name = "numPuntosControl";
            this.numPuntosControl.Size = new System.Drawing.Size(80, 20);
            this.numPuntosControl.TabIndex = 4;
            this.numPuntosControl.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(430, 25);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(100, 50);
            this.btnAplicar.TabIndex = 5;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnAnimar
            // 
            this.btnAnimar.Enabled = false;
            this.btnAnimar.Location = new System.Drawing.Point(550, 25);
            this.btnAnimar.Name = "btnAnimar";
            this.btnAnimar.Size = new System.Drawing.Size(100, 50);
            this.btnAnimar.TabIndex = 6;
            this.btnAnimar.Text = "Animar";
            this.btnAnimar.UseVisualStyleBackColor = true;
            this.btnAnimar.Click += new System.EventHandler(this.btnAnimar_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(670, 25);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 50);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTipoCurva
            // 
            this.lblTipoCurva.AutoSize = true;
            this.lblTipoCurva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoCurva.Location = new System.Drawing.Point(800, 45);
            this.lblTipoCurva.Name = "lblTipoCurva";
            this.lblTipoCurva.Size = new System.Drawing.Size(113, 15);
            this.lblTipoCurva.TabIndex = 8;
            this.lblTipoCurva.Text = "Tipo de curva: -";
            // 
            // BSpline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 581);
            this.Controls.Add(this.lblTipoCurva);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAnimar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.numPuntosControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelDibujo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BSpline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Curvas B-Spline";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntosControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCubica;
        private System.Windows.Forms.RadioButton rbCuadratica;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbCerrada;
        private System.Windows.Forms.RadioButton rbAbierta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPuntosControl;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnAnimar;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTipoCurva;
    }
}