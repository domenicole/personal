using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurvasDeBezier.Bezier
{
    public partial class frmBezierLineales : Form
    {
        private Bezier curva;
        private Dibujo dibujo;

        private int puntoSeleccionado = -1;
        private bool arrastrando = false;
        private bool animando = false;
        private double tAnimacion = 0;
        private const double VELOCIDAD_ANIMACION = 0.01;

        private static frmBezierLineales instancia;

        public static frmBezierLineales Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new frmBezierLineales();
                return instancia;
            }
        }

        public frmBezierLineales()
        {
            InitializeComponent();

            // Inicializar el objeto dibujo
            dibujo = new Dibujo();

            // Configurar el NumericUpDown
            if (puntosDeControl != null)
            {
                puntosDeControl.Minimum = 2;
                puntosDeControl.Maximum = 10;
                puntosDeControl.Value = 4;
            }

            // Configurar el timer
            if (timerAnimacion == null)
            {
                timerAnimacion = new Timer();
                timerAnimacion.Interval = 20; // 50 FPS
                timerAnimacion.Tick += TimerAnimacion_Tick;
            }

            // Configurar el panel de dibujo con doble buffer
            if (panelDibujo != null)
            {
                panelDibujo.DoubleBuffered(true);
            }

            // Deshabilitar botón animar al inicio
            if (btnAnimar != null)
            {
                btnAnimar.Enabled = false;
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (puntosDeControl == null)
            {
                MessageBox.Show("Error: Control puntosDeControl no encontrado", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Detener animación si está activa
            if (animando)
            {
                animando = false;
                timerAnimacion?.Stop();
            }

            int numPuntos = (int)puntosDeControl.Value;
            List<PointF> puntos;

            // Generar puntos según el tipo de curva
            if (numPuntos <= 4)
            {
                puntos = Dibujo.GenerarPuntosDiagonal(numPuntos, panelDibujo.Width, panelDibujo.Height);
            }
            else
            {
                puntos = Dibujo.GenerarPuntosAleatorios(numPuntos, panelDibujo.Width, panelDibujo.Height);
            }

            curva = new Bezier(puntos);

            // Habilitar botón de animación
            if (btnAnimar != null)
            {
                btnAnimar.Enabled = true;
                btnAnimar.Text = "Animar Curva";
            }

            tAnimacion = 0;
            panelDibujo.Invalidate();
        }

        private void btnAnimar_Click(object sender, EventArgs e)
        {
            if (curva == null)
            {
                MessageBox.Show("Primero debes crear una curva con el botón Aplicar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (animando)
            {
                // Detener animación
                animando = false;
                timerAnimacion.Stop();
                btnAnimar.Text = "Animar Curva";
                panelDibujo.Invalidate();
            }
            else
            {
                // Iniciar animación
                animando = true;
                tAnimacion = 0;
                timerAnimacion.Start();
                btnAnimar.Text = "Detener Animación";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            curva = null;
            animando = false;

            if (timerAnimacion != null)
            {
                timerAnimacion.Stop();
            }

            tAnimacion = 0;

            if (btnAnimar != null)
            {
                btnAnimar.Enabled = false;
                btnAnimar.Text = "Animar Curva";
            }

            if (puntosDeControl != null)
            {
                puntosDeControl.Value = 4;
            }

            panelDibujo.Invalidate();
        }

        private void TimerAnimacion_Tick(object sender, EventArgs e)
        {
            if (!animando || curva == null) return;

            // Incrementar el valor de t
            tAnimacion += VELOCIDAD_ANIMACION;

            // Reiniciar cuando llegue al final
            if (tAnimacion >= 1.0)
            {
                tAnimacion = 0;
            }

            // Redibujar
            panelDibujo.Invalidate();
        }

        private void PanelDibujo_Paint(object sender, PaintEventArgs e)
        {
            if (curva == null || dibujo == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int numPuntos = curva.PuntosControl.Count;

            // Dibujar la curva según su tipo
            bool mostrarPuntosControl = !animando;

            switch (numPuntos)
            {
                case 2:
                    dibujo.DibujarLineal(g, curva, mostrarPuntosControl);
                    break;
                case 3:
                    dibujo.DibujarCuadratica(g, curva, mostrarPuntosControl);
                    break;
                case 4:
                    dibujo.DibujarCubica(g, curva, mostrarPuntosControl);
                    break;
                default:
                    dibujo.DibujarGradoSuperior(g, curva, mostrarPuntosControl);
                    break;
            }

            // Dibujar animación si está activa
            if (animando)
            {
                // Obtener datos completos del algoritmo de De Casteljau
                var datosCasteljau = curva.AlgoritmoDeCasteljauCompleto(tAnimacion);

                // Dibujar líneas auxiliares entre niveles
                DibujarLineasAuxiliares(g, datosCasteljau);

                // Dibujar todos los puntos intermedios
                var puntosIntermedios = datosCasteljau.ObtenerTodosPuntosIntermedios();
                dibujo.DibujarAlgoritmoDeCasteljau(g, puntosIntermedios);

                // Dibujar el punto final (el que viaja por la curva)
                dibujo.DibujarPuntoAnimacion(g, datosCasteljau.PuntoFinal);

                // Dibujar los puntos de control durante la animación
                DibujarPuntosControl(g, curva.PuntosControl);
            }
        }

        // Dibuja las líneas auxiliares del algoritmo de De Casteljau
        private void DibujarLineasAuxiliares(Graphics g, DatosDeCasteljau datos)
        {
            if (datos == null || datos.Niveles == null || datos.Niveles.Count < 2) return;

            Pen lapizAuxiliar = new Pen(Color.FromArgb(150, Color.Orange), 1.5f);
            lapizAuxiliar.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            // Dibujar líneas que conectan puntos consecutivos en cada nivel
            for (int nivel = 0; nivel < datos.Niveles.Count; nivel++)
            {
                var puntosNivel = datos.Niveles[nivel];

                for (int i = 0; i < puntosNivel.Count - 1; i++)
                {
                    g.DrawLine(lapizAuxiliar, puntosNivel[i], puntosNivel[i + 1]);
                }
            }

            lapizAuxiliar.Dispose();
        }

        // Dibuja los puntos de control
        private void DibujarPuntosControl(Graphics g, List<PointF> puntos)
        {
            const float RADIO_PUNTO = 6f;
            Brush pincelPuntos = new SolidBrush(Color.Red);

            foreach (var punto in puntos)
            {
                g.FillEllipse(pincelPuntos,
                    punto.X - RADIO_PUNTO,
                    punto.Y - RADIO_PUNTO,
                    RADIO_PUNTO * 2,
                    RADIO_PUNTO * 2);

                g.DrawEllipse(Pens.Black,
                    punto.X - RADIO_PUNTO,
                    punto.Y - RADIO_PUNTO,
                    RADIO_PUNTO * 2,
                    RADIO_PUNTO * 2);
            }

            pincelPuntos.Dispose();
        }

        private void PanelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (curva == null) return;

            puntoSeleccionado = Dibujo.ObtenerIndicePuntoCercano(e.Location, curva.PuntosControl);

            if (puntoSeleccionado >= 0)
            {
                arrastrando = true;
                panelDibujo.Cursor = Cursors.Hand;
            }
        }

        private void PanelDibujo_MouseMove(object sender, MouseEventArgs e)
        {
            if (curva == null) return;

            // Cambiar cursor si está sobre un punto
            if (!arrastrando)
            {
                int indice = Dibujo.ObtenerIndicePuntoCercano(e.Location, curva.PuntosControl);
                panelDibujo.Cursor = indice >= 0 ? Cursors.Hand : Cursors.Default;
            }

            // Mover punto si está arrastrando
            if (arrastrando && puntoSeleccionado >= 0)
            {
                var puntos = curva.PuntosControl;

                // Limitar el movimiento dentro del panel
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerAnimacion?.Stop();
            timerAnimacion?.Dispose();
            dibujo?.Dispose();
            base.OnFormClosing(e);
        }
    }

    // Clase de extensión para habilitar DoubleBuffered en Panel
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