using System.Drawing;

namespace GNX
{
    public partial class Theme
    {
        #region Form
        void SetMainBaseTheme(MainBaseForm f)
        {
            switch (SelectedTheme)
            {
                case eTheme.Light: LightMainBase(f); break;
                case eTheme.Dark: DarkMainBase(f); break;
            }
        }

        protected virtual void LightMainBase(MainBaseForm f) { f.BackColor = Colors.HTML("F0F0F0"); }
        protected virtual void DarkMainBase(MainBaseForm f) { f.BackColor = Colors.HTML("242424"); }

        void SetContentBaseTheme(ContentBaseForm f)
        {
            switch (SelectedTheme)
            {
                case eTheme.Light: LightContentBase(f); break;
                case eTheme.Dark: DarkContentBase(f); break;
            }
        }

        protected virtual void LightContentBase(ContentBaseForm f) { f.BackColor = Colors.HTML("F0F0F0"); }
        protected virtual void DarkContentBase(ContentBaseForm f) { f.BackColor = Colors.HTML("242424"); }
        #endregion

        #region Panel
        void SetFlatPanelTheme(FlatPanel c)
        {
            switch (SelectedTheme)
            {
                case eTheme.Light: LightFlatPanel(c); break;
                case eTheme.Dark: DarkFlatPanel(c); break;
            }
            //c.ResetColors();
        }

        protected virtual void LightFlatPanel(FlatPanel c)
        {
            c.BorderColor = Colors.HTML("A0A0A0");

            if (c.OriginalBackColor != Color.Transparent)
                c.BackColor = c.OriginalBackColor;
        }

        protected virtual void DarkFlatPanel(FlatPanel c)
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
        #endregion

        #region Label
        void SetFlatLabelTheme(FlatLabel c)
        {
            switch (SelectedTheme)
            {
                case eTheme.Light: LightFlatLabel(c); break;
                case eTheme.Dark: DarkFlatLabel(c); break;
            }
            //c.ResetColors();
        }

        protected virtual void LightFlatLabel(FlatLabel c) { c.ForeColor = c.OriginalForeColor; }
        protected virtual void DarkFlatLabel(FlatLabel c) { c.ForeColor = Colors.HTML("A3B2DC"); }
        #endregion

        #region FlatButton
        void SetFlatButtonTheme(FlatButton c)
        {
            switch (SelectedTheme)
            {
                case eTheme.Light: LightFlatButton(c); break;
                case eTheme.Dark: DarkFlatButton(c); break;
            }
            c.ResetColors();
        }

        protected virtual void LightFlatButton(FlatButton c)
        {
            c.BackgroundColor = Colors.RGB(230, 230, 230);
            c.BackgroundColorFocus = Colors.RGB(213, 213, 213);
            c.BorderColor = Colors.RGB(213, 223, 229);
            c.BorderColorDefault = Colors.RGB(213, 223, 229);
            c.TextColor = Colors.RGB(47, 47, 47);
            c.SelectedColor = Colors.RGB(203, 223, 254);
        }

        protected virtual void DarkFlatButton(FlatButton c)
        {
            c.BackgroundColor = Colors.RGB(80, 80, 80);
            c.BackgroundColorFocus = Colors.RGB(80, 80, 80);
            c.BorderColor = Colors.RGB(102, 102, 102);
            c.BorderColorDefault = Colors.RGB(102, 102, 102);
            c.TextColor = Colors.RGB(210, 210, 210);
            c.SelectedColor = Colors.RGB(25, 25, 25);
        }
        #endregion


        #region FlatTextBox
        void SetFlatTextBoxTheme(FlatTextBox c)
        {
            switch (SelectedTheme)
            {
                case eTheme.Light: LightFlatTextBox(c); break;
                case eTheme.Dark: DarktFlatTextBox(c); break;
            }
            c.ResetColors();
        }

        protected virtual void LightFlatTextBox(FlatTextBox c)
        {
            c.BackgroundColor = Colors.HTML("FFFFFF");
            c.BackgroundColorFocus = Colors.HTML("FFFFFF");
            c.LabelTextColor = Colors.RGB(108, 132, 199);
            c.TextColor = Colors.RGB(47, 47, 47);
            c.TextColorFocus = Colors.RGB(47, 47, 47);
            c.BorderColor = Colors.RGB(213, 223, 229);
        }

        protected virtual void DarktFlatTextBox(FlatTextBox c)
        {
            c.BackgroundColor = Colors.HTML("191919");
            c.BackgroundColorFocus = Colors.HTML("191919");
            c.LabelTextColor = Colors.HTML("A3B2DC");
            c.TextColor = Colors.HTML("D2D2D2");
            c.TextColorFocus = Colors.HTML("D2D2D2");
            c.BorderColor = Colors.HTML("424242");
        }
        #endregion

        #region FlatComboBox
        void SetFlatComboBoxTheme(FlatComboBox c)
        {
            switch (SelectedTheme)
            {
                case eTheme.Light: LightFlatComboBox(c); break;
                case eTheme.Dark: DarkFlatComboBox(c); break;
            }
            c.ResetColors();
        }

        protected virtual void LightFlatComboBox(FlatComboBox c)
        {
            c.BackgroundColor = Colors.HTML("FFFFFF");
            c.LabelTextColor = Colors.RGB(108, 132, 199);
            c.ItemTextColor = Colors.RGB(47, 47, 47);
            c.BorderColor = Colors.RGB(213, 223, 229);
        }

        protected virtual void DarkFlatComboBox(FlatComboBox c)
        {
            c.BackgroundColor = Colors.HTML("191919");
            c.LabelTextColor = Colors.HTML("A3B2DC");
            c.ItemTextColor = Colors.HTML("D2D2D2");
            c.BorderColor = Colors.HTML("424242");
        }
        #endregion

        #region FlatStatusBar

        void SetFlatStatusBarTheme(FlatStatusBar c)
        {
            switch (SelectedTheme)
            {
                case eTheme.Light: LightFlatStatusBar(c); break;
                case eTheme.Dark: DarkFlatStatusBar(c); break;
            }
            //c.ResetColors();
        }

        protected virtual void LightFlatStatusBar(FlatStatusBar c)
        {
            c.BackColor = Colors.RGB(145, 145, 145);
            c.BackColorContent = Colors.RGB(240, 240, 240);
        }

        protected virtual void DarkFlatStatusBar(FlatStatusBar c)
        {
            c.BackColor = Colors.HTML("424242");
            c.BackColorContent = Colors.HTML("242424");
        }
        #endregion
    }
}