using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Resolvers;

namespace AlgoritmosU2
{
    internal class AlgoritmoDDA
    {
        float pendiente;

        public float CalcularPendiente(int x0, int y0, int xf, int yf)
        {
            if (xf - x0 == 0)
            {
                pendiente = float.PositiveInfinity;
            }
            else
            {
                pendiente = (float)(yf - y0) / (xf - x0);
            }

            return pendiente;
        }

        public float CalcularIncremento(int x0, int y0, int xf, int yf)
        {
            CalcularPendiente(x0, y0, xf, yf);

            float dx = xf - x0;
            float dy = yf - y0;

            float pasos = Math.Max(Math.Abs(dx), Math.Abs(dy));

            if (pasos == 0)
                return 0;

            return pasos;
        }

        public PointF CalcularCoordenadaK(int x0, int y0, int xf, int yf, int k)
        {
            float dx = xf - x0;
            float dy = yf - y0;

            float pasos = Math.Max(Math.Abs(dx), Math.Abs(dy));

            if (pasos == 0)
                return new PointF(x0, y0);

            float xInc = dx / pasos;
            float yInc = dy / pasos;

            float xk = x0 + k * xInc;
            float yk = y0 + k * yInc;

            return new PointF(xk, yk);
        }

        public List<PointF> GenerarPuntos(int x0, int y0, int xf, int yf)
        {
            List<PointF> puntos = new List<PointF>();

            float dx = xf - x0;
            float dy = yf - y0;
            float pasos = Math.Max(Math.Abs(dx), Math.Abs(dy));

            if (pasos == 0)
            {
                puntos.Add(new PointF(x0, y0));
                return puntos;
            }

            float xInc = dx / pasos;
            float yInc = dy / pasos;

            float x = x0;
            float y = y0;

            for (int k = 0; k <= pasos; k++)
            {
                puntos.Add(new PointF(x, y));
                x += xInc;
                y += yInc;
            }

            return puntos;
        }
    }
}
