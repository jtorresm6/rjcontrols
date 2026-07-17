using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace prueba
{
    public class RJToggleButton : CheckBox
    {
        // Campos privados para colores del Switch
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        // Propiedades de diseño expuestas en VS
        [Category("RJ Code Advance")]
        public Color OnBackColor
        {
            get => onBackColor;
            set { onBackColor = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color OnToggleColor
        {
            get => onToggleColor;
            set { onToggleColor = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color OffBackColor
        {
            get => offBackColor;
            set { offBackColor = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color OffToggleColor
        {
            get => offToggleColor;
            set { offToggleColor = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get => solidStyle;
            set { solidStyle = value; this.Invalidate(); }
        }

        // Ocultar el texto por defecto para que solo sea el Switch
        public override string Text
        {
            get => base.Text;
            set { }
        }

        public RJToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }

        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 1, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent?.BackColor ?? Color.White);

            if (this.Checked) // Estado: ON (Activado)
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                else
                    pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());

                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                    new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else // Estado: OFF (Desactivado)
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                else
                    pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());

                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                    new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}