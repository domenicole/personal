using AlgoritmoDeRelleno;
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
    public partial class frmPoligonos : Form
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private DibujoRelleno dibujo;
        private bool modoLibre = false;

        private List<Point> puntosLibres;
        private static frmPoligonos instancia;

        // Algoritmos de recorte
        private AlgoritmoSutherlandHodgman algoritmoSH;
        private AlgoritmoWeilerAtherton algoritmoWA;
        private AlgoritmoLiangBarsky algoritmoLB;

        private Rectangle planoVisible;
        private List<Point> poligonoOriginal;
        private bool poligonoCreado = false;

        public static frmPoligonos Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new frmPoligonos();
                return instancia;
            }
        }
        public frmPoligonos()
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
            algoritmoSH = new AlgoritmoSutherlandHodgman(graphics, planoVisible);
            algoritmoWA = new AlgoritmoWeilerAtherton(graphics, planoVisible);
            algoritmoLB = new AlgoritmoLiangBarsky(graphics, planoVisible);

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarModos();
            puntosLibres.Clear();
            poligonoOriginal = null;
            LimpiarCanvas();
            algoritmoSH.DibujarPlanoRecorte();
            ActualizarPanel();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCanvas();
            algoritmoSH.DibujarPlanoRecorte();
            puntosLibres.Clear();
            poligonoOriginal = null;
            ActualizarPanel();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            ReiniciarModos();
            modoLibre = true;
            puntosLibres.Clear();
            poligonoCreado = false;

            // Limpiar y redibujar el plano
            LimpiarCanvas();
            DibujarPlanoRecorte();
            ActualizarPanel();

            MessageBox.Show("Modo Dibujo Libre activado.\n\nInstrucciones:\n" +
                          "• Clic izquierdo: Agregar puntos\n" +
                          "• Clic derecho: Cerrar y dibujar la figura\n" +
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

                    // Dibujar líneas temporales mientras se agregan puntos
                    if (puntosLibres.Count > 1)
                    {
                        using (Pen penTemp = new Pen(Color.Gray, 1))
                        {
                            penTemp.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            graphics.DrawLine(penTemp,
                                            puntosLibres[puntosLibres.Count - 2],
                                            puntosLibres[puntosLibres.Count - 1]);
                        }
                    }

                    ActualizarPanel();
                }
            }
            else if (e.Button == MouseButtons.Right && modoLibre)
            {
                if (puntosLibres.Count >= 3)
                {
                    // Guardar el polígono original ANTES de limpiarlo
                    poligonoOriginal = new List<Point>(puntosLibres);
                    poligonoCreado = true;

                    // Limpiar y redibujar todo
                    LimpiarCanvas();
                    DibujarPlanoRecorte(); // ¡IMPORTANTE! Redibujar el plano de recorte
                    dibujo.DibujarPoligonoLibre(puntosLibres);

                    ActualizarPanel();
                    modoLibre = false;

                    MessageBox.Show($"Polígono creado con {puntosLibres.Count} vértices.\n\n" +
                                  "Ahora puedes aplicar cualquiera de los 3 algoritmos:\n" +
                                  "• Sutherland-Hodgman (azul)\n" +
                                  "• Weiler-Atherton (verde)\n" +
                                  "• Liang-Barsky (morado)",
                                  "Polígono Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Necesitas al menos 3 puntos para crear una figura.",
                                  "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        private void ReiniciarModos()
        {
            modoLibre = false;
        }

        private void ActualizarPanel()
        {
            panelDibujo.Invalidate();
        }

        private void LimpiarCanvas()
        {
            graphics.Clear(Color.White);
        }

        private void btnSutherland_Click(object sender, EventArgs e)
        {
            if (!ValidarPoligono()) return;

            // Ejecutar algoritmo
            List<PointF> poligonoRecortado = algoritmoSH.RecortarPoligono(poligonoOriginal);

            // Visualizar resultado
            LimpiarCanvas();
            algoritmoSH.DibujarPlanoRecorte();
            DibujarPoligonoOriginal();

            if (poligonoRecortado != null && poligonoRecortado.Count > 0)
            {
                algoritmoSH.DibujarPoligonoRecortado(poligonoRecortado, Color.Blue);
                MostrarInformacionRecorte("SUTHERLAND-HODGMAN", algoritmoSH.ObtenerRegistroRecorte(),
                                        poligonoRecortado.Count);
            }
            else
            {
                MessageBox.Show("El polígono está completamente fuera del plano visible.",
                              "Sutherland-Hodgman", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ActualizarPanel();
        }

        private void btnAtherton_Click(object sender, EventArgs e)
        {
            if (!ValidarPoligono()) return;

            // Ejecutar algoritmo
            List<List<PointF>> poligonosRecortados = algoritmoWA.RecortarPoligono(poligonoOriginal);

            // Visualizar resultado
            LimpiarCanvas();
            algoritmoWA.DibujarPlanoRecorte();
            DibujarPoligonoOriginal();

            if (poligonosRecortados != null && poligonosRecortados.Count > 0)
            {
                algoritmoWA.DibujarPoligonosRecortados(poligonosRecortados, Color.Green);

                int totalVertices = poligonosRecortados.Sum(p => p.Count);
                MostrarInformacionRecorte("WEILER-ATHERTON", algoritmoWA.ObtenerRegistroRecorte(),
                                        totalVertices, poligonosRecortados.Count);
            }
            else
            {
                MessageBox.Show("El polígono está completamente fuera del plano visible.",
                              "Weiler-Atherton", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ActualizarPanel();
        }

        private void btnLiangBarsky_Click(object sender, EventArgs e)
        {
            if (!ValidarPoligono()) return;

            // Ejecutar algoritmo
            List<PointF> poligonoRecortado = algoritmoLB.RecortarPoligono(poligonoOriginal);

            // Visualizar resultado
            LimpiarCanvas();
            algoritmoLB.DibujarPlanoRecorte();
            DibujarPoligonoOriginal();

            if (poligonoRecortado != null && poligonoRecortado.Count > 0)
            {
                algoritmoLB.DibujarPoligonoRecortado(poligonoRecortado, Color.Purple);
                MostrarInformacionRecorte("LIANG-BARSKY", algoritmoLB.ObtenerRegistroRecorte(),
                                        poligonoRecortado.Count);
            }
            else
            {
                MessageBox.Show("El polígono está completamente fuera del plano visible.",
                              "Liang-Barsky", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ActualizarPanel();
        }

        private bool ValidarPoligono()
        {
            if (!poligonoCreado || poligonoOriginal == null || poligonoOriginal.Count < 3)
            {
                MessageBox.Show("Primero debes dibujar un polígono antes de aplicar el recorte.\n\n" +
                              "1. Presiona el botón 'Dibujar'\n" +
                              "2. Haz clic izquierdo para agregar puntos\n" +
                              "3. Haz clic derecho para cerrar el polígono",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void DibujarPoligonoOriginal()
        {
            if (poligonoOriginal == null || poligonoOriginal.Count == 0)
                return;

            using (Pen penGris = new Pen(Color.LightGray, 1))
            using (Brush brushGris = new SolidBrush(Color.FromArgb(50, Color.Gray)))
            {
                graphics.FillPolygon(brushGris, poligonoOriginal.ToArray());
                graphics.DrawPolygon(penGris, poligonoOriginal.ToArray());
            }
        }

        private void MostrarInformacionRecorte(string nombreAlgoritmo, List<string> registro,
                                               int verticesFinales, int numPoligonos = 1)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"=== {nombreAlgoritmo} ===\n");
            sb.AppendLine($"Vértices originales: {poligonoOriginal.Count}");

            if (numPoligonos > 1)
            {
                sb.AppendLine($"Polígonos resultantes: {numPoligonos}");
                sb.AppendLine($"Total de vértices: {verticesFinales}");
            }
            else
            {
                sb.AppendLine($"Vértices después del recorte: {verticesFinales}");
            }

            sb.AppendLine("\nDETALLES DEL PROCESO:");
            sb.AppendLine(new string('-', 60));

            foreach (string linea in registro)
            {
                sb.AppendLine(linea);
            }

            sb.AppendLine("\n" + new string('=', 60));
            sb.AppendLine("LEYENDA:");
            sb.AppendLine("• Gris claro: Polígono original");
            sb.AppendLine("• Rojo: Plano de recorte (región visible 0000)");

            switch (nombreAlgoritmo)
            {
                case "SUTHERLAND-HODGMAN":
                    sb.AppendLine("• Azul: Polígono recortado");
                    sb.AppendLine("\nCaracterísticas: Recorte secuencial por cada borde");
                    break;
                case "WEILER-ATHERTON":
                    sb.AppendLine("• Verde: Polígono(s) recortado(s)");
                    sb.AppendLine("\nCaracterísticas: Maneja múltiples regiones resultantes");
                    break;
                case "LIANG-BARSKY":
                    sb.AppendLine("• Morado: Polígono recortado");
                    sb.AppendLine("\nCaracterísticas: Ecuaciones paramétricas, eficiente");
                    break;
            }

            txtPuntos.Text = sb.ToString();
        }

        private void frmPoligonos_Load(object sender, EventArgs e)
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
