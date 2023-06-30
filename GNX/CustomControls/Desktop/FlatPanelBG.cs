using System.Drawing;
namespace GNX
{
    public class FlatPanelBG : FlatPanel
    {
        public override void DarkTheme()
        {
            base.DarkTheme();
            if (BackColor != Color.Transparent)
                BackColor = ColorTranslator.FromHtml("#242424");
            //BackColor = ColorTranslator.FromHtml("#191919");
        }
    }
}