using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RRQMSkin.Charts.Primitives
{
    /// <summary>
    /// 若汝棋茗绘图基础类
    /// </summary>
    public abstract class RRQMShape : Shape
    {
        /// <summary>
        ///
        /// </summary>
        public RRQMShape()
        {
            this.SizeChanged += Sector_SizeChanged;
        }

        public bool IsInDesignMode
        {
            get { return DesignerProperties.GetIsInDesignMode(this); }
        }

        private void Sector_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.InvalidateVisual();
        }
        /// <summary>
        ///
        /// </summary>
        protected override Geometry DefiningGeometry { get { return CreatGeometry(); } }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected abstract Geometry CreatGeometry();
    }
}