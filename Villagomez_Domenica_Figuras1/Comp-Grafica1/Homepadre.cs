using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp_Grafica1
{
    public partial class Homepadre : Form
    {
        public Homepadre()
        {
            InitializeComponent();
        }

        private void CerrarFormulariosHijos()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        private void rectanguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Rectangulo rectangulo = Rectangulo.Instancia;
            rectangulo.MdiParent = this;
            rectangulo.Show();
        }

        private void cuadradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Cuadrado cuadrado = Cuadrado.Instancia;
            cuadrado.MdiParent = this;
            cuadrado.Show();
        }

        private void trianguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Triangulo triangulo = Triangulo.Instancia;
            triangulo.MdiParent = this;
            triangulo.Show();
        }

        private void romboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Rombo rombo = Rombo.Instancia;
            rombo.MdiParent = this;
            rombo.Show();
        }

        private void romboideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Romboide romboide = Romboide.Instancia;
            romboide.MdiParent = this;
            romboide.Show();
        }

        private void trapecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Trapecio trapecio = Trapecio.Instancia;
            trapecio.MdiParent = this;
            trapecio.Show();
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Circulo circulo = Circulo.Instancia;
            circulo.MdiParent = this;
            circulo.Show();
        }

        private void poligonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Poligono poligono = Poligono.Instancia;
            poligono.MdiParent = this;
            poligono.Show();
        }
    }
}
