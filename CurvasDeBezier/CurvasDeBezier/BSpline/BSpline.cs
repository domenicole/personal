using CurvasDeBezier.Bezier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CurvasDeBezier
{
    public partial class BSpline : Form
    {
        private CBSpline curva;
        private int puntoSeleccionado = -1;
        private bool arrastrando = false;
        private bool animando = false;
        private double tAnimacion = 0;
        private const double VELOCIDAD_ANIMACION = 0.008;
        private Timer timerAnimacion;

        private static BSpline instancia;

        public static BSpline Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new BSpline();
                return instancia;
            }
        }
        public BSpline()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Configurar timer
            timerAnimacion = new Timer();
            timerAnimacion.Interval = 20;
            timerAnimacion.Tick += TimerAnimacion_Tick;

            // Configurar panel
            panelDibujo.DoubleBuffered(true);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (animando)
            {
                animando = false;
                timerAnimacion.Stop();
            }

            int numPuntos = (int)numPuntosControl.Value;
            int grado = rbCuadratica.Checked ? 2 : 3;
            bool cerrada = rbCerrada.Checked;

            // Validar número mínimo de puntos
            if (numPuntos < grado + 1)
            {
                MessageBox.Show($"Se necesitan al menos {grado + 1} puntos para una B-Spline de grado {grado}",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPuntosControl.Value = grado + 1;
                return;
            }

            // Generar puntos de control
            List<PointF> puntos = GenerarPuntosControl(numPuntos, cerrada);
            curva = new CBSpline(puntos, grado, cerrada);

            btnAnimar.Enabled = true;
            lblTipoCurva.Text = curva.ObtenerTipoCurva();
            tAnimacion = 0;
            panelDibujo.Invalidate();
        }

        private List<PointF> GenerarPuntosControl(int numPuntos, bool cerrada)
        {
            List<PointF> puntos = new List<PointF>();
            float centerX = panelDibujo.Width / 2f;
            float centerY = panelDibujo.Height / 2f;
            float radio = Math.Min(centerX, centerY) - 80;

            if (cerrada)
            {
                // Distribución circular para curvas cerradas
                for (int i = 0; i < numPuntos; i++)
                {
                    double angulo = 2 * Math.PI * i / numPuntos;
                    float x = centerX + radio * (float)Math.Cos(angulo);
                    float y = centerY + radio * (float)Math.Sin(angulo);
                    puntos.Add(new PointF(x, y));
                }
            }
            else
            {
                // Distribución sinusoidal para curvas abiertas
                float margen = 60;
                float ancho = panelDibujo.Width - 2 * margen;
                float alto = panelDibujo.Height - 2 * margen;

                for (int i = 0; i < numPuntos; i++)
                {
                    float t = (float)i / (numPuntos - 1);
                    float x = margen + t * ancho;
                    float y = centerY + (float)(Math.Sin(t * Math.PI * 2) * alto * 0.3);
                    puntos.Add(new PointF(x, y));
                }
            }

            return puntos;
        }

        private void btnAnimar_Click(object sender, EventArgs e)
        {
            if (curva == null)
            {
                MessageBox.Show("Primero debes crear una curva", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (animando)
            {
                animando = false;
                timerAnimacion.Stop();
                btnAnimar.Text = "Animar";
                panelDibujo.Invalidate();
            }
            else
            {
                animando = true;
                tAnimacion = 0;
                timerAnimacion.Start();
                btnAnimar.Text = "Detener";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            curva = null;
            animando = false;
            timerAnimacion.Stop();
            tAnimacion = 0;
            btnAnimar.Enabled = false;
            btnAnimar.Text = "Animar";
            lblTipoCurva.Text = "Tipo de curva: -";
            numPuntosControl.Value = 5;
            rbCuadratica.Checked = false;
            rbCubica.Checked = true;
            rbAbierta.Checked = true;
            rbCerrada.Checked = false;
            panelDibujo.Invalidate();
        }

        private void TimerAnimacion_Tick(object sender, EventArgs e)
        {
            if (!animando || curva == null) return;

            tAnimacion += VELOCIDAD_ANIMACION;

            if (tAnimacion >= 1.0)
            {
                tAnimacion = 0;
            }

            panelDibujo.Invalidate();
        }

        private void PanelDibujo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (curva == null) return;

            // Dibujar líneas de control
            DibujarLineasControl(g, curva.PuntosControl);

            // Dibujar curva
            DibujarCurva(g);

            // Dibujar puntos de control
            DibujarPuntosControl(g, curva.PuntosControl);

            // Dibujar animación
            if (animando)
            {
                var datos = curva.CalcularDatosAnimacion(tAnimacion);
                DibujarPuntoAnimacion(g, datos.PuntoActual);
            }
        }

        private void DibujarLineasControl(Graphics g, List<PointF> puntos)
        {
            if (puntos.Count < 2) return;

            Pen lapiz = new Pen(Color.LightGray, 1f);
            lapiz.DashStyle = DashStyle.Dash;

            for (int i = 0; i < puntos.Count - 1; i++)
            {
                g.DrawLine(lapiz, puntos[i], puntos[i + 1]);
            }

            if (curva.EsCerrada && puntos.Count > 0)
            {
                g.DrawLine(lapiz, puntos[puntos.Count - 1], puntos[0]);
            }

            lapiz.Dispose();
        }

        private void DibujarCurva(Graphics g)
        {
            var puntosCurva = curva.GenerarCurva(200);
            if (puntosCurva.Count < 2) return;

            Pen lapiz = new Pen(Color.Blue, 2.5f);
            lapiz.LineJoin = LineJoin.Round;

            for (int i = 0; i < puntosCurva.Count - 1; i++)
            {
                g.DrawLine(lapiz, puntosCurva[i], puntosCurva[i + 1]);
            }

            lapiz.Dispose();
        }

        private void DibujarPuntosControl(Graphics g, List<PointF> puntos)
        {
            const float radio = 6f;
            Brush pincel = new SolidBrush(Color.Red);

            foreach (var punto in puntos)
            {
                g.FillEllipse(pincel, punto.X - radio, punto.Y - radio, radio * 2, radio * 2);
                g.DrawEllipse(Pens.Black, punto.X - radio, punto.Y - radio, radio * 2, radio * 2);
            }

            pincel.Dispose();
        }

        private void DibujarPuntoAnimacion(Graphics g, PointF punto)
        {
            const float radio = 8f;
            Brush pincel = new SolidBrush(Color.Green);
            g.FillEllipse(pincel, punto.X - radio, punto.Y - radio, radio * 2, radio * 2);
            g.DrawEllipse(new Pen(Color.DarkGreen, 2), punto.X - radio, punto.Y - radio, radio * 2, radio * 2);
            pincel.Dispose();
        }

        private void PanelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (curva == null) return;

            puntoSeleccionado = ObtenerPuntoCercano(e.Location, curva.PuntosControl);

            if (puntoSeleccionado >= 0)
            {
                arrastrando = true;
                panelDibujo.Cursor = Cursors.Hand;
            }
        }

        private void PanelDibujo_MouseMove(object sender, MouseEventArgs e)
        {
            if (curva == null) return;

            if (!arrastrando)
            {
                int indice = ObtenerPuntoCercano(e.Location, curva.PuntosControl);
                panelDibujo.Cursor = indice >= 0 ? Cursors.Hand : Cursors.Default;
            }

            if (arrastrando && puntoSeleccionado >= 0)
            {
                var puntos = curva.PuntosControl;
                float x = Math.Max(0, Math.Min(e.X, panelDibujo.Width));
                float y = Math.Max(0, Math.Min(e.Y, panelDibujo.Height));
                puntos[puntoSeleccionado] = new PointF(x, y);
                curva.PuntosControl = puntos;
                panelDibujo.Invalidate();
            }
        }

        private void PanelDibujo_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrando = false;
            puntoSeleccionado = -1;
            panelDibujo.Cursor = Cursors.Default;
        }

        private int ObtenerPuntoCercano(Point mouse, List<PointF> puntos, float tolerancia = 10f)
        {
            for (int i = 0; i < puntos.Count; i++)
            {
                float dx = mouse.X - puntos[i].X;
                float dy = mouse.Y - puntos[i].Y;
                float distancia = (float)Math.Sqrt(dx * dx + dy * dy);

                if (distancia <= tolerancia)
                    return i;
            }
            return -1;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerAnimacion?.Stop();
            timerAnimacion?.Dispose();
            base.OnFormClosing(e);
        }
    }

    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            var property = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            property?.SetValue(control, enable, null);
        }
    }
}