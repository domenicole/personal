using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurvasDeBezier
{
    public partial class Curvas : Form
    {
        public Curvas()
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
        private void curvasBSplineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            BSpline frmBSpline = BSpline.Instancia;
            frmBSpline.MdiParent = this;
            frmBSpline.Show();
        }

        private void curvasDeBezierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            BSpline frmBSpline = BSpline.Instancia;
            frmBSpline.MdiParent = this;
            frmBSpline.Show();
        }
    }
}
