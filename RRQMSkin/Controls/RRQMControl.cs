using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RRQMSkin.Controls
{
    public class RRQMControl : Control
    {
        public RRQMControl()
        {
            this.SizeChanged += this.PieChart_SizeChanged;
        }

        private void PieChart_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.InvalidateArrange();
            this.InvalidateMeasure();
            this.InvalidateVisual();
        }
        public bool IsInDesignMode
        {
            get { return DesignerProperties.GetIsInDesignMode(this); }
        }
    }
}
