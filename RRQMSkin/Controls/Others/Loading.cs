﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using RRQMSkin.Charts.Primitives;

namespace RRQMSkin.Controls
{
    /// <summary>
    /// 正在加载
    /// </summary>
    public class Loading : RRQMControl
    {
        static Loading()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Loading), new FrameworkPropertyMetadata(typeof(Loading)));
        }

        private Sector sector;

        /// <summary>
        ///
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.sector = (Sector)this.Template.FindName("sector", this);
        }



        /// <summary>
        /// 前景色
        /// </summary>
        public new Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        /// <summary>
        /// 前景色属性
        /// </summary>
        public static new readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Brush), typeof(Loading), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3CD5DB"))));

        /// <summary>
        /// 周期时间
        /// </summary>
        public TimeSpan Duration
        {
            get { return (TimeSpan)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        /// <summary>
        /// 周期时间属性
        /// </summary>
        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(TimeSpan), typeof(Loading), new PropertyMetadata(TimeSpan.FromSeconds(1), OnChanged));

        /// <summary>
        /// 弧长比例
        /// </summary>
        public double ArcLength
        {
            get { return (double)GetValue(ArcLengthProperty); }
            set { SetValue(ArcLengthProperty, value); }
        }

        /// <summary>
        /// 弧长比例属性
        /// </summary>
        public static readonly DependencyProperty ArcLengthProperty =
            DependencyProperty.Register("ArcLength", typeof(double), typeof(Loading), new PropertyMetadata(0.3, OnChanged));

        /// <summary>
        /// 结束角
        /// </summary>
        public double EndAngle
        {
            get { return (double)GetValue(EndAngleProperty); }
            private set { SetValue(EndAngleProperty, value); }
        }

        /// <summary>
        /// 结束角属性
        /// </summary>
        public static readonly DependencyProperty EndAngleProperty =
            DependencyProperty.Register("EndAngle", typeof(double), typeof(Loading), new PropertyMetadata(120.0));

        /// <summary>
        /// 正在加载
        /// </summary>
        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        /// <summary>
        /// 正在加载属性
        /// </summary>
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(Loading), new PropertyMetadata(false, OnLoadChanged));

        private static void OnLoadChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Loading loading = (Loading)d;
            if (!loading.IsInDesignMode)
            {
                loading.OnApplyTemplate();
                if (loading.sector != null)
                {
                    if (loading.IsLoading)
                    {
                        DoubleAnimation animation = new DoubleAnimation();
                        animation.To = 360;
                        animation.RepeatBehavior = RepeatBehavior.Forever;
                        animation.Duration = loading.Duration;

                        RotateTransform rotateTransform = new RotateTransform();
                        rotateTransform.CenterX = loading.ActualWidth/2;
                        rotateTransform.CenterY = loading.ActualHeight/2;
                        loading.sector.RenderTransform = rotateTransform;
                        rotateTransform.BeginAnimation(RotateTransform.AngleProperty,animation);
                    }
                    else
                    {
                        loading.sector.RenderTransform=null;
                    }
                }
            }
        }

        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Loading loading = (Loading)d;
            loading.EndAngle = 360 * loading.ArcLength;
            loading.InvalidateVisual();
        }
    }
}