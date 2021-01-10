using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RRQMSkin.Charts
{
   public abstract class RRQMChart:ItemsControl
    {
        public abstract void UpdataChart();

        public bool IsInDesignMode
        {
            get { return DesignerProperties.GetIsInDesignMode(this); }
        }
    }
}
