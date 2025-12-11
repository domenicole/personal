using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosU2
{
    internal class AlgoritmoCyrusBeck
    {
        private Graphics graphics;
        private Rectangle planoVisible;
        private List<string> registroRecorte;

        public AlgoritmoCyrusBeck(Graphics g, Rectangle plano)
        {
            graphics = g;
            planoVisible = plano;
            registroRecorte = new List<string>();
        }

        public List<LineaRecortada> RecortarLineas(List<Point> puntosLineas)
        {
            registroRecorte.Clear();
            List<LineaRecortada> resultado = new List<LineaRecortada>();

            if (puntosLineas == null || puntosLineas.Count < 2)
                return resultado;

            int numeroLineas = puntosLineas.Count / 2;

            registroRecorte.Add("=== ALGORITMO CYRUS-BECK ===");
            registroRecorte.Add($"Total de líneas: {numeroLineas}");
            registroRecorte.Add($"Ventana de recorte: ({planoVisible.Left}, {planoVisible.Top}) " +
                              $"a ({planoVisible.Right}, {planoVisible.Bottom})");
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

                EstadoLinea estado = RecortarLineaCyrusBeck(ref x1, ref y1, ref x2, ref y2);

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

        private EstadoLinea RecortarLineaCyrusBeck(ref float x1, ref float y1, ref float x2, ref float y2)
        {
            // Vector dirección de la línea
            float dx = x2 - x1;
            float dy = y2 - y1;

            registroRecorte.Add($"  Vector dirección D: ({dx:F1}, {dy:F1})");

            // Parámetros t
            float tE = 0.0f;  // tEntrada: máximo de los entrantes
            float tL = 1.0f;  // tSalida: mínimo de los salientes

            // Definir los 4 bordes del rectángulo con sus normales hacia adentro
            // Orden: Izquierdo, Derecho, Inferior, Superior

            // Estructura de datos para cada borde
            var bordes = new[]
            {
                new {
                    Nombre = "IZQUIERDO",
                    Punto = new PointF(planoVisible.Left, planoVisible.Top),
                    Normal = new PointF(1, 0),  // Normal hacia la derecha (adentro)
                    p = -dx,
                    q = x1 - planoVisible.Left
                },
                new {
                    Nombre = "DERECHO",
                    Punto = new PointF(planoVisible.Right, planoVisible.Top),
                    Normal = new PointF(-1, 0),  // Normal hacia la izquierda (adentro)
                    p = dx,
                    q = planoVisible.Right - x1
                },
                new {
                    Nombre = "INFERIOR",
                    Punto = new PointF(planoVisible.Left, planoVisible.Bottom),
                    Normal = new PointF(0, -1),  // Normal hacia arriba (adentro)
                    p = dy,
                    q = planoVisible.Bottom - y1
                },
                new {
                    Nombre = "SUPERIOR",
                    Punto = new PointF(planoVisible.Left, planoVisible.Top),
                    Normal = new PointF(0, 1),  // Normal hacia abajo (adentro)
                    p = -dy,
                    q = y1 - planoVisible.Top
                }
            };

            registroRecorte.Add("");

            foreach (var borde in bordes)
            {
                // Calcular el producto punto D·N
                float dDotN = dx * borde.Normal.X + dy * borde.Normal.Y;

                // Vector desde punto del borde al punto inicial de la línea
                float wx = x1 - borde.Punto.X;
                float wy = y1 - borde.Punto.Y;
                float wDotN = wx * borde.Normal.X + wy * borde.Normal.Y;

                registroRecorte.Add($"  Borde {borde.Nombre}:");
                registroRecorte.Add($"    Normal: ({borde.Normal.X}, {borde.Normal.Y})");
                registroRecorte.Add($"    D·N = {dDotN:F3}, W·N = {wDotN:F3}");

                if (Math.Abs(dDotN) < 0.00001f)
                {
                    // Línea paralela al borde
                    registroRecorte.Add($"    → Línea PARALELA al borde");

                    if (wDotN < 0)
                    {
                        // La línea está completamente fuera
                        registroRecorte.Add($"    → W·N < 0: Línea completamente FUERA");
                        return EstadoLinea.Invisible;
                    }
                    registroRecorte.Add($"    → W·N >= 0: Continuar");
                }
                else
                {
                    // Calcular t donde la línea cruza este borde
                    float t = -wDotN / dDotN;
                    registroRecorte.Add($"    t = -W·N / D·N = {t:F3}");

                    if (dDotN < 0)
                    {
                        // Borde Potencialmente Entrante (PE)
                        registroRecorte.Add($"    → D·N < 0: Borde PE (Potencialmente Entrante)");

                        if (t > tE)
                        {
                            tE = t;
                            registroRecorte.Add($"    → Actualizar tE = {tE:F3} (tomar MÁXIMO)");
                        }
                        else
                        {
                            registroRecorte.Add($"    → tE no cambia ({t:F3} <= {tE:F3})");
                        }
                    }
                    else
                    {
                        // Borde Potencialmente Saliente (PL - Potentially Leaving)
                        registroRecorte.Add($"    → D·N > 0: Borde PL (Potencialmente Saliente)");

                        if (t < tL)
                        {
                            tL = t;
                            registroRecorte.Add($"    → Actualizar tL = {tL:F3} (tomar MÍNIMO)");
                        }
                        else
                        {
                            registroRecorte.Add($"    → tL no cambia ({t:F3} >= {tL:F3})");
                        }
                    }
                }

                // Verificación temprana de invisibilidad
                if (tE > tL)
                {
                    registroRecorte.Add($"    → tE > tL ({tE:F3} > {tL:F3}): Línea INVISIBLE");
                    return EstadoLinea.Invisible;
                }

                registroRecorte.Add("");
            }

            registroRecorte.Add($"  Parámetros finales: tE = {tE:F3}, tL = {tL:F3}");

            // Verificar validez del segmento
            if (tE > tL)
            {
                registroRecorte.Add($"  → tE > tL: Sin segmento visible");
                return EstadoLinea.Invisible;
            }

            // Calcular los nuevos puntos
            float x1Nuevo = x1 + tE * dx;
            float y1Nuevo = y1 + tE * dy;
            float x2Nuevo = x1 + tL * dx;
            float y2Nuevo = y1 + tL * dy;

            registroRecorte.Add($"  Punto entrada (t={tE:F3}): ({x1Nuevo:F1}, {y1Nuevo:F1})");
            registroRecorte.Add($"  Punto salida (t={tL:F3}): ({x2Nuevo:F1}, {y2Nuevo:F1})");

            // Determinar si fue recortada
            bool fueRecortada = (tE > 0.0001f || tL < 0.9999f);

            x1 = x1Nuevo;
            y1 = y1Nuevo;
            x2 = x2Nuevo;
            y2 = y2Nuevo;

            return fueRecortada ? EstadoLinea.Recortada : EstadoLinea.Visible;
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
}