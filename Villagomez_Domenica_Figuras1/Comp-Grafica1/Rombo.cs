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
    public partial class Rombo : Form
    {
        private static Rombo instancia;

        public static Rombo Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new Rombo();
                return instancia;
            }
        }

        private Rombo()
        {
            InitializeComponent();
        }

        private void btnRombo_Click(object sender, EventArgs e)
        {
            try
            {
                float diagMayor = float.Parse(txtDiagMayor.Text);
                float diagMenor = float.Parse(txtDiagMenor.Text);
                float lado = float.Parse(txtLado.Text);

                if (diagMayor <= 0.00f || diagMenor <= 0.00f || lado <= 0.00f)
                {
                    MessageBox.Show("Los valores deben ser mayores que cero.");
                    return;
                }

                float area = diagMayor * diagMenor;
                float perimetro = lado * 4;

                MessageBox.Show("El área del rombo es: " + area + "\n El perimetro es: " + perimetro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Los números ingresados no son válidos.\n" + ex.Message);
            }
        }
    }
}
