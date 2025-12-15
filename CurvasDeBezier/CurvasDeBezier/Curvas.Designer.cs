namespace CurvasDeBezier
{
    partial class Curvas
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.linealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curvasBSplineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curvasDeBezierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linealToolStripMenuItem,
            this.curvasBSplineToolStripMenuItem,
            this.curvasDeBezierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1078, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // linealToolStripMenuItem
            // 
            this.linealToolStripMenuItem.Name = "linealToolStripMenuItem";
            this.linealToolStripMenuItem.Size = new System.Drawing.Size(16, 29);
            // 
            // curvasBSplineToolStripMenuItem
            // 
            this.curvasBSplineToolStripMenuItem.Name = "curvasBSplineToolStripMenuItem";
            this.curvasBSplineToolStripMenuItem.Size = new System.Drawing.Size(151, 29);
            this.curvasBSplineToolStripMenuItem.Text = "Curvas B-Spline";
            this.curvasBSplineToolStripMenuItem.Click += new System.EventHandler(this.curvasBSplineToolStripMenuItem_Click);
            // 
            // curvasDeBezierToolStripMenuItem
            // 
            this.curvasDeBezierToolStripMenuItem.Name = "curvasDeBezierToolStripMenuItem";
            this.curvasDeBezierToolStripMenuItem.Size = new System.Drawing.Size(157, 29);
            this.curvasDeBezierToolStripMenuItem.Text = "Curvas de Bezier";
            this.curvasDeBezierToolStripMenuItem.Click += new System.EventHandler(this.curvasDeBezierToolStripMenuItem_Click);
            // 
            // Curvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 544);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Curvas";
            this.Text = "s de Curvas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem linealToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curvasBSplineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curvasDeBezierToolStripMenuItem;
    }
}

