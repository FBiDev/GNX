using System.Drawing;
using System.Windows.Forms;

namespace GNX
{
    public class ThemeColorDark : ThemeColor
    {
        public override void WindowForm(Form f) { Theme.SetWindowDark(f.Handle, 1); }
        public override void MainBaseForm(MainBaseForm f) { f.BackColor = Colors.HTML("242424"); }
        public override void ContentBaseForm(ContentBaseForm f) { f.BackColor = Colors.HTML("242424"); }

        public override void FlatPanel(FlatPanel c)
        {
            c.BorderColor = Colors.HTML("424242");

            if (c.OriginalBackColor != Color.Transparent)
            {
                if (c.OriginalBackColor == Colors.HTML("F0F0F0"))
                    c.BackColor = Colors.HTML("242424");
                else if (c.OriginalBackColor == Colors.HTML("FCFCFC"))
                    c.BackColor = Colors.HTML("272727");
            }
        }

        public override void FlatLabel(FlatLabel c)
        {
            c.ForeColor = Colors.HTML("A3B2DC");
        }

        public override void FlatButton(FlatButton c)
        {
            c.BackgroundColor = Colors.RGB(80, 80, 80);
            c.BackgroundColorFocus = Colors.RGB(80, 80, 80);
            c.BorderColor = Colors.RGB(102, 102, 102);
            c.BorderColorDefault = Colors.RGB(102, 102, 102);
            c.TextColor = Colors.RGB(210, 210, 210);
            c.SelectedColor = Colors.RGB(25, 25, 25);
        }

        public override void FlatCheckBox(FlatCheckBox c)
        {
            c.BorderColor = ColorTranslator.FromHtml("#424242");
            c.BorderColorFocus = Color.FromArgb(108, 132, 199);
            c.BackColor = ColorTranslator.FromHtml("#191919");
        }

        public override void FlatTextBox(FlatTextBox c)
        {
            c.BackgroundColor = Colors.HTML("191919");
            c.BackgroundColorFocus = Colors.HTML("191919");
            c.LabelTextColor = Colors.HTML("A3B2DC");
            c.TextColor = Colors.HTML("D2D2D2");
            c.TextColorFocus = Colors.HTML("D2D2D2");
            c.BorderColor = Colors.HTML("424242");
        }

        public override void FlatMaskedTextBox(FlatMaskedTextBox c)
        {
            c.BackgroundColor = Colors.HTML("191919");
            c.BackgroundColorFocus = Colors.HTML("191919");
            c.LabelTextColor = Colors.HTML("A3B2DC");
            c.TextColor = Colors.HTML("D2D2D2");
            c.TextColorFocus = Colors.HTML("D2D2D2");
            c.BorderColor = Colors.HTML("424242");
        }

        public override void FlatComboBox(FlatComboBox c)
        {
            c.BackgroundColor = Colors.HTML("191919");
            c.LabelTextColor = Colors.HTML("A3B2DC");
            c.ItemTextColor = Colors.HTML("D2D2D2");
            c.BorderColor = Colors.HTML("424242");
        }

        public override void FlatStatusBar(FlatStatusBar c)
        {
            c.BackColor = Colors.HTML("424242");
            c.BackColorContent = Colors.HTML("242424");
        }
    }
}