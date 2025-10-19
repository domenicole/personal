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
    public partial class Circulo : Form
    {
        private static Circulo instancia;

        public static Circulo Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new Circulo();
                return instancia;
            }
        }

        private Circulo()
        {
            InitializeComponent();
        }

        private void btnCirculo_Click(object sender, EventArgs e)
        {
            try
            {
                double radio = double.Parse(txtRadio.Text);
                double diametro = radio * 2;
                double pi = 3.1416;

                if (radio <= 0.00f)
                {
                    MessageBox.Show("Los lados deben ser mayores que cero.");
                    return;
                }

                double area = pi * (radio * radio);
                double circunferencia = pi * diametro;

                MessageBox.Show("El área del circulo es: " + area + "\n La circunferencia es: " + circunferencia);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Los números ingresados no son válidos.\n" + ex.Message);
            }
        }
    }
}
