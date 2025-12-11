using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosU2
{
    public partial class frmAlgoritmos : Form
    {
        public frmAlgoritmos()
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

        private void algoritmoDeLineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            frmAlgLineas frmAlgoritmoLineas = frmAlgLineas.Instancia;
            frmAlgoritmoLineas.MdiParent = this;
            frmAlgoritmoLineas.Show();
        }

        private void algoritmoCircunferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Circunferencia Circunferencia = Circunferencia.Instancia;
            Circunferencia.MdiParent = this;
            Circunferencia.Show();
        }

        private void algoritmoDeRellenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            frmAlgRelleno frmAlgoritmoRelleno = frmAlgRelleno.Instancia;
            frmAlgoritmoRelleno.MdiParent = this;
            frmAlgoritmoRelleno.Show();
        }

        private void algoritmoDeRecorteDeLineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            frmCorteLineas frmCorteLineas = frmCorteLineas.Instancia;
            frmCorteLineas.MdiParent = this;
            frmCorteLineas.Show();
        }

        private void algoritmoDeRecorteDePolígonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            frmPoligonos frmPoligonos = frmPoligonos.Instancia;
            frmPoligonos.MdiParent = this;
            frmPoligonos.Show();
        }
    }
}
