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
    public partial class Rectangulo : Form
    {
        private static Rectangulo instancia;

        public static Rectangulo Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new Rectangulo();
                return instancia;
            }
        }

        private Rectangulo()
        {
            InitializeComponent();
        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            try
            {
                float baser = float.Parse(txtBase.Text);
                float altura = float.Parse(txtAltura.Text);

                if (baser <= 0.00f || altura <= 0.00f)
                {
                    MessageBox.Show("Los valores deben ser mayores que cero.");
                    return;
                }

                float area = baser * altura;
                float perimetro = baser + baser + altura + altura;

                MessageBox.Show("El área del rectángulo es: " + area + "\n El perimetro es: " + perimetro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Los números ingresados no son válidos.\n" + ex.Message);
            }
        }
    }
}
