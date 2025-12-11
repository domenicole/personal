using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosU2
{
    internal class AlgoritmoWeilerAtherton
    {
        private Graphics graphics;
        private Rectangle planoVisible;
        private List<string> registroRecorte;
        private List<PointF> verticesVentana;

        public AlgoritmoWeilerAtherton(Graphics g, Rectangle plano)
        {
            graphics = g;
            planoVisible = plano;
            registroRecorte = new List<string>();

            // Definir vértices de la ventana de recorte
            verticesVentana = new List<PointF>
            {
                new PointF(plano.Left, plano.Top),
                new PointF(plano.Right, plano.Top),
                new PointF(plano.Right, plano.Bottom),
                new PointF(plano.Left, plano.Bottom)
            };
        }

        public void DibujarPlanoRecorte()
        {
            using (Pen penRojo = new Pen(Color.Red, 2))
            {
                graphics.DrawRectangle(penRojo, planoVisible);
            }
        }

        public List<List<PointF>> RecortarPoligono(List<Point> poligonoOriginal)
        {
            registroRecorte.Clear();
            List<List<PointF>> resultados = new List<List<PointF>>();

            if (poligonoOriginal == null || poligonoOriginal.Count < 3)
                return resultados;

            registroRecorte.Add("=== ALGORITMO WEILER-ATHERTON ===");
            registroRecorte.Add($"Polígono original: {poligonoOriginal.Count} vértices");
            registroRecorte.Add($"Ventana de recorte: ({planoVisible.Left}, {planoVisible.Top}) a ({planoVisible.Right}, {planoVisible.Bottom})");
            registroRecorte.Add("");

            // Convertir a PointF
            List<PointF> poligono = poligonoOriginal.Select(p => new PointF(p.X, p.Y)).ToList();

            // Encontrar intersecciones
            List<Vertice> listaPoligono = ConstruirListaVertices(poligono, true);
            List<Vertice> listaVentana = ConstruirListaVertices(verticesVentana, false);

            registroRecorte.Add($"Vértices del polígono procesados: {listaPoligono.Count}");
            registroRecorte.Add($"Intersecciones encontradas: {listaPoligono.Count(v => v.EsInterseccion)}");
            registroRecorte.Add("");

            // Construir polígonos resultantes siguiendo las intersecciones
            List<PointF> resultado = ConstruirPoligonoRecortado(listaPoligono);

            if (resultado.Count >= 3)
            {
                resultados.Add(resultado);
                registroRecorte.Add($"Polígono resultante: {resultado.Count} vértices");
            }
            else
            {
                registroRecorte.Add("No hay intersección válida o polígono completamente fuera");
            }

            return resultados;
        }

        private List<Vertice> ConstruirListaVertices(List<PointF> puntos, bool esPoligono)
        {
            List<Vertice> vertices = new List<Vertice>();

            for (int i = 0; i < puntos.Count; i++)
            {
                PointF p1 = puntos[i];
                PointF p2 = puntos[(i + 1) % puntos.Count];

                // Agregar vértice original
                Vertice v = new Vertice
                {
                    Punto = p1,
                    EsInterseccion = false,
                    EsEntrada = false,
                    Visitado = false
                };
                vertices.Add(v);

                // Buscar intersecciones con la ventana
                if (esPoligono)
                {
                    List<InterseccionInfo> intersecciones = EncontrarIntersecciones(p1, p2);

                    foreach (var inter in intersecciones.OrderBy(x => x.T))
                    {
                        bool dentroAntes = PuntoEnRectangulo(p1);
                        bool dentroDespues = PuntoEnRectangulo(p2);

                        Vertice vInter = new Vertice
                        {
                            Punto = inter.Punto,
                            EsInterseccion = true,
                            EsEntrada = !dentroAntes && dentroDespues,
                            Visitado = false,
                            T = inter.T
                        };
                        vertices.Add(vInter);

                        registroRecorte.Add($"Intersección en ({inter.Punto.X:F1}, {inter.Punto.Y:F1}) - " +
                                          $"{(vInter.EsEntrada ? "ENTRADA" : "SALIDA")}");
                    }
                }
            }

            return vertices;
        }

        private List<InterseccionInfo> EncontrarIntersecciones(PointF p1, PointF p2)
        {
            List<InterseccionInfo> intersecciones = new List<InterseccionInfo>();

            // Verificar intersección con cada lado de la ventana
            for (int i = 0; i < 4; i++)
            {
                PointF v1 = verticesVentana[i];
                PointF v2 = verticesVentana[(i + 1) % 4];

                PointF? interseccion = CalcularInterseccionLineas(p1, p2, v1, v2, out float t);

                if (interseccion.HasValue && t > 0.0001f && t < 0.9999f)
                {
                    intersecciones.Add(new InterseccionInfo
                    {
                        Punto = interseccion.Value,
                        T = t
                    });
                }
            }

            return intersecciones;
        }

        private PointF? CalcularInterseccionLineas(PointF p1, PointF p2, PointF p3, PointF p4, out float t)
        {
            t = 0;
            float x1 = p1.X, y1 = p1.Y;
            float x2 = p2.X, y2 = p2.Y;
            float x3 = p3.X, y3 = p3.Y;
            float x4 = p4.X, y4 = p4.Y;

            float den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

            if (Math.Abs(den) < 0.0001f)
                return null;

            float t1 = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / den;
            float t2 = -((x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3)) / den;

            if (t1 >= 0 && t1 <= 1 && t2 >= 0 && t2 <= 1)
            {
                t = t1;
                return new PointF(x1 + t1 * (x2 - x1), y1 + t1 * (y2 - y1));
            }

            return null;
        }

        private List<PointF> ConstruirPoligonoRecortado(List<Vertice> vertices)
        {
            List<PointF> resultado = new List<PointF>();

            // Buscar primera intersección de entrada no visitada
            Vertice inicio = vertices.FirstOrDefault(v => v.EsInterseccion && v.EsEntrada && !v.Visitado);

            if (inicio == null)
            {
                // Si no hay intersecciones, verificar si está completamente dentro
                bool todosDentro = vertices.Where(v => !v.EsInterseccion)
                                          .All(v => PuntoEnRectangulo(v.Punto));

                if (todosDentro)
                {
                    return vertices.Where(v => !v.EsInterseccion).Select(v => v.Punto).ToList();
                }
                return resultado;
            }

            Vertice actual = inicio;
            int maxIteraciones = vertices.Count * 2;
            int iteracion = 0;

            do
            {
                resultado.Add(actual.Punto);
                actual.Visitado = true;

                int indiceActual = vertices.IndexOf(actual);

                if (actual.EsInterseccion)
                {
                    // Cambiar entre polígono y ventana
                    actual = vertices[(indiceActual + 1) % vertices.Count];
                }
                else
                {
                    // Seguir por el polígono
                    actual = vertices[(indiceActual + 1) % vertices.Count];
                }

                iteracion++;
            }
            while (actual != inicio && iteracion < maxIteraciones);

            return resultado;
        }

        private bool PuntoEnRectangulo(PointF punto)
        {
            return punto.X >= planoVisible.Left && punto.X <= planoVisible.Right &&
                   punto.Y >= planoVisible.Top && punto.Y <= planoVisible.Bottom;
        }

        public void DibujarPoligonosRecortados(List<List<PointF>> poligonos, Color color)
        {
            foreach (var poligono in poligonos)
            {
                if (poligono.Count < 3)
                    continue;

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
        }

        public List<string> ObtenerRegistroRecorte()
        {
            return new List<string>(registroRecorte);
        }

        private class Vertice
        {
            public PointF Punto { get; set; }
            public bool EsInterseccion { get; set; }
            public bool EsEntrada { get; set; }
            public bool Visitado { get; set; }
            public float T { get; set; }
        }

        private class InterseccionInfo
        {
            public PointF Punto { get; set; }
            public float T { get; set; }
        }
    }
}
