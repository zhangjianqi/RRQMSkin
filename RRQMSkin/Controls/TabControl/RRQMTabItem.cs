using System.Windows.Controls;
using System.Windows.Input;
using RRQMMVVM;

namespace RRQMSkin.Controls
{
    public class RRQMTabItem : TabItem
    {
        public RRQMTabItem()
        {
            this.CloseItemCommand = new ExecuteCommand(CloseItem);
        }

        public ExecuteCommand CloseItemCommand { get; set; }

        private void CloseItem()
        {
            if (this.Parent is RRQMTabControl)
            {
                RRQMTabControl tabControl = (RRQMTabControl)this.Parent;
                tabControl.Items.Remove(this);
            }
        }
    }
}