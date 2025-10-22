using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace ModernProgress
{
    public partial class ModernCircularProgressBar : Control
    {
        #region --- public interface ----------------------------------------

        [Browsable(true)]
        [Category("Behavior")]
        public int Value
        {
            get => _target;
            set
            {
                if (value < _min) value = _min;
                if (value > _max) value = _max;
                _target = value;
                StartTimer();
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        public int Maximum
        {
            get => _max;
            set { _max = Math.Max(1, value); InvalidateNonChildren(); }
        }

        [Browsable(true)]
        [Category("Behavior")]
        public int Minimum
        {
            get => _min;
            set { _min = Math.Min(value, _max - 1); InvalidateNonChildren(); }
        }

        [Browsable(true)]
        [Category("Appearance")] public int LineWidth { get; set; } = 12;
        [Browsable(true)]
        [Category("Appearance")] public Color ProgressStartColor { get; set; } = Color.FromArgb(200, Color.MediumSlateBlue);
        [Browsable(true)]
        [Category("Appearance")] public Color ProgressEndColor { get; set; } = Color.FromArgb(200, Color.DeepSkyBlue);
        [Browsable(true)]
        [Category("Appearance")] public Color BackgroundRingColor { get; set; } = Color.FromArgb(80, 80, 80, 80);

        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(5)]
        public int UpdateInterval
        {
            get => _timer.Interval;
            set { _timer.Interval = Math.Max(1, value); }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool SmoothAnimation { get; set; } = true;

        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(3.0)]
        public double AnimationSpeed { get; set; } = 3.0;

        /// <summary>
        /// Fires every time the bar rolls over 100 % -> 0 %.
        /// </summary>
        public event EventHandler Looped;

        #endregion

        #region --- ctor / dispose ------------------------------------------

        public ModernCircularProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            Size = new Size(120, 120);

            _timer = new System.Windows.Forms.Timer { Interval = 5 };
            _timer.Tick += TimerTick;

            //Create Pens/ Brushes once; they are replaced only when a colour changes.
            RecreatePensBrushes();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _timer?.Stop();
                _timer?.Dispose();
                _backPen?.Dispose();
                _forePen?.Dispose();
                _textBrush?.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region --- painting ------------------------------------------------

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Visible || Width <= 0 || Height <= 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int lw = Math.Max(1, LineWidth);
            var rect = new RectangleF(lw / 2f, lw / 2f, Width - lw, Height - lw);

            // background ring
            g.DrawArc(_backPen, rect, -90, 360);

            // progress arc
            float percent = (_current / 100f - _min) / (_max - _min);
            percent = Math.Max(0f, Math.Min(1f, percent));
            float sweep = percent * 360f;
            if (sweep > 0.1f)
            {
                _forePen.Width = lw;
                g.DrawArc(_forePen, rect, -90, sweep);
            }

            // text
            string txt = $"{percent * 100:0.00}%";
            g.DrawString(txt, Font, _textBrush, ClientRectangle, _format);
        }

        #endregion

        #region --- animation -----------------------------------------------

        private void TimerTick(object sender, EventArgs e)
        {
            bool needPaint = false;

            if (!SmoothAnimation)
            {
                if (_current != _target * 100)
                {
                    _current = _target * 100;
                    needPaint = true;
                }
            }
            else
            {
                double diff = _target - _current / 100.0;
                if (Math.Abs(diff) < 0.01)
                {
                    _current = _target * 100;
                }
                else
                {
                    double step = diff * AnimationSpeed * 0.02;
                    step = Math.Max(Math.Abs(step), 0.02) * Math.Sign(diff);
                    _current += (int)Math.Round(step * 100);
                }

                // rollover 100 % -> 0 %
                if (_current >= _max * 100)
                {
                    _current = _min * 100;
                    Looped?.Invoke(this, EventArgs.Empty);
                }

                needPaint = true;
            }

            if (needPaint)
                InvalidateNonChildren();

            if (!SmoothAnimation || (_current == _target * 100))
                _timer.Stop();
        }

        #endregion

        #region --- private helpers -----------------------------------------

        private readonly System.Windows.Forms.Timer _timer;
        private readonly object _lock = new object();
        private readonly StringFormat _format = new StringFormat
        { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        private int _min = 0;
        private int _max = 10000;
        private int _target = 0;
        private int _current = 0;   // stored in hundredths

        private Pen _backPen;
        private Pen _forePen;
        private Brush _textBrush;

        private void RecreatePensBrushes()
        {
            _backPen?.Dispose();
            _forePen?.Dispose();
            _textBrush?.Dispose();

            _backPen = new Pen(BackgroundRingColor, LineWidth);
            _textBrush = new SolidBrush(ForeColor);
            ReplaceGradientPen(); // creates _forePen
        }

        private void ReplaceGradientPen()
        {
            _forePen?.Dispose();
            var rect = new RectangleF(0, 0, Width, Height);
            var brush = new LinearGradientBrush(rect, ProgressStartColor, ProgressEndColor, 45f);
            _forePen = new Pen(brush, LineWidth)
            { StartCap = LineCap.Round, EndCap = LineCap.Round };
        }

        private void StartTimer()
        {
            if (!_timer.Enabled)
                _timer.Start();
        }

        private void InvalidateNonChildren()
        {
            if (IsHandleCreated)
                BeginInvoke((MethodInvoker)(() => Invalidate(invalidateChildren: false)));
        }


        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            _textBrush?.Dispose();
            _textBrush = new SolidBrush(ForeColor);
            InvalidateNonChildren();
        }
        #endregion
    }
}
