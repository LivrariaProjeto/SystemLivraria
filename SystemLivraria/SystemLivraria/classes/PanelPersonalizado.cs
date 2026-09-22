using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemLivraria.classes
{
    public class PanelPersonalizado: Panel
    {
        //campos
        private int borderRadius = 30;
        private float gradientAngle = 90F;
        private Color gradientTopColor = Color.DodgerBlue;
        private Color gradientBottomColor = Color.CadetBlue;

        //contrutores
        public PanelPersonalizado() { 
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new Size(350,200);
        }

        //propriedades
        public int BorderRadius { 
            get => borderRadius;
            set { borderRadius = value; this.Invalidate(); }
        }
        public float GradientAngle { 
            get => gradientAngle;
            set { gradientAngle = value; this.Invalidate(); }
        }
        public Color GradientTopColor { 
            get => gradientTopColor;
            set { gradientTopColor = value; this.Invalidate(); }
        }
        public Color GradientBottomColor { 
            get => gradientBottomColor;
            set { gradientBottomColor = value; this.Invalidate(); }
        }

        //metodos
        private GraphicsPath getPnlPersonalizado(RectangleF rectangle, float radius) { 
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Height - radius, radius, radius, 0, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Height - radius, radius, radius, 90, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        //overridden methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //gradiente
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brushPnlPersonalizado = new LinearGradientBrush(this.ClientRectangle, this.gradientTopColor, this.gradientBottomColor, this.GradientAngle);
            Graphics graphicsPnlPersonalizado = e.Graphics;
            graphicsPnlPersonalizado.FillRectangle(brushPnlPersonalizado, ClientRectangle);

            //border radius
            RectangleF rectangleF = new RectangleF(0,0, this.Width, this.Height);
            if(borderRadius > 2)
            {
                using (GraphicsPath graphicsPath = getPnlPersonalizado(rectangleF, borderRadius))
                using (Pen pen = new Pen(this.Parent.BackColor, 2))
                {
                    this.Region = new Region(graphicsPath);
                    e.Graphics.DrawPath(pen, graphicsPath);
                }
            }
            else this.Region = new Region(rectangleF);
           

            

        }
    }
}
