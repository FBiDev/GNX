using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GNX
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
