using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AlgoritmosU2
{
    internal class DibujoRelleno
    {
        private Graphics graphics;
        private Pen lapiz;

        public DibujoRelleno(Graphics g)
        {
            graphics = g;
            lapiz = new Pen(Color.Black, 2);
        }

        // Dibuja un cuadrado centrado en el punto especificado
        public void DibujarCuadrado(int x, int y, int tamaño)
        {
            int mitad = tamaño / 2;
            Rectangle rect = new Rectangle(x - mitad, y - mitad, tamaño, tamaño);
            graphics.DrawRectangle(lapiz, rect);
        }

        // Dibuja un círculo centrado en el punto especificado
        public void DibujarCirculo(int x, int y, int radio)
        {
            Rectangle rect = new Rectangle(x - radio, y - radio, radio * 2, radio * 2);
            graphics.DrawEllipse(lapiz, rect);
        }

        // Dibuja una polilínea conectando los puntos y cierra la figura
        public void DibujarPoligonoLibre(List<Point> puntos)
        {
            if (puntos.Count < 2)
                return;

            // Dibujar líneas entre los puntos
            for (int i = 0; i < puntos.Count - 1; i++)
            {
                graphics.DrawLine(lapiz, puntos[i], puntos[i + 1]);
            }

            // Cerrar la figura conectando el último punto con el primero
            if (puntos.Count >= 3)
            {
                graphics.DrawLine(lapiz, puntos[puntos.Count - 1], puntos[0]);
            }
        }
        public void DibujarLineas(List<Point> puntos)
        {
            // Verificar que haya al menos 2 puntos
            if (puntos.Count < 2)
                return;

            int numeroLineas = puntos.Count / 2;

            for (int i = 0; i < numeroLineas; i++)
            {
                Point puntoInicio = puntos[i * 2];
                Point puntoFin = puntos[i * 2 + 1];
                graphics.DrawLine(lapiz, puntoInicio, puntoFin);
            }

        }

        // Dibuja un punto de guía para el dibujo libre
        public void DibujarPuntoGuia(int x, int y)
        {
            Brush brush = new SolidBrush(Color.Red);
            graphics.FillEllipse(brush, x - 3, y - 3, 6, 6);
            brush.Dispose();
        }

        // Limpia toda la superficie de dibujo
        public void Limpiar(Color colorFondo)
        {
            graphics.Clear(colorFondo);
        }

        public void CambiarColorLapiz(Color color)
        {
            lapiz.Color = color;
        }

        public void CambiarGrosorLapiz(float grosor)
        {
            lapiz.Width = grosor;
        }
    }
}