using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosU2
{
    internal class AlgoritmoCohenSutherland
    {
        private Graphics graphics;
        private Rectangle planoVisible;
        private List<string> registroRecorte;
        private float xMin, xMax, yMin, yMax;

        // Códigos de región de Cohen-Sutherland
        private const int INSIDE = 0; // 0000
        private const int LEFT = 1;   // 0001
        private const int RIGHT = 2;  // 0010
        private const int BOTTOM = 4; // 0100
        private const int TOP = 8;    // 1000

        public AlgoritmoCohenSutherland(Graphics g, Rectangle plano)
        {
            graphics = g;
            planoVisible = plano;
            registroRecorte = new List<string>();

            xMin = plano.Left;
            xMax = plano.Right;
            yMin = plano.Top;
            yMax = plano.Bottom;
        }

        // Calcula el código de región para un punto
        private int CalcularCodigo(float x, float y)
        {
            int codigo = INSIDE;

            if (x < xMin)
                codigo |= LEFT;
            else if (x > xMax)
                codigo |= RIGHT;

            if (y < yMin)
                codigo |= TOP;
            else if (y > yMax)
                codigo |= BOTTOM;

            return codigo;
        }

        // Obtiene el nombre legible del código
        private string ObtenerNombreCodigo(int codigo)
        {
            if (codigo == INSIDE) return "INSIDE (0000)";

            List<string> partes = new List<string>();
            if ((codigo & TOP) != 0) partes.Add("TOP");
            if ((codigo & BOTTOM) != 0) partes.Add("BOTTOM");
            if ((codigo & LEFT) != 0) partes.Add("LEFT");
            if ((codigo & RIGHT) != 0) partes.Add("RIGHT");

            string binario = Convert.ToString(codigo, 2).PadLeft(4, '0');
            return $"{string.Join("-", partes)} ({binario})";
        }

        public List<LineaRecortada> RecortarLineas(List<Point> puntosLineas)
        {
            registroRecorte.Clear();
            List<LineaRecortada> resultado = new List<LineaRecortada>();

            if (puntosLineas == null || puntosLineas.Count < 2)
                return resultado;

            int numeroLineas = puntosLineas.Count / 2;

            registroRecorte.Add("=== ALGORITMO COHEN-SUTHERLAND ===");
            registroRecorte.Add($"Total de líneas: {numeroLineas}");
            registroRecorte.Add($"Ventana de recorte: ({xMin}, {yMin}) a ({xMax}, {yMax})");
            registroRecorte.Add("");
            registroRecorte.Add("PROCESAMIENTO DE LÍNEAS:");
            registroRecorte.Add(new string('-', 70));

            int lineasVisibles = 0;
            int lineasRecortadas = 0;
            int lineasInvisibles = 0;

            for (int i = 0; i < numeroLineas; i++)
            {
                Point p1 = puntosLineas[i * 2];
                Point p2 = puntosLineas[i * 2 + 1];

                registroRecorte.Add($"\nLínea {i + 1}: ({p1.X}, {p1.Y}) → ({p2.X}, {p2.Y})");

                float x1 = p1.X, y1 = p1.Y;
                float x2 = p2.X, y2 = p2.Y;

                int codigo1 = CalcularCodigo(x1, y1);
                int codigo2 = CalcularCodigo(x2, y2);

                registroRecorte.Add($"  Código P1: {ObtenerNombreCodigo(codigo1)}");
                registroRecorte.Add($"  Código P2: {ObtenerNombreCodigo(codigo2)}");

                EstadoLinea estado = RecortarLinea(ref x1, ref y1, ref x2, ref y2, codigo1, codigo2, i + 1);

                LineaRecortada lineaResultado = new LineaRecortada
                {
                    Original = new PointF[] { p1, p2 },
                    Estado = estado
                };

                if (estado != EstadoLinea.Invisible)
                {
                    lineaResultado.Recortada = new PointF[]
                    {
                        new PointF(x1, y1),
                        new PointF(x2, y2)
                    };

                    if (estado == EstadoLinea.Visible)
                    {
                        registroRecorte.Add($"  Estado: VISIBLE (completamente dentro)");
                        lineasVisibles++;
                    }
                    else
                    {
                        registroRecorte.Add($"  Estado: RECORTADA");
                        registroRecorte.Add($"  Nueva línea: ({x1:F1}, {y1:F1}) → ({x2:F1}, {y2:F1})");
                        lineasRecortadas++;
                    }
                }
                else
                {
                    registroRecorte.Add($"  Estado: INVISIBLE (completamente fuera)");
                    lineasInvisibles++;
                }

                resultado.Add(lineaResultado);
            }

            registroRecorte.Add("");
            registroRecorte.Add(new string('=', 70));
            registroRecorte.Add("RESUMEN:");
            registroRecorte.Add($"  Líneas visibles: {lineasVisibles}");
            registroRecorte.Add($"  Líneas recortadas: {lineasRecortadas}");
            registroRecorte.Add($"  Líneas invisibles: {lineasInvisibles}");
            registroRecorte.Add($"  Total procesadas: {numeroLineas}");

            return resultado;
        }

        private EstadoLinea RecortarLinea(ref float x1, ref float y1, ref float x2, ref float y2,
                                          int codigo1Inicial, int codigo2Inicial, int numeroLinea)
        {
            int codigo1 = codigo1Inicial;
            int codigo2 = codigo2Inicial;
            bool aceptada = false;
            bool fueRecortada = false;
            int iteracion = 0;

            while (true)
            {
                iteracion++;
                registroRecorte.Add($"    Iteración {iteracion}:");

                if ((codigo1 | codigo2) == 0)
                {
                    // Ambos puntos dentro
                    aceptada = true;
                    registroRecorte.Add($"      → Ambos códigos son 0000: Línea ACEPTADA");
                    break;
                }
                else if ((codigo1 & codigo2) != 0)
                {
                    // Ambos puntos en la misma región exterior
                    registroRecorte.Add($"      → AND de códigos != 0: Línea RECHAZADA");
                    break;
                }
                else
                {
                    // Línea necesita recorte
                    fueRecortada = true;
                    int codigoFuera = (codigo1 != 0) ? codigo1 : codigo2;
                    float x = 0, y = 0;

                    registroRecorte.Add($"      → Recortando punto con código {ObtenerNombreCodigo(codigoFuera)}");

                    // Encuentra el punto de intersección
                    if ((codigoFuera & TOP) != 0)
                    {
                        // Punto arriba del rectángulo
                        x = x1 + (x2 - x1) * (yMin - y1) / (y2 - y1);
                        y = yMin;
                        registroRecorte.Add($"      → Intersección con borde TOP: ({x:F1}, {y:F1})");
                    }
                    else if ((codigoFuera & BOTTOM) != 0)
                    {
                        // Punto abajo del rectángulo
                        x = x1 + (x2 - x1) * (yMax - y1) / (y2 - y1);
                        y = yMax;
                        registroRecorte.Add($"      → Intersección con borde BOTTOM: ({x:F1}, {y:F1})");
                    }
                    else if ((codigoFuera & RIGHT) != 0)
                    {
                        // Punto a la derecha del rectángulo
                        y = y1 + (y2 - y1) * (xMax - x1) / (x2 - x1);
                        x = xMax;
                        registroRecorte.Add($"      → Intersección con borde RIGHT: ({x:F1}, {y:F1})");
                    }
                    else if ((codigoFuera & LEFT) != 0)
                    {
                        // Punto a la izquierda del rectángulo
                        y = y1 + (y2 - y1) * (xMin - x1) / (x2 - x1);
                        x = xMin;
                        registroRecorte.Add($"      → Intersección con borde LEFT: ({x:F1}, {y:F1})");
                    }

                    // Reemplazar el punto fuera con el punto de intersección
                    if (codigoFuera == codigo1)
                    {
                        x1 = x;
                        y1 = y;
                        codigo1 = CalcularCodigo(x1, y1);
                        registroRecorte.Add($"      → Nuevo código P1: {ObtenerNombreCodigo(codigo1)}");
                    }
                    else
                    {
                        x2 = x;
                        y2 = y;
                        codigo2 = CalcularCodigo(x2, y2);
                        registroRecorte.Add($"      → Nuevo código P2: {ObtenerNombreCodigo(codigo2)}");
                    }
                }
            }

            if (aceptada)
            {
                return fueRecortada ? EstadoLinea.Recortada : EstadoLinea.Visible;
            }
            else
            {
                return EstadoLinea.Invisible;
            }
        }

        public void DibujarLineasRecortadas(List<LineaRecortada> lineas, Color color)
        {
            using (Pen pen = new Pen(color, 3))
            {
                foreach (var linea in lineas)
                {
                    if (linea.Estado != EstadoLinea.Invisible && linea.Recortada != null)
                    {
                        graphics.DrawLine(pen, linea.Recortada[0], linea.Recortada[1]);

                        // Dibujar puntos en los extremos
                        using (Brush brush = new SolidBrush(color))
                        {
                            graphics.FillEllipse(brush,
                                linea.Recortada[0].X - 4,
                                linea.Recortada[0].Y - 4, 8, 8);
                            graphics.FillEllipse(brush,
                                linea.Recortada[1].X - 4,
                                linea.Recortada[1].Y - 4, 8, 8);
                        }
                    }
                }
            }
        }

        public void DibujarPlanoRecorte()
        {
            using (Pen penRojo = new Pen(Color.Red, 2))
            {
                graphics.DrawRectangle(penRojo, planoVisible);
            }
        }

        public List<string> ObtenerRegistroRecorte()
        {
            return new List<string>(registroRecorte);
        }
    }

    public class LineaRecortada
    {
        public PointF[] Original { get; set; }
        public PointF[] Recortada { get; set; }
        public EstadoLinea Estado { get; set; }
    }

    public enum EstadoLinea
    {
        Visible,      // Línea completamente dentro
        Recortada,    // Línea parcialmente dentro (fue recortada)
        Invisible     // Línea completamente fuera
    }
}
