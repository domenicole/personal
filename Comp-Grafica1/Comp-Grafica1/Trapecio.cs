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
    public partial class Trapecio : Form
    {
        private static Trapecio instancia;

        public static Trapecio Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new Trapecio();
                return instancia;
            }
        }

        private Trapecio()
        {
            InitializeComponent();
        }

        private void btnTrapecio_Click(object sender, EventArgs e)
        {
            try
            {
                float baseMayor = float.Parse(txtBaseMayor.Text);
                float altura = float.Parse(txtAltura.Text);
                float baseMenor = float.Parse(txtBaseMenor.Text);
                float lado = float.Parse(txtLado.Text);

                if (baseMayor <= 0.00f || altura <= 0.00f || baseMenor <= 0.00f || lado <= 0.00f)
                {
                    MessageBox.Show("Los valores deben ser mayores que cero.");
                    return;
                }

                float area = (altura * (baseMayor * baseMenor)) / 2;
                float perimetro = baseMayor + baseMenor + (lado * 2);

                MessageBox.Show("El área del trapecio es: " + area + "\n El perimetro es: " + perimetro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Los números ingresados no son válidos.\n" + ex.Message);
            }
        }
    }
}
