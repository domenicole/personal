using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CurvasDeBezier.Bezier
{
    internal class Dibujo
    {
        private const float RADIO_PUNTO = 6f;
        private const float GROSOR_LINEA = 2f;
        private const float GROSOR_LINEA_CONTROL = 1f;

        private Pen lapizCurva;
        private Pen lapizLineasControl;
        private Brush pincelPuntos;
        private Brush pincelPuntoAnimacion;

        public Dibujo()
        {
            lapizCurva = new Pen(Color.Blue, GROSOR_LINEA);
            lapizCurva.LineJoin = LineJoin.Round;
            lapizLineasControl = new Pen(Color.Gray, GROSOR_LINEA_CONTROL);
            lapizLineasControl.DashStyle = DashStyle.Dash;
            pincelPuntos = new SolidBrush(Color.Red);
            pincelPuntoAnimacion = new SolidBrush(Color.Green);
        }

        // 1. Dibujar curva lineal (2 puntos)
        public void DibujarLineal(Graphics g, Bezier bezier, bool mostrarPuntosControl = true)
        {
            var puntos = bezier.PuntosControl;
            if (puntos.Count < 2) return;

            // Dibujar línea
            g.DrawLine(lapizCurva, puntos[0], puntos[1]);

            // Dibujar puntos de control
            if (mostrarPuntosControl)
            {
                DibujarPuntosControl(g, puntos);
            }
        }

        // 2. Dibujar curva cuadrática (3 puntos)
        public void DibujarCuadratica(Graphics g, Bezier bezier, bool mostrarPuntosControl = true)
        {
            var puntos = bezier.PuntosControl;
            if (puntos.Count < 3) return;

            // Dibujar líneas de control
            if (mostrarPuntosControl)
            {
                DibujarLineasControl(g, puntos);
            }

            // Dibujar curva
            var puntosCurva = bezier.GenerarCurva(100);
            DibujarCurvaCompleta(g, puntosCurva);

            // Dibujar puntos de control
            if (mostrarPuntosControl)
            {
                DibujarPuntosControl(g, puntos);
            }
        }

        // 3. Dibujar curva cúbica (4 puntos)
        public void DibujarCubica(Graphics g, Bezier bezier, bool mostrarPuntosControl = true)
        {
            var puntos = bezier.PuntosControl;
            if (puntos.Count < 4) return;

            // Dibujar líneas de control
            if (mostrarPuntosControl)
            {
                DibujarLineasControl(g, puntos);
            }

            // Dibujar curva
            var puntosCurva = bezier.GenerarCurva(150);
            DibujarCurvaCompleta(g, puntosCurva);

            // Dibujar puntos de control
            if (mostrarPuntosControl)
            {
                DibujarPuntosControl(g, puntos);
            }
        }

        // 4. Dibujar curva de grado superior (más de 4 puntos)
        public void DibujarGradoSuperior(Graphics g, Bezier bezier, bool mostrarPuntosControl = true)
        {
            var puntos = bezier.PuntosControl;
            if (puntos.Count < 2) return;

            // Dibujar líneas de control
            if (mostrarPuntosControl)
            {
                DibujarLineasControl(g, puntos);
            }

            // Dibujar curva con más puntos para mayor suavidad
            var puntosCurva = bezier.GenerarCurva(200);
            DibujarCurvaCompleta(g, puntosCurva);

            // Dibujar puntos de control
            if (mostrarPuntosControl)
            {
                DibujarPuntosControl(g, puntos);
            }
        }

        // Dibuja la curva completa
        private void DibujarCurvaCompleta(Graphics g, List<PointF> puntosCurva)
        {
            if (puntosCurva.Count < 2) return;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 0; i < puntosCurva.Count - 1; i++)
            {
                g.DrawLine(lapizCurva, puntosCurva[i], puntosCurva[i + 1]);
            }
        }

        // Dibuja las líneas que conectan los puntos de control
        private void DibujarLineasControl(Graphics g, List<PointF> puntos)
        {
            for (int i = 0; i < puntos.Count - 1; i++)
            {
                g.DrawLine(lapizLineasControl, puntos[i], puntos[i + 1]);
            }
        }

        // Dibuja los puntos de control
        private void DibujarPuntosControl(Graphics g, List<PointF> puntos)
        {
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
        }

        // Dibuja el punto de animación en la curva
        public void DibujarPuntoAnimacion(Graphics g, PointF punto)
        {
            float radio = RADIO_PUNTO + 2;
            g.FillEllipse(pincelPuntoAnimacion,
                punto.X - radio,
                punto.Y - radio,
                radio * 2,
                radio * 2);

            g.DrawEllipse(new Pen(Color.DarkGreen, 2),
                punto.X - radio,
                punto.Y - radio,
                radio * 2,
                radio * 2);
        }

        // Dibuja los puntos intermedios del algoritmo de De Casteljau
        public void DibujarAlgoritmoDeCasteljau(Graphics g, List<PointF> puntosIntermedios)
        {
            Pen lapizIntermedio = new Pen(Color.Orange, 1f);
            lapizIntermedio.DashStyle = DashStyle.Dot;

            Brush pincelIntermedio = new SolidBrush(Color.Orange);
            float radioIntermedio = 3f;

            foreach (var punto in puntosIntermedios)
            {
                g.FillEllipse(pincelIntermedio,
                    punto.X - radioIntermedio,
                    punto.Y - radioIntermedio,
                    radioIntermedio * 2,
                    radioIntermedio * 2);
            }
        }

        // Genera puntos de control en diagonal (para lineal, cuadrática y cúbica por defecto)
        public static List<PointF> GenerarPuntosDiagonal(int numPuntos, int ancho, int alto)
        {
            List<PointF> puntos = new List<PointF>();

            float margen = 50;
            float espacioX = (ancho - 2 * margen) / (numPuntos - 1);
            float espacioY = (alto - 2 * margen) / (numPuntos - 1);

            for (int i = 0; i < numPuntos; i++)
            {
                float x = margen + i * espacioX;
                float y = margen + i * espacioY;
                puntos.Add(new PointF(x, y));
            }

            return puntos;
        }

        // Genera puntos de control aleatorios (para grado superior)
        public static List<PointF> GenerarPuntosAleatorios(int numPuntos, int ancho, int alto)
        {
            List<PointF> puntos = new List<PointF>();
            Random rand = new Random();

            float margen = 50;

            for (int i = 0; i < numPuntos; i++)
            {
                float x = margen + (float)rand.NextDouble() * (ancho - 2 * margen);
                float y = margen + (float)rand.NextDouble() * (alto - 2 * margen);
                puntos.Add(new PointF(x, y));
            }

            return puntos;
        }

        // Verifica si un punto del mouse está cerca de un punto de control
        public static int ObtenerIndicePuntoCercano(Point mouse, List<PointF> puntos, float tolerancia = 10f)
        {
            for (int i = 0; i < puntos.Count; i++)
            {
                float dx = mouse.X - puntos[i].X;
                float dy = mouse.Y - puntos[i].Y;
                float distancia = (float)Math.Sqrt(dx * dx + dy * dy);

                if (distancia <= tolerancia)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Dispose()
        {
            lapizCurva?.Dispose();
            lapizLineasControl?.Dispose();
            pincelPuntos?.Dispose();
            pincelPuntoAnimacion?.Dispose();
        }
    }
}