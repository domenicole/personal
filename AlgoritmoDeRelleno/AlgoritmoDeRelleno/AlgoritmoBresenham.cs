using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosU2
{
    internal class AlgoritmoBresenham
    {
        public List<PointF> GenerarPuntos(int x0, int y0, int xf, int yf)
        {
            List<PointF> puntos = new List<PointF>();

            int dx = Math.Abs(xf - x0);
            int dy = Math.Abs(yf - y0);

            // Determinar dirección del incremento
            int sx = x0 < xf ? 1 : -1;
            int sy = y0 < yf ? 1 : -1;

            int error = dx - dy;
            int x = x0;
            int y = y0;

            while (true)
            {
                puntos.Add(new PointF(x, y));

                // Si llegamos al punto final, terminar
                if (x == xf && y == yf)
                    break;

                int error2 = 2 * error;

                // Decidir si incrementar en X
                if (error2 > -dy)
                {
                    error -= dy;
                    x += sx;
                }

                // Decidir si incrementar en Y
                if (error2 < dx)
                {
                    error += dx;
                    y += sy;
                }
            }

            return puntos;
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