using System;
using System.Collections.Generic;
using System.Drawing;

namespace CurvasDeBezier
{
    internal class CBSpline
    {
        private List<PointF> puntosControl;
        private int grado; // 2 = cuadrática, 3 = cúbica
        private bool esCerrada;
        private List<double> vectorNodal;

        public CBSpline(List<PointF> puntos, int grado, bool cerrada)
        {
            this.puntosControl = puntos;
            this.grado = grado;
            this.esCerrada = cerrada;
            GenerarVectorNodal();
        }

        public List<PointF> PuntosControl
        {
            get { return puntosControl; }
            set
            {
                puntosControl = value;
                GenerarVectorNodal();
            }
        }

        public int Grado => grado;
        public bool EsCerrada => esCerrada;

        // Genera el vector nodal uniforme
        private void GenerarVectorNodal()
        {
            vectorNodal = new List<double>();
            int n = puntosControl.Count;
            int m = n + grado + 1;

            if (esCerrada)
            {
                // Vector nodal uniforme para curvas cerradas
                for (int i = 0; i < m; i++)
                {
                    vectorNodal.Add(i);
                }
            }
            else
            {
                // Vector nodal con nodos múltiples en los extremos (curva abierta)
                for (int i = 0; i <= grado; i++)
                {
                    vectorNodal.Add(0);
                }
                for (int i = 1; i < n - grado; i++)
                {
                    vectorNodal.Add(i);
                }
                for (int i = 0; i <= grado; i++)
                {
                    vectorNodal.Add(n - grado);
                }
            }
        }

        // Función base B-spline usando algoritmo de Cox-de Boor
        private double FuncionBase(int i, int p, double t)
        {
            if (p == 0)
            {
                return (t >= vectorNodal[i] && t < vectorNodal[i + 1]) ? 1.0 : 0.0;
            }

            double c1 = 0, c2 = 0;

            if (vectorNodal[i + p] - vectorNodal[i] != 0)
            {
                c1 = ((t - vectorNodal[i]) / (vectorNodal[i + p] - vectorNodal[i])) *
                     FuncionBase(i, p - 1, t);
            }

            if (vectorNodal[i + p + 1] - vectorNodal[i + 1] != 0)
            {
                c2 = ((vectorNodal[i + p + 1] - t) / (vectorNodal[i + p + 1] - vectorNodal[i + 1])) *
                     FuncionBase(i + 1, p - 1, t);
            }

            return c1 + c2;
        }

        // Calcula un punto en la curva B-Spline
        public PointF CalcularPunto(double t)
        {
            if (puntosControl == null || puntosControl.Count < grado + 1)
                return PointF.Empty;

            int n = puntosControl.Count;
            double tMin = vectorNodal[grado];
            double tMax = vectorNodal[n];

            // Mapear t de [0,1] al rango del vector nodal
            double u = tMin + t * (tMax - tMin);

            // Asegurar que u esté en el rango válido
            u = Math.Max(tMin, Math.Min(tMax - 0.0001, u));

            double x = 0, y = 0;

            for (int i = 0; i < n; i++)
            {
                double basis = FuncionBase(i, grado, u);
                x += basis * puntosControl[i].X;
                y += basis * puntosControl[i].Y;
            }

            return new PointF((float)x, (float)y);
        }

        // Genera la curva completa
        public List<PointF> GenerarCurva(int numPuntos = 200)
        {
            List<PointF> curva = new List<PointF>();

            for (int i = 0; i <= numPuntos; i++)
            {
                double t = (double)i / numPuntos;
                curva.Add(CalcularPunto(t));
            }

            return curva;
        }

        // Calcula puntos intermedios para animación
        public DatosAnimacionBSpline CalcularDatosAnimacion(double t)
        {
            DatosAnimacionBSpline datos = new DatosAnimacionBSpline();
            datos.PuntoActual = CalcularPunto(t);
            datos.ValorT = t;
            datos.PuntosControl = new List<PointF>(puntosControl);

            return datos;
        }

        public string ObtenerTipoCurva()
        {
            string tipo = grado == 2 ? "Cuadrática" : "Cúbica";
            string estado = esCerrada ? "Cerrada" : "Abierta";
            return $"B-Spline {tipo} {estado}";
        }
    }

    // Clase para datos de animación
    internal class DatosAnimacionBSpline
    {
        public PointF PuntoActual { get; set; }
        public double ValorT { get; set; }
        public List<PointF> PuntosControl { get; set; }

        public DatosAnimacionBSpline()
        {
            PuntosControl = new List<PointF>();
        }
    }
}