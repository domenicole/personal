using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosU2
{
    public partial class frmAlgRelleno : Form
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private DibujoRelleno dibujo;
        private CAlgoritmoDeRelleno algoritmoRelleno;
        private CScanline algoritmoScanline;
        private CPatron algoritmoPatron;

        private List<Point> puntosLibres;
        private bool modoLibre = false;
        private bool modoCuadrado = false;
        private bool modoCirculo = false;

        private string modoRellenoSeleccionado = "";
        public static bool animacionActiva = true;
        public static bool cancelado = false;

        private static frmAlgRelleno instancia;

        public static frmAlgRelleno Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new frmAlgRelleno();
                return instancia;
            }
        }
        public frmAlgRelleno()
        {
            InitializeComponent();
            inicializarGrafico();
        }

        private void inicializarGrafico()
        {
            bitmap = new Bitmap(panelDibujo.Width, panelDibujo.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            dibujo = new DibujoRelleno(graphics);
            puntosLibres = new List<Point>();
        }

        private void btnDibujoLibre_Click(object sender, EventArgs e)
        {
            ReiniciarModos();
            modoLibre = true;
            puntosLibres.Clear();
            MessageBox.Show("Modo Dibujo Libre activado.\nHaz clic para agregar puntos.\nHaz clic derecho para cerrar la figura.",
                          "Modo Dibujo Libre", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCirculo_Click(object sender, EventArgs e)
        {
            ReiniciarModos();
            modoCirculo = true;
            MessageBox.Show("Modo Círculo activado.\nHaz clic donde deseas el centro del círculo.",
                          "Modo Círculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            ReiniciarModos();
            modoCuadrado = true;
            MessageBox.Show("Modo Cuadrado activado.\nHaz clic donde deseas el centro del cuadrado.",
                          "Modo Cuadrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFloodfill_Click(object sender, EventArgs e)
        {
            ReiniciarModos();
            modoRellenoSeleccionado = "floodfill";
            MessageBox.Show("Algoritmo FloodFill seleccionado.\nHaz clic dentro de la figura para rellenarla.",
                          "FloodFill", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnScanline_Click(object sender, EventArgs e)
        {
            ReiniciarModos();
            modoRellenoSeleccionado = "scanline";
            MessageBox.Show("Algoritmo Scanline seleccionado.\nHaz clic dentro de la figura para rellenarla.",
                          "Scanline", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPatron_Click(object sender, EventArgs e)
        {
            ReiniciarModos();
            modoRellenoSeleccionado = "patron";
            MessageBox.Show("Algoritmo de Relleno por Patrón seleccionado.\nHaz clic dentro de la figura para rellenarla.",
                          "Relleno por Patrón", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            animacionActiva = false;
            MessageBox.Show("Animación desactivada. El relleno se completará instantáneamente.",
                          "Completar Instantáneo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnActivarAnimacion_Click(object sender, EventArgs e)
        {
            animacionActiva = true;
            MessageBox.Show("Animación activada. El relleno se mostrará paso a paso.",
                          "Animación Activada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PanelDibujo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (modoCuadrado)
                {
                    dibujo.DibujarCuadrado(e.X, e.Y, 100);
                    ActualizarPanel();
                    modoCuadrado = false;
                }
                else if (modoCirculo)
                {
                    dibujo.DibujarCirculo(e.X, e.Y, 50);
                    ActualizarPanel();
                    modoCirculo = false;
                }
                else if (modoLibre)
                {
                    puntosLibres.Add(new Point(e.X, e.Y));
                    dibujo.DibujarPuntoGuia(e.X, e.Y);
                    ActualizarPanel();
                }
                else if (!string.IsNullOrEmpty(modoRellenoSeleccionado))
                {
                    // Ejecutar el algoritmo de relleno seleccionado
                    EjecutarAlgoritmoRelleno(e.X, e.Y);
                    modoRellenoSeleccionado = ""; // Resetear después de usar
                }
            }
            else if (e.Button == MouseButtons.Right && modoLibre)
            {
                // Cerrar la figura en modo libre
                if (puntosLibres.Count >= 3)
                {
                    LimpiarCanvas();
                    dibujo.DibujarPoligonoLibre(puntosLibres);
                    ActualizarPanel();
                    modoLibre = false;
                }
                else
                {
                    MessageBox.Show("Necesitas al menos 3 puntos para crear una figura.",
                                  "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void EjecutarAlgoritmoRelleno(int x, int y)
        {
            cancelado = false;
            if (txtCoords != null)
            {
                txtCoords.Clear();
            }

            _ = EjecutarAlgoritmoRellenoAsync(x, y);
        }

        private async Task EjecutarAlgoritmoRellenoAsync(int x, int y)
        {
            switch (modoRellenoSeleccionado)
            {
                case "floodfill":
                    algoritmoRelleno = new CAlgoritmoDeRelleno(bitmap, txtCoords, panelDibujo);
                    algoritmoRelleno.FloodFill(x, y);
                    bitmap = algoritmoRelleno.ObtenerBitmap();
                    break;

                case "scanline":
                    algoritmoScanline = new CScanline(bitmap, txtCoords, panelDibujo);
                    await algoritmoScanline.RellenarAsync(x, y);
                    bitmap = algoritmoScanline.ObtenerBitmap();
                    break;

                case "patron":
                    algoritmoPatron = new CPatron(bitmap, txtCoords, panelDibujo);
                    await algoritmoPatron.RellenarAsync(x, y);
                    bitmap = algoritmoPatron.ObtenerBitmap();
                    break;
            }

            ActualizarPanel();
        }

        private void ReiniciarModos()
        {
            modoLibre = false;
            modoCuadrado = false;
            modoCirculo = false;
            modoRellenoSeleccionado = "";
            puntosLibres.Clear();
        }

        private void ActualizarPanel()
        {
            panelDibujo.Invalidate();
        }

        private void LimpiarCanvas()
        {
            graphics.Clear(Color.White);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void ResetCanvas()
        {
            cancelado = false;

            bitmap = new Bitmap(panelDibujo.Width, panelDibujo.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            dibujo = new DibujoRelleno(graphics);

            puntosLibres.Clear();
            modoLibre = false;
            modoCuadrado = false;
            modoCirculo = false;
            modoRellenoSeleccionado = "";

            txtCoords.Clear();

            panelDibujo.Invalidate();
            panelDibujo.Update();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelado = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ResetCanvas();
        }

        private void frmAlgRelleno_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.Location = new Point(
                    (this.MdiParent.ClientSize.Width - this.Width) / 2,
                    (this.MdiParent.ClientSize.Height - this.Height) / 2
                );
            }
        }
    }
}