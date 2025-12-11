using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosU2
{
    internal class AlgoritmoPuntoMedio
    {
        public List<PointF> GenerarPuntos(int x0, int y0, int xf, int yf)
        {
            List<PointF> puntos = new List<PointF>();

            int dx = xf - x0;
            int dy = yf - y0;

            // Determinar el octante y ajustar
            bool steep = Math.Abs(dy) > Math.Abs(dx);

            if (steep)
            {
                // Intercambiar x e y
                Swap(ref x0, ref y0);
                Swap(ref xf, ref yf);
                Swap(ref dx, ref dy);
            }

            if (x0 > xf)
            {
                // Asegurar que dibujamos de izquierda a derecha
                Swap(ref x0, ref xf);
                Swap(ref y0, ref yf);
                dx = -dx;
                dy = -dy;
            }

            int x = x0;
            int y = y0;

            dx = Math.Abs(dx);
            dy = Math.Abs(dy);

            int incrE = 2 * dy;           // Incremento hacia el Este
            int incrNE = 2 * (dy - dx);   // Incremento hacia el Noreste
            int d = 2 * dy - dx;          // Decisión inicial

            int yStep = y0 < yf ? 1 : -1;

            // Generar puntos
            for (int i = 0; i <= dx; i++)
            {
                if (steep)
                {
                    puntos.Add(new PointF(y, x));
                }
                else
                {
                    puntos.Add(new PointF(x, y));
                }

                if (d <= 0)
                {
                    // Elegir E (Este)
                    d += incrE;
                }
                else
                {
                    // Elegir NE (Noreste)
                    d += incrNE;
                    y += yStep;
                }

                x++;
            }

            return puntos;
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public float CalcularPendiente(int x0, int y0, int xf, int yf)
        {
            if (xf - x0 == 0)
            {
                return float.PositiveInfinity;
            }
            return (float)(yf - y0) / (xf - x0);
        }

        public PointF CalcularCoordenadaK(int x0, int y0, int xf, int yf, int k)
        {
            var puntos = GenerarPuntos(x0, y0, xf, yf);
            if (k >= 0 && k < puntos.Count)
            {
                return puntos[k];
            }
            return new PointF(x0, y0);
        }
    }
}