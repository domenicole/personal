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
    public partial class Poligono : Form
    {
        private static Poligono instancia;

        public static Poligono Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new Poligono();
                return instancia;
            }
        }

        private Poligono()
        {
            InitializeComponent();
        }

        private void btnPoligono_Click(object sender, EventArgs e)
        {
            try
            {
                int numLados = int.Parse(txtNumLados.Text);
                float apotema = float.Parse(txtApotema.Text);
                float lado = float.Parse(txtLado.Text);

                if (apotema <= 0.00f || lado <= 0.00f || numLados <= 0)
                {
                    MessageBox.Show("Los valores deben ser mayores que cero.");
                    return;
                }

                float perimetro = numLados * lado;
                float area = (perimetro * apotema) / 2;

                MessageBox.Show("El área del poligono es: " + area + "\n El perimetro es: " + perimetro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Los números ingresados no son válidos.\n" + ex.Message);
            }
        }
    }
}
