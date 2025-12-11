using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosU2
{
    public class CPatron
    {
        private Bitmap bitmap;
        private TextBox txtCoords;
        private Panel panel;
        private Color colorBorde;
        private int ancho;
        private int alto;
        private bool[,] patron;

        public CPatron(Bitmap bmp, TextBox txt, Panel pnl)
        {
            bitmap = new Bitmap(bmp);
            txtCoords = txt;
            panel = pnl;
            colorBorde = Color.Black;
            ancho = bitmap.Width;
            alto = bitmap.Height;

            // Vincular evento PAINT al panel (para dibujar el bitmap en tiempo real)
            panel.Paint += (s, e) =>
            {
                e.Graphics.DrawImage(bitmap, 0, 0, panel.Width, panel.Height);
            };

            // Definir patrón (8x8)
            patron = new bool[,]
            {
                { true, false, false, false, true, false, false, false },
                { false, true, false, false, false, true, false, false },
                { false, false, true, false, false, false, true, false },
                { false, false, false, true, false, false, false, true },
                { true, false, false, false, true, false, false, false },
                { false, true, false, false, false, true, false, false },
                { false, false, true, false, false, false, true, false },
                { false, false, false, true, false, false, false, true }
            };
        }

        public async Task RellenarAsync(int x, int y)
        {
            Color colorOriginal = bitmap.GetPixel(x, y);

            if (EsBorde(colorOriginal))
                return;

            Queue<Point> cola = new Queue<Point>();
            HashSet<Point> visitados = new HashSet<Point>();

            cola.Enqueue(new Point(x, y));
            visitados.Add(new Point(x, y));

            int contador = 0;

            while (cola.Count > 0)
            {
                if (frmAlgRelleno.cancelado) return;
                Point punto = cola.Dequeue();
                int px = punto.X;
                int py = punto.Y;

                // Rellenar según el patrón
                if (DebeRellenar(px, py))
                {
                    bitmap.SetPixel(px, py, ObtenerColorPatron(px, py));

                    ActualizarTexto(px, py);

                    // Animación
                    if (frmAlgRelleno.animacionActiva)
                    {
                        contador++;
                        if (contador % 3 == 0)
                        {
                            panel.Invalidate();
                            Application.DoEvents();
                            await Task.Delay(8);
                        }
                    }
                }

                // Vecinos 4-direcciones
                Point[] vecinos =
                {
                    new Point(px + 1, py),
                    new Point(px - 1, py),
                    new Point(px, py + 1),
                    new Point(px, py - 1)
                };

                foreach (Point vecino in vecinos)
                {
                    if (!EsValido(vecino.X, vecino.Y)) continue;
                    if (visitados.Contains(vecino)) continue;

                    Color colorVecino = bitmap.GetPixel(vecino.X, vecino.Y);

                    if (!EsBorde(colorVecino) && colorVecino.ToArgb() == colorOriginal.ToArgb())
                    {
                        cola.Enqueue(vecino);
                        visitados.Add(vecino);
                    }
                }
            }

            // Actualización final
            panel.Invalidate();
            Application.DoEvents();
        }

        private bool DebeRellenar(int x, int y)
        {
            int px = x % patron.GetLength(1);
            int py = y % patron.GetLength(0);
            return patron[py, px];
        }

        private Color ObtenerColorPatron(int x, int y)
        {
            int px = x % patron.GetLength(1);
            int py = y % patron.GetLength(0);

            return patron[py, px]
                ? Color.FromArgb(50, 100, 200)
                : Color.FromArgb(150, 180, 230);
        }

        private bool EsValido(int x, int y)
        {
            return x >= 0 && x < ancho && y >= 0 && y < alto;
        }

        private bool EsBorde(Color color)
        {
            return (color.R < 50 && color.G < 50 && color.B < 50);
        }

        private void ActualizarTexto(int x, int y)
        {
            if (txtCoords.InvokeRequired)
            {
                txtCoords.Invoke(new Action(() =>
                {
                    txtCoords.AppendText($"({x}, {y})\r\n");
                    txtCoords.ScrollToCaret();
                }));
            }
            else
            {
                txtCoords.AppendText($"({x}, {y})\r\n");
                txtCoords.ScrollToCaret();
            }
        }

        public Bitmap ObtenerBitmap()
        {
            return bitmap;
        }
    }
}
