using System;
//

namespace GNX
{
    public class ListItem
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public ListItem()
        {
            Value = 0;
            Text = string.Empty;
        }
    }
}