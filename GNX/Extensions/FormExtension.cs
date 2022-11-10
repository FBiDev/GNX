using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GNX
{
    public static class FormExtension
    {
        public static IEnumerable<T> GetControls<T>(this Control c)
        {
            return c.Controls.OfType<T>().
                   Concat(c.Controls.OfType<Control>().SelectMany(x => x.GetControls<T>()));
        }

        public static Point ControlLocation(this Form f, Control c)
        {
            Point locationOnForm = f.PointToClient(c.Parent.PointToScreen(c.Location));
            return locationOnForm;
        }
    }
}
