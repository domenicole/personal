namespace AlgoritmosU2
{
    partial class frmAlgoritmos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlgoritmos));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.algoritmoDeLineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmoCircunferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmoDeRellenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmoDeRecorteDeLineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmoDeRecorteDePolígonosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MistyRose;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algoritmoDeLineasToolStripMenuItem,
            this.algoritmoCircunferenciaToolStripMenuItem,
            this.algoritmoDeRellenoToolStripMenuItem,
            this.algoritmoDeRecorteDeLineasToolStripMenuItem,
            this.algoritmoDeRecorteDePolígonosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1178, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // algoritmoDeLineasToolStripMenuItem
            // 
            this.algoritmoDeLineasToolStripMenuItem.Name = "algoritmoDeLineasToolStripMenuItem";
            this.algoritmoDeLineasToolStripMenuItem.Size = new System.Drawing.Size(187, 29);
            this.algoritmoDeLineasToolStripMenuItem.Text = "Algoritmo de Lineas";
            this.algoritmoDeLineasToolStripMenuItem.Click += new System.EventHandler(this.algoritmoDeLineasToolStripMenuItem_Click);
            // 
            // algoritmoCircunferenciaToolStripMenuItem
            // 
            this.algoritmoCircunferenciaToolStripMenuItem.Name = "algoritmoCircunferenciaToolStripMenuItem";
            this.algoritmoCircunferenciaToolStripMenuItem.Size = new System.Drawing.Size(224, 29);
            this.algoritmoCircunferenciaToolStripMenuItem.Text = "Algoritmo Circunferencia";
            this.algoritmoCircunferenciaToolStripMenuItem.Click += new System.EventHandler(this.algoritmoCircunferenciaToolStripMenuItem_Click);
            // 
            // algoritmoDeRellenoToolStripMenuItem
            // 
            this.algoritmoDeRellenoToolStripMenuItem.Name = "algoritmoDeRellenoToolStripMenuItem";
            this.algoritmoDeRellenoToolStripMenuItem.Size = new System.Drawing.Size(196, 29);
            this.algoritmoDeRellenoToolStripMenuItem.Text = "Algoritmo de Relleno";
            this.algoritmoDeRellenoToolStripMenuItem.Click += new System.EventHandler(this.algoritmoDeRellenoToolStripMenuItem_Click);
            // 
            // algoritmoDeRecorteDeLineasToolStripMenuItem
            // 
            this.algoritmoDeRecorteDeLineasToolStripMenuItem.Name = "algoritmoDeRecorteDeLineasToolStripMenuItem";
            this.algoritmoDeRecorteDeLineasToolStripMenuItem.Size = new System.Drawing.Size(165, 29);
            this.algoritmoDeRecorteDeLineasToolStripMenuItem.Text = "Recorte de Lineas";
            this.algoritmoDeRecorteDeLineasToolStripMenuItem.Click += new System.EventHandler(this.algoritmoDeRecorteDeLineasToolStripMenuItem_Click);
            // 
            // algoritmoDeRecorteDePolígonosToolStripMenuItem
            // 
            this.algoritmoDeRecorteDePolígonosToolStripMenuItem.Name = "algoritmoDeRecorteDePolígonosToolStripMenuItem";
            this.algoritmoDeRecorteDePolígonosToolStripMenuItem.Size = new System.Drawing.Size(196, 29);
            this.algoritmoDeRecorteDePolígonosToolStripMenuItem.Text = "Recorte de Polígonos";
            this.algoritmoDeRecorteDePolígonosToolStripMenuItem.Click += new System.EventHandler(this.algoritmoDeRecorteDePolígonosToolStripMenuItem_Click);
            // 
            // frmAlgoritmos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAlgoritmos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem algoritmoDeLineasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmoCircunferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmoDeRellenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmoDeRecorteDeLineasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmoDeRecorteDePolígonosToolStripMenuItem;
    }
}