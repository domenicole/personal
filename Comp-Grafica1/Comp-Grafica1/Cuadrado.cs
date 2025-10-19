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
    public partial class Cuadrado : Form
    {
        private static Cuadrado instancia;

        public static Cuadrado Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new Cuadrado();
                return instancia;
            }
        }

        private Cuadrado()
        {
            InitializeComponent();
        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            try
            {
                float lado = float.Parse(txtLado.Text);

                if (lado <= 0.00f)
                {
                    MessageBox.Show("Los lados deben ser mayores que cero.");
                    return;
                }

                float area = lado * lado;
                float perimetro = lado*4;

                MessageBox.Show("El área del cuadrado es: " + area + "\n El perimetro es: " + perimetro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Los números ingresados no son válidos.\n" + ex.Message);
            }
        }
    }
}
