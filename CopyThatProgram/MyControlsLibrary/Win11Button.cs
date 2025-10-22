using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyControlsLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    [DefaultEvent("Click")]
    public class ModernButton : Control
    {
        private bool isHovered = false;
        private bool isPressed = false;
        private bool mouseDownInside = false;
        private float animationProgress = 0f;
        private Timer animationTimer;
        private float cornerRadius = 12f;

        public ModernButton()
        {
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            Size = new Size(120, 40);
            ForeColor = Color.White;
            BackColor = Color.FromArgb(50, 120, 220);

            animationTimer = new Timer { Interval = 16 };
            animationTimer.Tick += AnimationTimer_Tick;
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("The corner radius of the button.")]
        public float CornerRadius
        {
            get => cornerRadius;
            set { cornerRadius = value; Invalidate(); }
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (isPressed)
            {
                animationProgress = Math.Min(1f, animationProgress + 0.1f);
                Invalidate();
            }
            else
            {
                animationProgress = Math.Max(0f, animationProgress - 0.1f);
                Invalidate();
            }

            if (animationProgress <= 0f || animationProgress >= 1f)
                animationTimer.Stop();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHovered = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                mouseDownInside = true;
                animationTimer.Start();
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (mouseDownInside && ClientRectangle.Contains(e.Location))
            {
                OnClick(EventArgs.Empty);
            }
            isPressed = false;
            mouseDownInside = false;
            animationTimer.Start();
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = ClientRectangle;
            rect.Inflate(-1, -1);

            using (GraphicsPath path = RoundedRect(rect, cornerRadius))
            using (LinearGradientBrush bgBrush = new LinearGradientBrush(rect,
                ControlPaint.Light(BackColor, isHovered ? 0.4f : 0.1f),
                BackColor, LinearGradientMode.Vertical))
            {
                e.Graphics.FillPath(bgBrush, path);

                if (isHovered)
                {
                    using (var shine = new LinearGradientBrush(rect, Color.FromArgb(80, Color.White), Color.Transparent, LinearGradientMode.ForwardDiagonal))
                        e.Graphics.FillPath(shine, path);
                }

                // "Crumple" effect: squish down on press
                float scale = 1f - (0.05f * animationProgress);
                e.Graphics.TranslateTransform(Width / 2f, Height / 2f);
                e.Graphics.ScaleTransform(scale, scale);
                e.Graphics.TranslateTransform(-Width / 2f, -Height / 2f);

                TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            using (var pen = new Pen(Color.FromArgb(100, Color.Black), 1.2f))
            using (GraphicsPath path = RoundedRect(rect, cornerRadius))
                e.Graphics.DrawPath(pen, path);
        }

        private GraphicsPath RoundedRect(Rectangle rect, float radius)
        {
            float diameter = radius * 2f;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(rect.Location, sizeF);
            GraphicsPath path = new GraphicsPath();

            // Top left arc
            path.AddArc(arc, 180, 90);
            // Top right arc
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            // Bottom right arc
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // Bottom left arc
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}

