using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AlgoritmosU2
{
    internal class Dibujo
    {
        private readonly Panel panel;
        private readonly Timer timer;
        private List<PointF> puntos;
        private List<PointF> puntosOriginales;
        private int paso;

        // Variables para escalado
        private float escalaX;
        private float escalaY;
        private float offsetX;
        private float offsetY;
        private int margen = 40;

        // Rango de coordenadas originales
        private float minX, maxX, minY, maxY;

        public Dibujo(Panel panelObjetivo)
        {
            panel = panelObjetivo;
            timer = new Timer();
            timer.Interval = 50; // Velocidad de animación (milisegundos por punto)
            timer.Tick += Timer_Tick;
            panel.Paint += Panel_Paint;
        }

        // Método para ajustar la velocidad de animación
        public void SetVelocidadAnimacion(int milisegundos)
        {
            timer.Interval = milisegundos;
        }

        public void DibujarAnimado(List<PointF> listaDePuntos)
        {
            puntosOriginales = listaDePuntos;
            CalcularEscala(listaDePuntos);
            puntos = EscalarPuntos(listaDePuntos);
            paso = 0;
            panel.Refresh();
            timer.Start();
        }

        private void CalcularEscala(List<PointF> listaDePuntos)
        {
            if (listaDePuntos == null || listaDePuntos.Count == 0) return;

            // Encontrar los límites de las coordenadas originales
            minX = listaDePuntos.Min(p => p.X);
            maxX = listaDePuntos.Max(p => p.X);
            minY = listaDePuntos.Min(p => p.Y);
            maxY = listaDePuntos.Max(p => p.Y);

            // Agregar un pequeño margen a los límites si son iguales
            if (Math.Abs(maxX - minX) < 0.001f)
            {
                minX -= 1;
                maxX += 1;
            }
            if (Math.Abs(maxY - minY) < 0.001f)
            {
                minY -= 1;
                maxY += 1;
            }

            // Calcular el área disponible en el panel
            float areaDisponibleX = panel.Width - 2 * margen;
            float areaDisponibleY = panel.Height - 2 * margen;

            // Calcular escalas
            float rangoX = maxX - minX;
            float rangoY = maxY - minY;

            escalaX = areaDisponibleX / rangoX;
            escalaY = areaDisponibleY / rangoY;

            // Usar la misma escala para ambos ejes (mantener proporción)
            float escala = Math.Min(escalaX, escalaY);
            escalaX = escala;
            escalaY = escala;

            // Calcular offsets para centrar el dibujo
            offsetX = margen - minX * escalaX + (areaDisponibleX - rangoX * escalaX) / 2;
            offsetY = margen - minY * escalaY + (areaDisponibleY - rangoY * escalaY) / 2;
        }

        private List<PointF> EscalarPuntos(List<PointF> listaDePuntos)
        {
            List<PointF> puntosEscalados = new List<PointF>();
            foreach (PointF p in listaDePuntos)
            {
                float x = p.X * escalaX + offsetX;
                // Invertir Y para que crezca hacia arriba como en plano cartesiano
                float y = panel.Height - (p.Y * escalaY + offsetY);
                puntosEscalados.Add(new PointF(x, y));
            }
            return puntosEscalados;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (puntos == null || paso >= puntos.Count)
            {
                timer.Stop();
                return;
            }

            paso++;
            panel.Invalidate(); // Forzar repintado del panel completo
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            // Dibujar cuadrícula
            if (puntosOriginales != null && puntosOriginales.Count > 0)
            {
                DibujarCuadricula(e.Graphics);
            }

            // Dibujar puntos animados uno por uno
            if (puntos == null) return;

            // Dibujar líneas conectando los puntos ya dibujados
            if (paso > 1)
            {
                using (Pen penLinea = new Pen(Color.Blue, 2))
                {
                    for (int i = 0; i < paso - 1 && i < puntos.Count - 1; i++)
                    {
                        e.Graphics.DrawLine(penLinea, puntos[i], puntos[i + 1]);
                    }
                }
            }

            // Dibujar los puntos
            for (int i = 0; i < paso && i < puntos.Count; i++)
            {
                PointF p = puntos[i];

                // Punto actual (el último) más grande y de color diferente
                if (i == paso - 1)
                {
                    e.Graphics.FillEllipse(Brushes.Red, p.X - 3, p.Y - 3, 6, 6);
                }
                else
                {
                    e.Graphics.FillEllipse(Brushes.DarkRed, p.X - 2, p.Y - 2, 4, 4);
                }
            }
        }

        public void Limpiar()
        {
            try
            {
                // Parar animación si estaba corriendo
                if (timer != null && timer.Enabled)
                    timer.Stop();

                // Limpiar datos de puntos
                if (puntos != null) puntos.Clear();
                if (puntosOriginales != null) puntosOriginales.Clear();
                paso = 0;

                // Forzar repintado del panel (seguro en cualquier hilo)
                if (panel != null && !panel.IsDisposed)
                {
                    if (panel.InvokeRequired)
                    {
                        panel.Invoke((Action)(() => { panel.Invalidate(); panel.Refresh(); }));
                    }
                    else
                    {
                        panel.Invalidate();
                        panel.Refresh();
                    }
                }
            }
            catch
            {
            }
        }
        private void DibujarCuadricula(Graphics g)
        {
            Pen penCuadricula = new Pen(Color.LightGray, 1);
            Pen penEjes = new Pen(Color.Black, 2);
            Font fuente = new Font("Arial", 8);
            Brush brushTexto = Brushes.Black;

            // Calcular el intervalo de la cuadrícula
            float rangoX = maxX - minX;
            float rangoY = maxY - minY;

            int divisionesDeseadas = 10;
            float intervaloX = CalcularIntervaloRedondeado(rangoX / divisionesDeseadas);
            float intervaloY = CalcularIntervaloRedondeado(rangoY / divisionesDeseadas);

            // Dibujar líneas verticales
            float inicioX = (float)(Math.Floor(minX / intervaloX) * intervaloX);
            for (float x = inicioX; x <= maxX + intervaloX; x += intervaloX)
            {
                float xPantalla = x * escalaX + offsetX;

                if (xPantalla >= 0 && xPantalla <= panel.Width)
                {
                    // Línea vertical
                    g.DrawLine(penCuadricula, xPantalla, 0, xPantalla, panel.Height);

                    // Etiqueta
                    string etiqueta = x.ToString("F1");
                    SizeF tamTexto = g.MeasureString(etiqueta, fuente);
                    g.DrawString(etiqueta, fuente, brushTexto,
                        xPantalla - tamTexto.Width / 2, panel.Height - margen + 5);
                }
            }

            // Dibujar líneas horizontales
            float inicioY = (float)(Math.Floor(minY / intervaloY) * intervaloY);
            for (float y = inicioY; y <= maxY + intervaloY; y += intervaloY)
            {
                // Invertir Y para coordenadas cartesianas
                float yPantalla = panel.Height - (y * escalaY + offsetY);

                if (yPantalla >= 0 && yPantalla <= panel.Height)
                {
                    // Línea horizontal
                    g.DrawLine(penCuadricula, 0, yPantalla, panel.Width, yPantalla);

                    // Etiqueta
                    string etiqueta = y.ToString("F1");
                    g.DrawString(etiqueta, fuente, brushTexto, 5, yPantalla - 10);
                }
            }

            // Dibujar ejes principales si (0,0) está visible
            float origenX = 0 * escalaX + offsetX;
            float origenY = panel.Height - (0 * escalaY + offsetY);

            if (origenX >= 0 && origenX <= panel.Width)
            {
                g.DrawLine(penEjes, origenX, 0, origenX, panel.Height);
            }

            if (origenY >= 0 && origenY <= panel.Height)
            {
                g.DrawLine(penEjes, 0, origenY, panel.Width, origenY);
            }

            penCuadricula.Dispose();
            penEjes.Dispose();
            fuente.Dispose();
        }

        private float CalcularIntervaloRedondeado(float intervalo)
        {
            float magnitud = (float)Math.Pow(10, Math.Floor(Math.Log10(intervalo)));
            float residuo = intervalo / magnitud;

            if (residuo <= 1.5f) return magnitud;
            if (residuo <= 3.5f) return 2 * magnitud;
            if (residuo <= 7.5f) return 5 * magnitud;
            return 10 * magnitud;
        }


    }
}