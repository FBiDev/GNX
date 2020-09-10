using System;
using System.Collections.Generic;
using System.Windows.Forms;
//

namespace GNX
{
    public class ComboBoxNew : ComboBox
    {
        private int previousIndex = -1;
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectedIndex != previousIndex)
            {
                base.OnSelectedIndexChanged(e);
                previousIndex = SelectedIndex;
            }
        }
    }
}
