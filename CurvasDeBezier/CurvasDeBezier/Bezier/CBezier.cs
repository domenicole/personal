using System;
using System.Collections.Generic;
using System.Drawing;

namespace CurvasDeBezier.Bezier
{
    internal class Bezier
    {
        private List<PointF> puntosControl;
        private int n; // grado de la curva

        public Bezier(List<PointF> puntos)
        {
            this.puntosControl = puntos;
            this.n = puntos.Count - 1;
        }

        public List<PointF> PuntosControl
        {
            get { return puntosControl; }
            set
            {
                puntosControl = value;
                n = value.Count - 1;
            }
        }

        // Calcula el coeficiente binomial (n sobre i)
        private long CoeficienteBinomial(int n, int i)
        {
            if (i > n) return 0;
            if (i == 0 || i == n) return 1;
            long resultado = 1;
            for (int k = 0; k < i; k++)
            {
                resultado = resultado * (n - k) / (k + 1);
            }
            return resultado;
        }

        // Función de Bernstein: B(i,n,t) = C(n,i) * (1-t)^(n-i) * t^i
        private double Bernstein(int i, int n, double t)
        {
            double coef = CoeficienteBinomial(n, i);
            double termino1 = Math.Pow(1 - t, n - i);
            double termino2 = Math.Pow(t, i);
            return coef * termino1 * termino2;
        }

        // Calcula un punto en la curva de Bézier para un valor t dado (0 <= t <= 1)
        public PointF CalcularPunto(double t)
        {
            if (puntosControl == null || puntosControl.Count == 0)
                return PointF.Empty;

            // Limitar t entre 0 y 1
            t = Math.Max(0, Math.Min(1, t));

            double x = 0;
            double y = 0;

            for (int i = 0; i <= n; i++)
            {
                double bernstein = Bernstein(i, n, t);
                x += bernstein * puntosControl[i].X;
                y += bernstein * puntosControl[i].Y;
            }

            return new PointF((float)x, (float)y);
        }

        // Genera una lista de puntos que forman la curva completa
        public List<PointF> GenerarCurva(int numPuntos = 100)
        {
            List<PointF> puntosCurva = new List<PointF>();

            for (int i = 0; i <= numPuntos; i++)
            {
                double t = (double)i / numPuntos;
                puntosCurva.Add(CalcularPunto(t));
            }

            return puntosCurva;
        }

        // Obtiene el tipo de curva según el número de puntos de control
        public string ObtenerTipoCurva()
        {
            int numPuntos = puntosControl.Count;
            switch (numPuntos)
            {
                case 2:
                    return "Lineal";
                case 3:
                    return "Cuadrática";
                case 4:
                    return "Cúbica";
                default:
                    return $"Grado {n}";
            }
        }

        // Algoritmo de De Casteljau mejorado para animación
        // Retorna todos los puntos intermedios organizados por nivel
        public DatosDeCasteljau AlgoritmoDeCasteljauCompleto(double t)
        {
            DatosDeCasteljau datos = new DatosDeCasteljau();

            // Limitar t entre 0 y 1
            t = Math.Max(0, Math.Min(1, t));

            // Iniciar con los puntos de control originales
            List<List<PointF>> niveles = new List<List<PointF>>();
            niveles.Add(new List<PointF>(puntosControl));

            List<PointF> puntosTrabajo = new List<PointF>(puntosControl);

            // Calcular cada nivel del algoritmo
            while (puntosTrabajo.Count > 1)
            {
                List<PointF> nuevosPuntos = new List<PointF>();

                for (int i = 0; i < puntosTrabajo.Count - 1; i++)
                {
                    float x = (float)((1 - t) * puntosTrabajo[i].X + t * puntosTrabajo[i + 1].X);
                    float y = (float)((1 - t) * puntosTrabajo[i].Y + t * puntosTrabajo[i + 1].Y);
                    PointF nuevoPunto = new PointF(x, y);
                    nuevosPuntos.Add(nuevoPunto);
                }

                niveles.Add(new List<PointF>(nuevosPuntos));
                puntosTrabajo = nuevosPuntos;
            }

            datos.Niveles = niveles;
            datos.PuntoFinal = puntosTrabajo.Count > 0 ? puntosTrabajo[0] : PointF.Empty;
            datos.ValorT = t;

            return datos;
        }

        // Versión simplificada para compatibilidad (retorna solo los puntos intermedios)
        public List<PointF> AlgoritmoDeCasteljau(double t)
        {
            List<PointF> todosLosPuntos = new List<PointF>();
            List<PointF> puntosTrabajo = new List<PointF>(puntosControl);

            t = Math.Max(0, Math.Min(1, t));

            while (puntosTrabajo.Count > 1)
            {
                List<PointF> nuevosPuntos = new List<PointF>();

                for (int i = 0; i < puntosTrabajo.Count - 1; i++)
                {
                    float x = (float)((1 - t) * puntosTrabajo[i].X + t * puntosTrabajo[i + 1].X);
                    float y = (float)((1 - t) * puntosTrabajo[i].Y + t * puntosTrabajo[i + 1].Y);
                    PointF nuevoPunto = new PointF(x, y);
                    nuevosPuntos.Add(nuevoPunto);
                    todosLosPuntos.Add(nuevoPunto);
                }

                puntosTrabajo = nuevosPuntos;
            }

            return todosLosPuntos;
        }
    }

    // Clase para almacenar los datos completos del algoritmo de De Casteljau
    internal class DatosDeCasteljau
    {
        public List<List<PointF>> Niveles { get; set; }
        public PointF PuntoFinal { get; set; }
        public double ValorT { get; set; }

        public DatosDeCasteljau()
        {
            Niveles = new List<List<PointF>>();
            PuntoFinal = PointF.Empty;
            ValorT = 0;
        }

        // Obtiene todas las líneas que conectan puntos entre niveles consecutivos
        public List<Tuple<PointF, PointF>> ObtenerLineasAuxiliares()
        {
            List<Tuple<PointF, PointF>> lineas = new List<Tuple<PointF, PointF>>();

            for (int nivel = 0; nivel < Niveles.Count - 1; nivel++)
            {
                for (int i = 0; i < Niveles[nivel].Count - 1; i++)
                {
                    if (i < Niveles[nivel + 1].Count)
                    {
                        lineas.Add(new Tuple<PointF, PointF>(Niveles[nivel][i], Niveles[nivel + 1][i]));
                        lineas.Add(new Tuple<PointF, PointF>(Niveles[nivel][i + 1], Niveles[nivel + 1][i]));
                    }
                }
            }

            return lineas;
        }

        // Obtiene todos los puntos intermedios (sin incluir los puntos de control originales)
        public List<PointF> ObtenerTodosPuntosIntermedios()
        {
            List<PointF> puntos = new List<PointF>();

            // Empezar desde el nivel 1 (saltar el nivel 0 que son los puntos de control)
            for (int i = 1; i < Niveles.Count; i++)
            {
                puntos.AddRange(Niveles[i]);
            }

            return puntos;
        }
    }
}