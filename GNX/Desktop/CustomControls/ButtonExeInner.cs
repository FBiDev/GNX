using System.Windows.Forms;

namespace GNX.Desktop
{
    public class ButtonExeInner : Button
    {
        protected override bool ShowFocusCues
        {
            get { return Focused; }
        }
    }
}