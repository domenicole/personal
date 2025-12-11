using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace AlgoritmosU2
{
    internal class CAlgoritmoDeRelleno
    {
        private Bitmap bitmap;
        private Color colorRelleno;
        private Color colorOriginal;
        private TextBox txtCoords;
        private Stack<Point> pila;
        private Panel panelDibujo;

        public CAlgoritmoDeRelleno(Bitmap bmp, TextBox coordsTextBox, Panel panel)
        {
            bitmap = bmp;
            txtCoords = coordsTextBox;
            panelDibujo = panel;
            pila = new Stack<Point>();
        }

        public void FloodFill(int x, int y)
        {
            // Verificar límites
            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                return;

            // Color rosa pastel
            colorRelleno = Color.FromArgb(255, 182, 193); // Rosa pastel (LightPink)
            colorOriginal = bitmap.GetPixel(x, y);

            // Si el color es el mismo, no hacer nada
            if (colorOriginal.ToArgb() == colorRelleno.ToArgb())
                return;

            txtCoords.Clear();
            txtCoords.AppendText("=== Inicio del Algoritmo FloodFill ===" + Environment.NewLine);
            txtCoords.AppendText($"Punto inicial: ({x}, {y})" + Environment.NewLine);
            txtCoords.AppendText($"Color original: {colorOriginal.Name}" + Environment.NewLine);
            txtCoords.AppendText($"Color de relleno: Rosa Pastel (R:255, G:182, B:193)" + Environment.NewLine);
            txtCoords.AppendText(Environment.NewLine + "Puntos pintados:" + Environment.NewLine);

            // Pintar el punto inicial
            bitmap.SetPixel(x, y, colorRelleno);
            pila.Push(new Point(x, y));

            int contador = 1;
            txtCoords.AppendText($"({x}, {y}) ");

            // Procesar la pila (LIFO - Last In First Out)
            while (pila.Count > 0)
            {
                Point puntoActual = pila.Peek(); // Ver el tope sin sacarlo
                bool encontroVecino = false;

                // Verificar vecinos en orden: Norte, Este, Sur, Oeste

                // Norte (arriba)
                Point norte = new Point(puntoActual.X, puntoActual.Y - 1);
                if (EsPixelValido(norte.X, norte.Y))
                {
                    bitmap.SetPixel(norte.X, norte.Y, colorRelleno);
                    pila.Push(norte);
                    encontroVecino = true;

                    contador++;
                    txtCoords.AppendText($"({norte.X}, {norte.Y}) ");
                    if (contador % 5 == 0)
                        txtCoords.AppendText(Environment.NewLine);

                    // Animación
                    if (contador % 10 == 0)
                    {
                        panelDibujo.Invalidate();
                        panelDibujo.Update();
                        Thread.Sleep(1);
                    }
                    continue; // Continuar con el nuevo punto
                }

                // Este (derecha)
                Point este = new Point(puntoActual.X + 1, puntoActual.Y);
                if (EsPixelValido(este.X, este.Y))
                {
                    bitmap.SetPixel(este.X, este.Y, colorRelleno);
                    pila.Push(este);
                    encontroVecino = true;

                    contador++;
                    txtCoords.AppendText($"({este.X}, {este.Y}) ");
                    if (contador % 5 == 0)
                        txtCoords.AppendText(Environment.NewLine);

                    // Animación
                    if (contador % 10 == 0)
                    {
                        panelDibujo.Invalidate();
                        panelDibujo.Update();
                        Thread.Sleep(1);
                    }
                    continue;
                }

                // Sur (abajo)
                Point sur = new Point(puntoActual.X, puntoActual.Y + 1);
                if (EsPixelValido(sur.X, sur.Y))
                {
                    bitmap.SetPixel(sur.X, sur.Y, colorRelleno);
                    pila.Push(sur);
                    encontroVecino = true;

                    contador++;
                    txtCoords.AppendText($"({sur.X}, {sur.Y}) ");
                    if (contador % 5 == 0)
                        txtCoords.AppendText(Environment.NewLine);

                    // Animación
                    if (contador % 10 == 0)
                    {
                        panelDibujo.Invalidate();
                        panelDibujo.Update();
                        Thread.Sleep(1);
                    }
                    continue;
                }

                // Oeste (izquierda)
                Point oeste = new Point(puntoActual.X - 1, puntoActual.Y);
                if (EsPixelValido(oeste.X, oeste.Y))
                {
                    bitmap.SetPixel(oeste.X, oeste.Y, colorRelleno);
                    pila.Push(oeste);
                    encontroVecino = true;

                    contador++;
                    txtCoords.AppendText($"({oeste.X}, {oeste.Y}) ");
                    if (contador % 5 == 0)
                        txtCoords.AppendText(Environment.NewLine);

                    // Animación
                    if (contador % 10 == 0)
                    {
                        panelDibujo.Invalidate();
                        panelDibujo.Update();
                        Thread.Sleep(1);
                    }
                    continue;
                }

                // Si no encontró ningún vecino libre, retroceder (sacar de la pila)
                if (!encontroVecino)
                {
                    pila.Pop();
                }
            }

            // Actualización final
            panelDibujo.Invalidate();
            panelDibujo.Update();

            txtCoords.AppendText(Environment.NewLine + Environment.NewLine);
            txtCoords.AppendText($"=== Fin del Algoritmo ===" + Environment.NewLine);
            txtCoords.AppendText($"Total de puntos pintados: {contador}" + Environment.NewLine);
        }

        private bool EsPixelValido(int x, int y)
        {
            // Verificar límites
            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                return false;

            // Verificar si el pixel tiene el color original
            Color color = bitmap.GetPixel(x, y);
            return color.ToArgb() == colorOriginal.ToArgb();
        }

        public Bitmap ObtenerBitmap()
        {
            return bitmap;
        }
    }
}