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
    public partial class Triangulo : Form
    {
        private static Triangulo instancia;

        public static Triangulo Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new Triangulo();
                return instancia;
            }
        }

        private Triangulo()
        {
            InitializeComponent();
        }

        private void btnTriangulo_Click(object sender, EventArgs e)
        {
            try
            {
                float baser = float.Parse(txtBase.Text);
                float altura = float.Parse(txtAltura.Text);
                float lado = float.Parse(txtLado.Text);

                if (baser <= 0.00f || altura <= 0.00f || lado <= 0.00f)
                {
                    MessageBox.Show("Los valores deben ser mayores que cero.");
                    return;
                }

                float area = (baser * altura) / 2;
                float perimetro = lado * 3;

                MessageBox.Show("El área del triángulo es: " + area + "\n El perimetro es: " + perimetro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Los números ingresados no son válidos.\n" + ex.Message);
            }
        }
    }
}
