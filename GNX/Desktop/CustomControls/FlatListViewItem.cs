using System.Windows.Forms;

namespace GNX.Desktop
{
    public class FlatListViewItem : ListViewItem
    {
        public bool Hover { get; set; }

        public FlatListViewItem()
        {
            Hover = false;
        }
    }
}