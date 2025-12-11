using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosU2
{
    internal class AlgoritmoSutherlandHodgman
    {
        private Graphics graphics;
        private Rectangle planoVisible;
        private List<string> registroRecorte;

        public AlgoritmoSutherlandHodgman(Graphics g, Rectangle plano)
        {
            graphics = g;
            planoVisible = plano;
            registroRecorte = new List<string>();
        }

        // Dibuja el plano de recorte en rojo
        public void DibujarPlanoRecorte()
        {
            using (Pen penRojo = new Pen(Color.Red, 2))
            {
                graphics.DrawRectangle(penRojo, planoVisible);
            }
        }

        // Realiza el recorte del polígono usando Sutherland-Hodgman
        public List<PointF> RecortarPoligono(List<Point> poligonoOriginal)
        {
            registroRecorte.Clear();

            if (poligonoOriginal == null || poligonoOriginal.Count < 3)
                return new List<PointF>();

            // Convertir a PointF para precisión en las intersecciones
            List<PointF> poligono = poligonoOriginal.Select(p => new PointF(p.X, p.Y)).ToList();

            registroRecorte.Add("=== INICIO DEL RECORTE ===");
            registroRecorte.Add($"Polígono original: {poligono.Count} vértices");
            registroRecorte.Add($"Plano visible: ({planoVisible.Left}, {planoVisible.Top}) a ({planoVisible.Right}, {planoVisible.Bottom})");
            registroRecorte.Add("");

            // Definir los 4 bordes del plano de recorte
            // Orden: Izquierdo, Derecho, Superior, Inferior
            List<Borde> bordes = new List<Borde>
            {
                new Borde(planoVisible.Left, TipoBorde.Izquierdo),
                new Borde(planoVisible.Right, TipoBorde.Derecho),
                new Borde(planoVisible.Top, TipoBorde.Superior),
                new Borde(planoVisible.Bottom, TipoBorde.Inferior)
            };

            // Aplicar recorte para cada borde
            foreach (var borde in bordes)
            {
                poligono = RecortarContraBorde(poligono, borde);
                registroRecorte.Add($"Después de recortar contra borde {borde.Tipo}: {poligono.Count} vértices");

                if (poligono.Count == 0)
                {
                    registroRecorte.Add("Polígono completamente fuera del plano visible");
                    break;
                }
            }

            registroRecorte.Add("");
            registroRecorte.Add("=== RESULTADO FINAL ===");
            registroRecorte.Add($"Vértices conservados/generados: {poligono.Count}");

            return poligono;
        }

        // Recorta el polígono contra un borde específico
        private List<PointF> RecortarContraBorde(List<PointF> poligono, Borde borde)
        {
            if (poligono.Count == 0)
                return poligono;

            List<PointF> salida = new List<PointF>();

            for (int i = 0; i < poligono.Count; i++)
            {
                PointF puntoActual = poligono[i];
                PointF puntoSiguiente = poligono[(i + 1) % poligono.Count];

                bool actualDentro = EstaDentro(puntoActual, borde);
                bool siguienteDentro = EstaDentro(puntoSiguiente, borde);

                if (actualDentro && siguienteDentro)
                {
                    // Ambos dentro: agregar el siguiente punto
                    salida.Add(puntoSiguiente);
                }
                else if (actualDentro && !siguienteDentro)
                {
                    // Sale del plano: agregar intersección
                    PointF interseccion = CalcularInterseccion(puntoActual, puntoSiguiente, borde);
                    salida.Add(interseccion);

                    registroRecorte.Add($"  Punto modificado (sale): ({puntoSiguiente.X:F1}, {puntoSiguiente.Y:F1}) " +
                                      $"→ ({interseccion.X:F1}, {interseccion.Y:F1})");
                }
                else if (!actualDentro && siguienteDentro)
                {
                    // Entra al plano: agregar intersección y el siguiente punto
                    PointF interseccion = CalcularInterseccion(puntoActual, puntoSiguiente, borde);
                    salida.Add(interseccion);
                    salida.Add(puntoSiguiente);

                    registroRecorte.Add($"  Punto modificado (entra): ({puntoActual.X:F1}, {puntoActual.Y:F1}) " +
                                      $"→ ({interseccion.X:F1}, {interseccion.Y:F1})");
                    registroRecorte.Add($"  Punto conservado: ({puntoSiguiente.X:F1}, {puntoSiguiente.Y:F1})");
                }
            }

            return salida;
        }

        private bool EstaDentro(PointF punto, Borde borde)
        {
            switch (borde.Tipo)
            {
                case TipoBorde.Izquierdo:
                    return punto.X >= borde.Valor;
                case TipoBorde.Derecho:
                    return punto.X <= borde.Valor;
                case TipoBorde.Superior:
                    return punto.Y >= borde.Valor;
                case TipoBorde.Inferior:
                    return punto.Y <= borde.Valor;
                default:
                    return false;
            }
        }

        private PointF CalcularInterseccion(PointF p1, PointF p2, Borde borde)
        {
            float x = 0, y = 0;

            switch (borde.Tipo)
            {
                case TipoBorde.Izquierdo:
                case TipoBorde.Derecho:
                    x = borde.Valor;
                    if (Math.Abs(p2.X - p1.X) > 0.0001f)
                    {
                        float t = (x - p1.X) / (p2.X - p1.X);
                        y = p1.Y + t * (p2.Y - p1.Y);
                    }
                    else
                    {
                        y = p1.Y;
                    }
                    break;

                case TipoBorde.Superior:
                case TipoBorde.Inferior:
                    y = borde.Valor;
                    if (Math.Abs(p2.Y - p1.Y) > 0.0001f)
                    {
                        float t = (y - p1.Y) / (p2.Y - p1.Y);
                        x = p1.X + t * (p2.X - p1.X);
                    }
                    else
                    {
                        x = p1.Y;
                    }
                    break;
            }

            return new PointF(x, y);
        }

        public void DibujarPoligonoRecortado(List<PointF> poligono, Color color)
        {
            if (poligono == null || poligono.Count < 3)
                return;

            using (Pen pen = new Pen(color, 2))
            using (Brush brush = new SolidBrush(Color.FromArgb(100, color)))
            {
                // Dibujar relleno semi-transparente
                graphics.FillPolygon(brush, poligono.ToArray());

                // Dibujar contorno
                graphics.DrawPolygon(pen, poligono.ToArray());

                // Dibujar vértices
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

        private class Borde
        {
            public float Valor { get; set; }
            public TipoBorde Tipo { get; set; }

            public Borde(float valor, TipoBorde tipo)
            {
                Valor = valor;
                Tipo = tipo;
            }
        }

        private enum TipoBorde
        {
            Izquierdo,
            Derecho,
            Superior,
            Inferior
        }
    }
}
