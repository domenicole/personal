using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosU2
{
    public partial class frmAlgLineas : Form
    {
        private static frmAlgLineas instancia;

        public static frmAlgLineas Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new frmAlgLineas();
                return instancia;
            }
        }

        AlgoritmosU2.AlgoritmoDDA dda = new AlgoritmosU2.AlgoritmoDDA();
        AlgoritmosU2.AlgoritmoBresenham bresenham = new AlgoritmosU2.AlgoritmoBresenham();
        AlgoritmosU2.AlgoritmoPuntoMedio puntoMedio = new AlgoritmosU2.AlgoritmoPuntoMedio();
        Dibujo dibujo;

        public frmAlgLineas()
        {
            InitializeComponent();
            dibujo = new Dibujo(panelDibujo);
            dibujo.SetVelocidadAnimacion(100);
        }

        private void btnDDA_Click(object sender, EventArgs e)
        {
            int x0 = (int)xInicial.Value;
            int y0 = (int)yInicial.Value;
            int xf = (int)xFinal.Value;
            int yf = (int)yFinal.Value;

            var puntos = dda.GenerarPuntos(x0, y0, xf, yf);
            dibujo.DibujarAnimado(puntos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x0 = (int)xInicial.Value;
            int y0 = (int)yInicial.Value;
            int xf = (int)xFinal.Value;
            int yf = (int)yFinal.Value;

            var puntos = bresenham.GenerarPuntos(x0, y0, xf, yf);
            dibujo.DibujarAnimado(puntos);
        }

        private void btnPuntoMedio_Click(object sender, EventArgs e)
        {
            int x0 = (int)xInicial.Value;
            int y0 = (int)yInicial.Value;
            int xf = (int)xFinal.Value;
            int yf = (int)yFinal.Value;

            var puntos = puntoMedio.GenerarPuntos(x0, y0, xf, yf);
            dibujo.DibujarAnimado(puntos);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void frmAlgLineas_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.Location = new Point(
                    (this.MdiParent.ClientSize.Width - this.Width) / 2,
                    (this.MdiParent.ClientSize.Height - this.Height) / 2
                );
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (dibujo != null)
            {
                dibujo.Limpiar();
            }
        }
    }
}
