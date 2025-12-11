using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosU2
{
    internal class AlgoritmoLiangBarskyLineas
    {
        private Graphics graphics;
        private Rectangle planoVisible;
        private List<string> registroRecorte;
        private float xMin, xMax, yMin, yMax;

        public AlgoritmoLiangBarskyLineas(Graphics g, Rectangle plano)
        {
            graphics = g;
            planoVisible = plano;
            registroRecorte = new List<string>();

            xMin = plano.Left;
            xMax = plano.Right;
            yMin = plano.Top;
            yMax = plano.Bottom;
        }

        public void DibujarPlanoRecorte()
        {
            using (Pen penRojo = new Pen(Color.Red, 2))
            {
                graphics.DrawRectangle(penRojo, planoVisible);
            }
        }

        public List<LineaRecortada> RecortarLineas(List<Point> puntosLineas)
        {
            registroRecorte.Clear();
            List<LineaRecortada> resultado = new List<LineaRecortada>();

            if (puntosLineas == null || puntosLineas.Count < 2)
                return resultado;

            int numeroLineas = puntosLineas.Count / 2;

            registroRecorte.Add("=== ALGORITMO LIANG-BARSKY (LÍNEAS) ===");
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

                EstadoLinea estado = RecortarLinea(ref x1, ref y1, ref x2, ref y2, i + 1);

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
                        registroRecorte.Add($"  Línea conservada: ({x1:F1}, {y1:F1}) → ({x2:F1}, {y2:F1})");
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

        private EstadoLinea RecortarLinea(ref float x1, ref float y1, ref float x2, ref float y2, int numeroLinea)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;

            float t0 = 0.0f;  // Parámetro t inicial
            float t1 = 1.0f;  // Parámetro t final

            registroRecorte.Add($"  Vector dirección: Δx={dx:F1}, Δy={dy:F1}");

            // Arrays para los valores p y q de las 4 ecuaciones
            float[] p = new float[4];
            float[] q = new float[4];

            // Configurar ecuaciones paramétricas
            // p[0]: -Δx (borde izquierdo)
            // p[1]:  Δx (borde derecho)
            // p[2]: -Δy (borde superior)
            // p[3]:  Δy (borde inferior)

            p[0] = -dx; q[0] = x1 - xMin;  // Izquierda
            p[1] = dx; q[1] = xMax - x1;  // Derecha
            p[2] = -dy; q[2] = y1 - yMin;  // Arriba
            p[3] = dy; q[3] = yMax - y1;  // Abajo

            registroRecorte.Add("");
            registroRecorte.Add("  Evaluación de bordes:");

            string[] nombresBorde = { "IZQUIERDO", "DERECHO", "SUPERIOR", "INFERIOR" };

            for (int i = 0; i < 4; i++)
            {
                registroRecorte.Add($"  Borde {nombresBorde[i]}:");
                registroRecorte.Add($"    p[{i}] = {p[i]:F3}, q[{i}] = {q[i]:F3}");

                if (Math.Abs(p[i]) < 0.0001f)
                {
                    // Línea paralela a este borde
                    registroRecorte.Add($"    → Línea PARALELA al borde");

                    if (q[i] < 0)
                    {
                        // Línea está completamente fuera
                        registroRecorte.Add($"    → q < 0: Línea completamente FUERA");
                        return EstadoLinea.Invisible;
                    }
                    registroRecorte.Add($"    → q >= 0: Continuar verificando");
                }
                else
                {
                    // Calcular el parámetro r = q/p
                    float r = q[i] / p[i];
                    registroRecorte.Add($"    r = q/p = {r:F3}");

                    if (p[i] < 0)
                    {
                        // Línea entrando por este borde (potencialmente entrante - PE)
                        registroRecorte.Add($"    → p < 0: Borde ENTRANTE (PE)");

                        if (r > t1)
                        {
                            // No hay intersección válida
                            registroRecorte.Add($"    → r > t1 ({r:F3} > {t1:F3}): Línea RECHAZADA");
                            return EstadoLinea.Invisible;
                        }

                        if (r > t0)
                        {
                            // Actualizar punto de entrada
                            registroRecorte.Add($"    → Actualizar t0: {t0:F3} → {r:F3}");
                            t0 = r;
                        }
                        else
                        {
                            registroRecorte.Add($"    → t0 no cambia (r <= t0)");
                        }
                    }
                    else
                    {
                        // Línea saliendo por este borde (potencialmente saliente - PS)
                        registroRecorte.Add($"    → p > 0: Borde SALIENTE (PS)");

                        if (r < t0)
                        {
                            // No hay intersección válida
                            registroRecorte.Add($"    → r < t0 ({r:F3} < {t0:F3}): Línea RECHAZADA");
                            return EstadoLinea.Invisible;
                        }

                        if (r < t1)
                        {
                            // Actualizar punto de salida
                            registroRecorte.Add($"    → Actualizar t1: {t1:F3} → {r:F3}");
                            t1 = r;
                        }
                        else
                        {
                            registroRecorte.Add($"    → t1 no cambia (r >= t1)");
                        }
                    }
                }
                registroRecorte.Add("");
            }

            registroRecorte.Add($"  Parámetros finales: t0 = {t0:F3}, t1 = {t1:F3}");

            // Verificar si hay intersección válida
            if (t0 > t1)
            {
                registroRecorte.Add($"  → t0 > t1: No hay intersección válida");
                return EstadoLinea.Invisible;
            }

            // Calcular los puntos de intersección usando la ecuación paramétrica
            float x1Nuevo = x1 + t0 * dx;
            float y1Nuevo = y1 + t0 * dy;
            float x2Nuevo = x1 + t1 * dx;
            float y2Nuevo = y1 + t1 * dy;

            registroRecorte.Add($"  Punto inicial: ({x1Nuevo:F1}, {y1Nuevo:F1})");
            registroRecorte.Add($"  Punto final: ({x2Nuevo:F1}, {y2Nuevo:F1})");

            // Determinar si la línea fue recortada
            bool fueRecortada = (t0 > 0.0001f || t1 < 0.9999f);

            // Actualizar las coordenadas
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

        public List<string> ObtenerRegistroRecorte()
        {
            return new List<string>(registroRecorte);
        }
    }
}
