using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmosU2
{
    public partial class Circunferencia : Form
    {
        private static Circunferencia instancia;

        public static Circunferencia Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                    instancia = new Circunferencia();
                return instancia;
            }
        }

        // Buffer y animación
        private Bitmap buffer;
        private readonly object bufferLock = new object();
        private List<List<PointF>> animOctantes;
        private int animOctanteIndex;
        private Color animColor;

        public Circunferencia()
        {
            InitializeComponent();
            // timer1 ya creado en el diseñador; conectamos el evento
            timer1.Tick += Timer1_Tick;
            timer1.Interval = 300; // ms entre octantes (ajusta a tu gusto)
            EnsureBuffer();
        }

        private void EnsureBuffer()
        {
            if (panelDibujo.Width <= 0 || panelDibujo.Height <= 0) return;

            lock (bufferLock)
            {
                if (buffer == null || buffer.Width != panelDibujo.Width || buffer.Height != panelDibujo.Height)
                {
                    buffer?.Dispose();
                    buffer = new Bitmap(Math.Max(1, panelDibujo.Width), Math.Max(1, panelDibujo.Height));
                    using (Graphics g = Graphics.FromImage(buffer))
                    {
                        g.Clear(Color.White);
                    }
                    panelDibujo.BackgroundImage = buffer;
                    panelDibujo.BackgroundImageLayout = ImageLayout.None;
                }
            }
        }

        private void ClearBuffer()
        {
            StopAnimation();
            lock (bufferLock)
            {
                if (buffer == null)
                {
                    EnsureBuffer();
                }
                using (Graphics g = Graphics.FromImage(buffer))
                {
                    g.Clear(Color.White);
                }
            }
            panelDibujo.Invalidate();
        }

        private void StartAnimation(List<List<PointF>> octantes, Color color)
        {
            if (octantes == null) return;
            animOctantes = octantes;
            animOctanteIndex = 0;
            animColor = color;
            EnsureBuffer();
            // limpiar antes de empezar
            lock (bufferLock)
            {
                using (Graphics g = Graphics.FromImage(buffer))
                {
                    g.Clear(Color.White);
                }
            }
            panelDibujo.Invalidate();
            timer1.Start();
        }

        private void StopAnimation()
        {
            if (timer1.Enabled) timer1.Stop();
            animOctantes = null;
            animOctanteIndex = 0;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (animOctantes == null)
            {
                timer1.Stop();
                return;
            }

            if (animOctanteIndex >= animOctantes.Count)
            {
                StopAnimation();
                return;
            }

            var oct = animOctantes[animOctanteIndex];
            lock (bufferLock)
            {
                using (Graphics g = Graphics.FromImage(buffer))
                {
                    using (Brush b = new SolidBrush(animColor))
                    {
                        foreach (PointF p in oct)
                        {
                            int x = (int)Math.Round(p.X);
                            int y = (int)Math.Round(p.Y);
                            g.FillRectangle(b, x, y, 2, 2);
                        }
                    }
                }
            }
            panelDibujo.Invalidate();
            animOctanteIndex++;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            EnsureBuffer();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            int xc = panelDibujo.Width / 2;
            int yc = panelDibujo.Height / 2;
            int r = (int)radio.Value;

            CCircunferencia circ = new CCircunferencia();
            var octs = circ.CalcularOctantesMidpoint(xc, yc, r);
            StartAnimation(octs, Color.Black); // algoritmo original: negro
        }

        private void btnBressenham_Click(object sender, EventArgs e)
        {
            int xc = panelDibujo.Width / 2;
            int yc = panelDibujo.Height / 2;
            int r = (int)radio.Value;

            CCircunferencia circ = new CCircunferencia();
            var octs = circ.CalcularOctantesParametrico(xc, yc, r, 1.0);
            StartAnimation(octs, Color.Red); // paramétrico: rojo
        }

        private void btnParametrico_Click(object sender, EventArgs e)
        {
            int xc = panelDibujo.Width / 2;
            int yc = panelDibujo.Height / 2;
            int r = (int)radio.Value;

            CCircunferencia circ = new CCircunferencia();
            var octs = circ.CalcularOctantesBresenham(xc, yc, r);
            StartAnimation(octs, Color.Blue); // Bresenham: azul
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            timer1.Stop();
            buffer?.Dispose();
        }

        private void Circunferencia_Load(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.Location = new Point(
                    (this.MdiParent.ClientSize.Width - this.Width) / 2,
                    (this.MdiParent.ClientSize.Height - this.Height) / 2
                );
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            ClearBuffer();
        }
    }
}