using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmosU2
{
    internal class CCircunferencia
    {
        public List<PointF> CalcularPuntos(int xc, int yc, int r)
        {
            List<PointF> puntos = new List<PointF>();
            List<PointF> octante1 = new List<PointF>();

            int x = 0;
            int y = r;
            int p = 1 - r;

            while (x <= y)
            {
                octante1.Add(new PointF(x, y));

                x++;

                if (p < 0)
                {
                    p = p + 2 * x + 1;
                }
                else
                {
                    y--;
                    p = p + 2 * (x - y) + 1;
                }
            }
            foreach (PointF punto in octante1)
            {
                float x1 = punto.X;
                float y1 = punto.Y;
                puntos.Add(new PointF(xc + x1, yc + y1)); // Octante 1
                puntos.Add(new PointF(xc + y1, yc + x1)); // Octante 2
                puntos.Add(new PointF(xc + y1, yc - x1)); // Octante 3
                puntos.Add(new PointF(xc + x1, yc - y1)); // Octante 4
                puntos.Add(new PointF(xc - x1, yc - y1)); // Octante 5
                puntos.Add(new PointF(xc - y1, yc - x1)); // Octante 6
                puntos.Add(new PointF(xc - y1, yc + x1)); // Octante 7
                puntos.Add(new PointF(xc - x1, yc + y1)); // Octante 8
            }

            return puntos;
        }

        public void DibujarCircunferencia(Panel panel, int xc, int yc, int r)
        {
            List<PointF> puntos = CalcularPuntos(xc, yc, r);

            using (Graphics g = panel.CreateGraphics())
            {
                foreach (PointF p in puntos)
                {
                    g.FillRectangle(Brushes.Black, p.X, p.Y, 2, 2);
                }
            }
        }

        // -------------------
        // Algoritmo paramétrico
        // -------------------
        public List<PointF> CalcularPuntosParametrico(int xc, int yc, int r, double pasoGrados = 1.0)
        {
            List<PointF> puntos = new List<PointF>();
            if (pasoGrados <= 0) pasoGrados = 1.0;

            for (double ang = 0; ang < 360.0; ang += pasoGrados)
            {
                double rad = ang * Math.PI / 180.0;
                float x = (float)(xc + r * Math.Cos(rad));
                float y = (float)(yc + r * Math.Sin(rad));
                puntos.Add(new PointF(x, y));
            }

            return puntos;
        }

        public void DibujarCircunferenciaParametrico(Panel panel, int xc, int yc, int r, double pasoGrados = 1.0)
        {
            List<PointF> puntos = CalcularPuntosParametrico(xc, yc, r, pasoGrados);

            using (Graphics g = panel.CreateGraphics())
            {
                foreach (PointF p in puntos)
                {
                    g.FillRectangle(Brushes.Black, p.X, p.Y, 2, 2);
                }
            }
        }

        // -------------------
        // Algoritmo de Bresenham
        // -------------------
        public List<PointF> CalcularPuntosBresenham(int xc, int yc, int r)
        {
            List<PointF> puntos = new List<PointF>();

            int x = 0;
            int y = r;
            int d = 3 - 2 * r; // decisión inicial

            while (x <= y)
            {
                // añadir los 8 octantes
                puntos.Add(new PointF(xc + x, yc + y));
                puntos.Add(new PointF(xc + y, yc + x));
                puntos.Add(new PointF(xc + y, yc - x));
                puntos.Add(new PointF(xc + x, yc - y));
                puntos.Add(new PointF(xc - x, yc - y));
                puntos.Add(new PointF(xc - y, yc - x));
                puntos.Add(new PointF(xc - y, yc + x));
                puntos.Add(new PointF(xc - x, yc + y));

                if (d < 0)
                {
                    d = d + 4 * x + 6;
                }
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }

            return puntos;
        }

        public void DibujarCircunferenciaBresenham(Panel panel, int xc, int yc, int r)
        {
            List<PointF> puntos = CalcularPuntosBresenham(xc, yc, r);

            using (Graphics g = panel.CreateGraphics())
            {
                foreach (PointF p in puntos)
                {
                    g.FillRectangle(Brushes.Black, p.X, p.Y, 2, 2);
                }
            }
        }

        public List<List<PointF>> CalcularOctantesMidpoint(int xc, int yc, int r)
        {
            var octs = new List<List<PointF>>();
            for (int i = 0; i < 8; i++) octs.Add(new List<PointF>());

            List<PointF> octante1 = new List<PointF>();
            int x = 0;
            int y = r;
            int p = 1 - r;

            while (x <= y)
            {
                octante1.Add(new PointF(x, y));
                x++;
                if (p < 0)
                {
                    p = p + 2 * x + 1;
                }
                else
                {
                    y--;
                    p = p + 2 * (x - y) + 1;
                }
            }

            foreach (PointF punto in octante1)
            {
                float x1 = punto.X;
                float y1 = punto.Y;
                octs[0].Add(new PointF(xc + x1, yc + y1)); // Octante 1
                octs[1].Add(new PointF(xc + y1, yc + x1)); // Octante 2
                octs[2].Add(new PointF(xc + y1, yc - x1)); // Octante 3
                octs[3].Add(new PointF(xc + x1, yc - y1)); // Octante 4
                octs[4].Add(new PointF(xc - x1, yc - y1)); // Octante 5
                octs[5].Add(new PointF(xc - y1, yc - x1)); // Octante 6
                octs[6].Add(new PointF(xc - y1, yc + x1)); // Octante 7
                octs[7].Add(new PointF(xc - x1, yc + y1)); // Octante 8
            }

            return octs;
        }

        public List<List<PointF>> CalcularOctantesParametrico(int xc, int yc, int r, double pasoGrados = 1.0)
        {
            var octs = new List<List<PointF>>();
            for (int i = 0; i < 8; i++) octs.Add(new List<PointF>());
            if (pasoGrados <= 0) pasoGrados = 1.0;

            for (double ang = 0; ang < 360.0; ang += pasoGrados)
            {
                double rad = ang * Math.PI / 180.0;
                float x = (float)(xc + r * Math.Cos(rad));
                float y = (float)(yc + r * Math.Sin(rad));
                float dx = x - xc;
                float dy = y - yc;
                int oct = OctantIndex(dx, dy);
                octs[oct].Add(new PointF(x, y));
            }

            return octs;
        }

        public List<List<PointF>> CalcularOctantesBresenham(int xc, int yc, int r)
        {
            var octs = new List<List<PointF>>();
            for (int i = 0; i < 8; i++) octs.Add(new List<PointF>());

            int x = 0;
            int y = r;
            int d = 3 - 2 * r;

            while (x <= y)
            {
                octs[0].Add(new PointF(xc + x, yc + y));
                octs[1].Add(new PointF(xc + y, yc + x));
                octs[2].Add(new PointF(xc + y, yc - x));
                octs[3].Add(new PointF(xc + x, yc - y));
                octs[4].Add(new PointF(xc - x, yc - y));
                octs[5].Add(new PointF(xc - y, yc - x));
                octs[6].Add(new PointF(xc - y, yc + x));
                octs[7].Add(new PointF(xc - x, yc + y));

                if (d < 0)
                {
                    d = d + 4 * x + 6;
                }
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }

            return octs;
        }

        private int OctantIndex(float dx, float dy)
        {
            if (dx >= 0 && dy >= 0)
            {
                return (Math.Abs(dx) <= Math.Abs(dy)) ? 0 : 1;
            }
            if (dx >= 0 && dy <= 0)
            {
                return (Math.Abs(dx) >= Math.Abs(dy)) ? 2 : 3;
            }
            if (dx <= 0 && dy <= 0)
            {
                return (Math.Abs(dx) <= Math.Abs(dy)) ? 4 : 5;
            }
            // dx <=0 && dy >=0
            return (Math.Abs(dx) >= Math.Abs(dy)) ? 6 : 7;
        }
    }
}