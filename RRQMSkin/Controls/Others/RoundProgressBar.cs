using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using RRQMSkin.Charts.Primitives;

namespace RRQMSkin.Controls
{
    /// <summary>
    /// 环形进度条
    /// </summary>
    public class RoundProgressBar : RangeBase
    {
        static RoundProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RoundProgressBar), new FrameworkPropertyMetadata(typeof(RoundProgressBar)));
        }

        Sector sector;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            sector = (Sector)this.Template.FindName("sector", this);

        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);
            OnChanged();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="oldMaximum"></param>
        /// <param name="newMaximum"></param>
        protected override void OnMaximumChanged(double oldMaximum, double newMaximum)
        {
            base.OnMaximumChanged(oldMaximum, newMaximum);
            OnChanged();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="oldMinimum"></param>
        /// <param name="newMinimum"></param>
        protected override void OnMinimumChanged(double oldMinimum, double newMinimum)
        {
            base.OnMinimumChanged(oldMinimum, newMinimum);
            OnChanged();
        }

        private void OnChanged()
        {
            if (this.sector == null)
            {
                return;
            }
            double progress = this.Value / (this.Maximum - this.Minimum);
            this.sector.EndAngle = this.sector.StartAngle + progress * 360;
        }
    }
}