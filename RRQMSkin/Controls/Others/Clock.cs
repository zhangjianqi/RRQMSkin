using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using RRQMSkin.Charts.Primitives;

namespace RRQMSkin.Controls
{
    /// <summary>
    /// 时钟
    /// </summary>
    public class Clock : RRQMControl
    {
        static Clock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Clock), new FrameworkPropertyMetadata(typeof(Clock)));
        }

        /// <summary>
        ///
        /// </summary>
      

        private Pointer secondPointer;
        private Pointer minutePointer;
        private Pointer hourPointer;
        /// <summary>
        ///
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            secondPointer = (Pointer)this.Template.FindName("secondPointer", this);
            minutePointer = (Pointer)this.Template.FindName("minutePointer", this);
            hourPointer = (Pointer)this.Template.FindName("hourPointer", this);
        }

        /// <summary>
        /// 显示时间
        /// </summary>
        [Category("RRQM"), Description("显示时间")]
        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        /// <summary>
        /// 显示时间属性
        /// </summary>
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(TimeSpan), typeof(Clock), new PropertyMetadata(new TimeSpan(0, 0, 0), OnTimeChanged));

        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Clock clock = (Clock)d;
            clock.InvalidateVisual();
        }

        private static void OnTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Clock clock = (Clock)d;
            if (clock.secondPointer != null && clock.minutePointer != null && clock.hourPointer != null)
            {
                clock.secondPointer.RatioAngle = -90 + clock.Time.Seconds * 6;
                clock.minutePointer.RatioAngle = -90 + clock.Time.Minutes * 6 + clock.Time.Seconds / 60.0 * 6;
                clock.hourPointer.RatioAngle = -90 + clock.Time.Hours * 30 + clock.Time.Minutes / 60.0 * 30;
            }
        }
    }
}