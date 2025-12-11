using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosU2
{
    internal class AlgoritmoLiangBarsky
    {
        private Graphics graphics;
        private Rectangle planoVisible;
        private List<string> registroRecorte;
        private float xMin, xMax, yMin, yMax;

        public AlgoritmoLiangBarsky(Graphics g, Rectangle plano)
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

        public List<PointF> RecortarPoligono(List<Point> poligonoOriginal)
        {
            registroRecorte.Clear();
            List<PointF> resultado = new List<PointF>();

            if (poligonoOriginal == null || poligonoOriginal.Count < 3)
                return resultado;

            registroRecorte.Add("=== ALGORITMO LIANG-BARSKY ===");
            registroRecorte.Add($"Polígono original: {poligonoOriginal.Count} vértices");
            registroRecorte.Add($"Ventana de recorte: ({xMin}, {yMin}) a ({xMax}, {yMax})");
            registroRecorte.Add("");
            registroRecorte.Add("PROCESAMIENTO DE ARISTAS:");
            registroRecorte.Add(new string('-', 60));

            List<PointF> poligono = poligonoOriginal.Select(p => new PointF(p.X, p.Y)).ToList();
            int aristasRecortadas = 0;
            int aristasConservadas = 0;
            int aristasFuera = 0;

            for (int i = 0; i < poligono.Count; i++)
            {
                PointF p1 = poligono[i];
                PointF p2 = poligono[(i + 1) % poligono.Count];

                registroRecorte.Add($"\nArista {i + 1}: ({p1.X:F1}, {p1.Y:F1}) → ({p2.X:F1}, {p2.Y:F1})");

                // Aplicar algoritmo Liang-Barsky a la arista
                PointF? inicio, fin;
                EstadoArista estado = RecortarArista(p1, p2, out inicio, out fin);

                switch (estado)
                {
                    case EstadoArista.Visible:
                        // Arista completamente visible
                        if (resultado.Count == 0 ||
                            Math.Abs(resultado[resultado.Count - 1].X - inicio.Value.X) > 0.01f ||
                            Math.Abs(resultado[resultado.Count - 1].Y - inicio.Value.Y) > 0.01f)
                        {
                            resultado.Add(inicio.Value);
                        }
                        resultado.Add(fin.Value);
                        registroRecorte.Add($"  Estado: VISIBLE (conservada)");
                        registroRecorte.Add($"  Puntos: ({inicio.Value.X:F1}, {inicio.Value.Y:F1}) → ({fin.Value.X:F1}, {fin.Value.Y:F1})");
                        aristasConservadas++;
                        break;

                    case EstadoArista.Recortada:
                        // Arista parcialmente visible (recortada)
                        if (resultado.Count == 0 ||
                            Math.Abs(resultado[resultado.Count - 1].X - inicio.Value.X) > 0.01f ||
                            Math.Abs(resultado[resultado.Count - 1].Y - inicio.Value.Y) > 0.01f)
                        {
                            resultado.Add(inicio.Value);
                        }
                        resultado.Add(fin.Value);
                        registroRecorte.Add($"  Estado: RECORTADA");
                        registroRecorte.Add($"  Original: ({p1.X:F1}, {p1.Y:F1}) → ({p2.X:F1}, {p2.Y:F1})");
                        registroRecorte.Add($"  Recortada: ({inicio.Value.X:F1}, {inicio.Value.Y:F1}) → ({fin.Value.X:F1}, {fin.Value.Y:F1})");
                        aristasRecortadas++;
                        break;

                    case EstadoArista.Invisible:
                        // Arista completamente fuera
                        registroRecorte.Add($"  Estado: INVISIBLE (descartada)");
                        aristasFuera++;
                        break;
                }
            }

            // Eliminar puntos duplicados consecutivos
            resultado = EliminarDuplicados(resultado);

            registroRecorte.Add("");
            registroRecorte.Add(new string('=', 60));
            registroRecorte.Add("RESUMEN:");
            registroRecorte.Add($"  Aristas conservadas: {aristasConservadas}");
            registroRecorte.Add($"  Aristas recortadas: {aristasRecortadas}");
            registroRecorte.Add($"  Aristas descartadas: {aristasFuera}");
            registroRecorte.Add($"  Vértices resultantes: {resultado.Count}");

            return resultado;
        }

        private EstadoArista RecortarArista(PointF p1, PointF p2, out PointF? inicio, out PointF? fin)
        {
            inicio = null;
            fin = null;

            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            float t0 = 0.0f;
            float t1 = 1.0f;

            // Array de valores p y q para las 4 condiciones de borde
            float[] p = new float[4];
            float[] q = new float[4];

            // Izquierda, Derecha, Abajo, Arriba
            p[0] = -dx; q[0] = p1.X - xMin;
            p[1] = dx; q[1] = xMax - p1.X;
            p[2] = -dy; q[2] = p1.Y - yMin;
            p[3] = dy; q[3] = yMax - p1.Y;

            for (int i = 0; i < 4; i++)
            {
                if (Math.Abs(p[i]) < 0.0001f)
                {
                    // Línea paralela al borde
                    if (q[i] < 0)
                    {
                        return EstadoArista.Invisible;
                    }
                }
                else
                {
                    float r = q[i] / p[i];

                    if (p[i] < 0)
                    {
                        // Línea que entra
                        if (r > t1)
                        {
                            return EstadoArista.Invisible;
                        }
                        else if (r > t0)
                        {
                            t0 = r;
                        }
                    }
                    else
                    {
                        // Línea que sale
                        if (r < t0)
                        {
                            return EstadoArista.Invisible;
                        }
                        else if (r < t1)
                        {
                            t1 = r;
                        }
                    }
                }
            }

            // Calcular puntos recortados
            inicio = new PointF(p1.X + t0 * dx, p1.Y + t0 * dy);
            fin = new PointF(p1.X + t1 * dx, p1.Y + t1 * dy);

            // Determinar si la arista fue recortada o está completamente visible
            if (t0 > 0.0001f || t1 < 0.9999f)
            {
                return EstadoArista.Recortada;
            }
            else
            {
                return EstadoArista.Visible;
            }
        }

        private List<PointF> EliminarDuplicados(List<PointF> puntos)
        {
            if (puntos.Count == 0)
                return puntos;

            List<PointF> resultado = new List<PointF>();
            resultado.Add(puntos[0]);

            for (int i = 1; i < puntos.Count; i++)
            {
                PointF anterior = resultado[resultado.Count - 1];
                PointF actual = puntos[i];

                if (Math.Abs(actual.X - anterior.X) > 0.01f ||
                    Math.Abs(actual.Y - anterior.Y) > 0.01f)
                {
                    resultado.Add(actual);
                }
            }

            // Verificar el último con el primero
            if (resultado.Count > 1)
            {
                PointF primero = resultado[0];
                PointF ultimo = resultado[resultado.Count - 1];

                if (Math.Abs(ultimo.X - primero.X) < 0.01f &&
                    Math.Abs(ultimo.Y - primero.Y) < 0.01f)
                {
                    resultado.RemoveAt(resultado.Count - 1);
                }
            }

            return resultado;
        }

        public void DibujarPoligonoRecortado(List<PointF> poligono, Color color)
        {
            if (poligono == null || poligono.Count < 3)
                return;

            using (Pen pen = new Pen(color, 2))
            using (Brush brush = new SolidBrush(Color.FromArgb(100, color)))
            {
                graphics.FillPolygon(brush, poligono.ToArray());
                graphics.DrawPolygon(pen, poligono.ToArray());

                using (Brush vertexBrush = new SolidBrush(color))
                {
                    foreach (var punto in poligono)
                    {
                        graphics.FillEllipse(vertexBrush, punto.X - 3, punto.Y - 3, 6, 6);
                    }
                }
            }
        }

        public List<string> ObtenerRegistroRecorte()
        {
            return new List<string>(registroRecorte);
        }

        private enum EstadoArista
        {
            Visible,      // Arista completamente dentro
            Recortada,    // Arista parcialmente dentro (fue recortada)
            Invisible     // Arista completamente fuera
        }
    }
}
