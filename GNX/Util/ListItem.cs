using System;
//

namespace GNX
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ListItem()
        {
            Id = 0;
            Name = string.Empty;
        }
    }
}
