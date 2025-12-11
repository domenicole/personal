using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosU2
{
    public class CScanline
    {
        private Bitmap bitmap;
        private TextBox txtCoords;
        private Panel panel;
        private Color colorRelleno;
        private int ancho;
        private int alto;

        public CScanline(Bitmap bmp, TextBox txt, Panel pnl)
        {
            bitmap = new Bitmap(bmp);
            txtCoords = txt;
            panel = pnl;
            colorRelleno = Color.Blue;

            ancho = bitmap.Width;
            alto = bitmap.Height;

            panel.Paint -= Panel_Paint;
            panel.Paint += Panel_Paint;
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0, panel.Width, panel.Height);
        }

        public async Task RellenarAsync(int xInicio, int yInicio)
        {
            if (!EsValido(xInicio, yInicio))
                return;

            int colorOriginal = bitmap.GetPixel(xInicio, yInicio).ToArgb();
            int colorRellenoArgb = colorRelleno.ToArgb();

            if (colorOriginal == colorRellenoArgb)
                return;

            Stack<Point> pila = new Stack<Point>();
            pila.Push(new Point(xInicio, yInicio));

            while (pila.Count > 0)
            {
                if (frmAlgRelleno.cancelado) return;

                Point p = pila.Pop();
                int x = p.X;
                int y = p.Y;

                if (!EsValido(x, y)) continue;

                // Buscar extremo izquierdo del segmento
                int izq = x;
                while (izq > 0 && bitmap.GetPixel(izq - 1, y).ToArgb() == colorOriginal)
                    izq--;

                // Buscar extremo derecho del segmento
                int der = x;
                while (der < ancho - 1 && bitmap.GetPixel(der + 1, y).ToArgb() == colorOriginal)
                    der++;

                // RELLENAR TODA LA LÍNEA
                for (int i = izq; i <= der; i++)
                {
                    if (frmAlgRelleno.cancelado) return;

                    bitmap.SetPixel(i, y, colorRelleno);
                }

                if (frmAlgRelleno.animacionActiva)
                {
                    panel.Invalidate();
                    Application.DoEvents();
                    await Task.Delay(8);
                }

                // Buscar segmentos en la línea superior
                if (y - 1 >= 0)
                    BuscarSegmentos(izq, der, y - 1, pila, colorOriginal);

                // Buscar segmentos en la línea inferior
                if (y + 1 < alto)
                    BuscarSegmentos(izq, der, y + 1, pila, colorOriginal);
            }

            // Refrescar al final si animación desactivada
            panel.Invalidate();
            Application.DoEvents();
        }

        private void BuscarSegmentos(int izq, int der, int y, Stack<Point> pila, int colorOriginal)
        {
            bool dentro = false;
            int xEntrada = 0;

            for (int x = izq; x <= der; x++)
            {
                int actual = bitmap.GetPixel(x, y).ToArgb();

                if (actual == colorOriginal)
                {
                    if (!dentro)
                    {
                        dentro = true;
                        xEntrada = x;
                    }
                }
                else if (dentro)
                {
                    pila.Push(new Point(xEntrada, y));
                    dentro = false;
                }
            }

            if (dentro)
                pila.Push(new Point(xEntrada, y));
        }

        private bool EsValido(int x, int y)
        {
            return x >= 0 && x < ancho && y >= 0 && y < alto;
        }

        public Bitmap ObtenerBitmap()
        {
            return bitmap;
        }
    }
}
