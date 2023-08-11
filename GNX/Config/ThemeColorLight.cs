using System.Drawing;
using System.Windows.Forms;

namespace GNX
{
    public class ThemeColorLight : ThemeColor
    {
        public override void WindowForm(Form f) { Theme.SetWindowDark(f.Handle, 0); }
        public override void MainBaseForm(MainBaseForm f) { f.BackColor = Colors.HTML("F0F0F0"); }
        public override void ContentBaseForm(ContentBaseForm f) { f.BackColor = Colors.HTML("F0F0F0"); }

        public override void FlatPanel(FlatPanel c)
        {
            c.BorderColor = Colors.HTML("A0A0A0");

            if (c.OriginalBackColor != Color.Transparent)
                c.BackColor = c.OriginalBackColor;
        }

        public override void FlatLabel(FlatLabel c)
        {
            c.ForeColor = c.OriginalForeColor;
        }

        public override void FlatButton(FlatButton c)
        {
            c.BackgroundColor = Colors.RGB(230, 230, 230);
            c.BackgroundColorFocus = Colors.RGB(213, 213, 213);
            c.BorderColor = Colors.RGB(213, 223, 229);
            c.BorderColorDefault = Colors.RGB(213, 223, 229);
            c.TextColor = Colors.RGB(47, 47, 47);
            c.SelectedColor = Colors.RGB(203, 223, 254);
        }

        public override void FlatTextBox(FlatTextBox c)
        {
            c.BackgroundColor = Colors.HTML("FFFFFF");
            c.BackgroundColorFocus = Colors.HTML("FFFFFF");
            c.LabelTextColor = Colors.RGB(108, 132, 199);
            c.TextColor = Colors.RGB(47, 47, 47);
            c.TextColorFocus = Colors.RGB(47, 47, 47);
            c.BorderColor = Colors.RGB(213, 223, 229);
        }

        public override void FlatMaskedTextBox(FlatMaskedTextBox c)
        {
            c.BackgroundColor = Colors.HTML("FFFFFF");
            c.BackgroundColorFocus = Colors.HTML("FFFFFF");
            c.LabelTextColor = Colors.RGB(108, 132, 199);
            c.TextColor = Colors.RGB(47, 47, 47);
            c.TextColorFocus = Colors.RGB(47, 47, 47);
            c.BorderColor = Colors.RGB(213, 223, 229);
        }

        public override void FlatComboBox(FlatComboBox c)
        {
            c.BackgroundColor = Colors.HTML("FFFFFF");
            c.LabelTextColor = Colors.RGB(108, 132, 199);
            c.ItemTextColor = Colors.RGB(47, 47, 47);
            c.BorderColor = Colors.RGB(213, 223, 229);
        }

        public override void FlatStatusBar(FlatStatusBar c)
        {
            c.BackColor = Colors.RGB(145, 145, 145);
            c.BackColorContent = Colors.RGB(240, 240, 240);
        }
    }
}