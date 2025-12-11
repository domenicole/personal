using AlgoritmosU2;
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
    public partial class frmCorteLineas : Form
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private DibujoRelleno dibujo;
        private bool modoLibre = false;

        private List<Point> puntosLibres;
        private Rectangle planoVisible;
        private List<Point> lineasOriginal;
        private bool lineasCreado = false;

        private AlgoritmoCohenSutherland algoritmoCS;
        private AlgoritmoCyrusBeck algoritmoCB;
        private AlgoritmoLiangBarskyLineas algoritmoLB;  // ← CAMBIADO: Usar la versión para LÍNEAS

        private static frmCorteLineas instancia;
        public static frmCorteLineas Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new frmCorteLineas();
                return instancia;
            }
        }

        public frmCorteLineas()
        {
            InitializeComponent();

            bitmap = new Bitmap(panelDibujo.Width, panelDibujo.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            dibujo = new DibujoRelleno(graphics);
            puntosLibres = new List<Point>();

            int margen = 80;
            planoVisible = new Rectangle(
                margen,
                margen,
                panelDibujo.Width - (margen * 2),
                panelDibujo.Height - (margen * 2)
            );

            // Inicializar los tres algoritmos de recorte
            algoritmoCS = new AlgoritmoCohenSutherland(graphics, planoVisible);
            algoritmoCB = new AlgoritmoCyrusBeck(graphics, planoVisible);
            algoritmoLB = new AlgoritmoLiangBarskyLineas(graphics, planoVisible);  // ← CAMBIADO

            // Dibujar el plano visible inicialmente
            DibujarPlanoRecorte();
            ActualizarPanel();
        }

        private void DibujarPlanoRecorte()
        {
            using (Pen penRojo = new Pen(Color.Red, 2))
            {
                graphics.DrawRectangle(penRojo, planoVisible);
            }
        }

        private void ActualizarPanel()
        {
            panelDibujo.Invalidate();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            ReiniciarModos();
            modoLibre = true;
            puntosLibres.Clear();
            lineasCreado = false;

            // Limpiar y redibujar el plano
            LimpiarCanvas();
            DibujarPlanoRecorte();
            ActualizarPanel();

            MessageBox.Show("Modo Dibujo Libre activado.\n\nInstrucciones:\n" +
                          "• Clic izquierdo: Agregar puntos (cada 2 puntos forman una línea)\n" +
                          "• Clic derecho: Finalizar el dibujo de líneas\n" +
                          "• El plano rojo es la región visible (0000)\n\n" +
                          "Después podrás aplicar cualquiera de los 3 algoritmos de recorte.",
                          "Modo Dibujo Libre", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PanelDibujo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (modoLibre)
                {
                    puntosLibres.Add(new Point(e.X, e.Y));
                    dibujo.DibujarPuntoGuia(e.X, e.Y);

                    if (puntosLibres.Count % 2 == 0)
                    {
                        // Dibujar la línea entre los dos últimos puntos
                        Point puntoInicio = puntosLibres[puntosLibres.Count - 2];
                        Point puntoFin = puntosLibres[puntosLibres.Count - 1];

                        graphics.DrawLine(new Pen(Color.Black, 2), puntoInicio, puntoFin);

                        int numeroLineas = puntosLibres.Count / 2;
                        this.Text = $"Recorte de Líneas - {numeroLineas} línea(s) dibujada(s)";
                    }

                    ActualizarPanel();
                }
            }
            else if (e.Button == MouseButtons.Right && modoLibre)
            {
                if (puntosLibres.Count >= 2)
                {
                    // Guardar las líneas originales ANTES de limpiar
                    lineasOriginal = new List<Point>(puntosLibres);
                    lineasCreado = true;

                    // Limpiar y redibujar todo
                    LimpiarCanvas();
                    DibujarPlanoRecorte();
                    dibujo.DibujarLineas(puntosLibres);

                    ActualizarPanel();
                    modoLibre = false;

                    int numeroLineas = puntosLibres.Count / 2;
                    MessageBox.Show($"Se dibujaron {numeroLineas} línea(s).\n\n" +
                                  "Ahora puedes aplicar cualquiera de los 3 algoritmos:\n" +
                                  "• Cohen-Sutherland (azul)\n" +
                                  "• Cyrus-Beck (verde)\n" +
                                  "• Liang-Barsky (morado)",
                                  "Líneas Creadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Necesitas al menos 2 puntos para dibujar líneas.",
                                  "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCanvas();
            DibujarPlanoRecorte();
            puntosLibres.Clear();
            lineasOriginal = null;
            lineasCreado = false;
            ActualizarPanel();
            this.Text = "Recorte de Líneas";
        }

        private void btnCohenSutherland_Click(object sender, EventArgs e)
        {
            if (!ValidarLineas()) return;

            // Limpiar y redibujar
            LimpiarCanvas();
            DibujarPlanoRecorte();
            DibujarLineasOriginales();

            // Aplicar algoritmo Cohen-Sutherland
            var lineasRecortadas = algoritmoCS.RecortarLineas(lineasOriginal);
            algoritmoCS.DibujarLineasRecortadas(lineasRecortadas, Color.Blue);

            ActualizarPanel();

            // Mostrar registro del recorte
            MostrarRegistroRecorte("Cohen-Sutherland", algoritmoCS.ObtenerRegistroRecorte());
        }

        private void btnCyrusBeck_Click(object sender, EventArgs e)
        {
            if (!ValidarLineas()) return;

            LimpiarCanvas();
            DibujarPlanoRecorte();
            DibujarLineasOriginales();

            // Aplicar algoritmo Cyrus-Beck
            var lineasRecortadas = algoritmoCB.RecortarLineas(lineasOriginal);
            algoritmoCB.DibujarLineasRecortadas(lineasRecortadas, Color.Green);

            ActualizarPanel();

            // Mostrar registro del recorte
            MostrarRegistroRecorte("Cyrus-Beck", algoritmoCB.ObtenerRegistroRecorte());
        }

        private void btnLiangBarsky_Click(object sender, EventArgs e)
        {
            if (!ValidarLineas()) return;

            LimpiarCanvas();
            DibujarPlanoRecorte();
            DibujarLineasOriginales();

            // Aplicar algoritmo Liang-Barsky
            var lineasRecortadas = algoritmoLB.RecortarLineas(lineasOriginal);
            algoritmoLB.DibujarLineasRecortadas(lineasRecortadas, Color.Purple);

            ActualizarPanel();

            // Mostrar registro del recorte
            MostrarRegistroRecorte("Liang-Barsky", algoritmoLB.ObtenerRegistroRecorte());
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void ReiniciarModos()
        {
            modoLibre = false;
        }

        private void LimpiarCanvas()
        {
            graphics.Clear(Color.White);
        }

        private bool ValidarLineas()
        {
            if (!lineasCreado || lineasOriginal == null || lineasOriginal.Count < 2)
            {
                MessageBox.Show("Primero debes dibujar líneas.\n\n" +
                              "1. Presiona el botón 'Dibujar'\n" +
                              "2. Haz clic izquierdo para agregar puntos (cada 2 puntos forman una línea)\n" +
                              "3. Haz clic derecho para finalizar",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void DibujarLineasOriginales()
        {
            if (lineasOriginal == null || lineasOriginal.Count < 2)
                return;

            using (Pen penGris = new Pen(Color.LightGray, 1))
            {
                penGris.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                for (int i = 0; i < lineasOriginal.Count - 1; i += 2)
                {
                    if (i + 1 < lineasOriginal.Count)
                    {
                        graphics.DrawLine(penGris, lineasOriginal[i], lineasOriginal[i + 1]);
                    }
                }
            }
        }

        private void MostrarRegistroRecorte(string nombreAlgoritmo, List<string> registro)
        {
            if (registro == null || registro.Count == 0 || txtPuntos == null)
                return;

            // Limpiar el TextBox y mostrar el registro
            txtPuntos.Clear();

            foreach (string linea in registro)
            {
                txtPuntos.AppendText(linea + "\n");
            }

            txtPuntos.AppendText("\n");
            txtPuntos.AppendText(new string('=', 70) + "\n");
            txtPuntos.AppendText("LEYENDA:\n");
            txtPuntos.AppendText("• Gris punteado: Líneas originales\n");
            txtPuntos.AppendText("• Rojo: Plano de recorte (región visible)\n");

            switch (nombreAlgoritmo)
            {
                case "Cohen-Sutherland":
                    txtPuntos.AppendText("• Azul: Líneas recortadas\n");
                    txtPuntos.AppendText("\nCaracterísticas: Usa códigos de región (4 bits)\n");
                    break;
                case "Cyrus-Beck":
                    txtPuntos.AppendText("• Verde: Líneas recortadas\n");
                    txtPuntos.AppendText("\nCaracterísticas: Usa normales y productos punto\n");
                    txtPuntos.AppendText("  PE = Potencialmente Entrante (tomar MÁXIMO)\n");
                    txtPuntos.AppendText("  PS = Potencialmente Saliente (tomar MÍNIMO)\n");
                    break;
                case "Liang-Barsky":
                    txtPuntos.AppendText("• Morado: Líneas recortadas\n");
                    txtPuntos.AppendText("\nCaracterísticas: Usa ecuaciones paramétricas (t0, t1)\n");
                    break;
            }

            txtPuntos.SelectionStart = 0;
            txtPuntos.SelectionLength = 0;
            txtPuntos.ScrollToCaret();
        }

        private void frmCorteLineas_Load(object sender, EventArgs e)
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