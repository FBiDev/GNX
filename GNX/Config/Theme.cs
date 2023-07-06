using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GNX
{
    public class Theme
    {
        public enum eTheme
        {
            Light,
            Dark,
            Blue
        }

        protected static Theme _inst;
        protected static Theme Instance
        {
            get { return _inst ?? (_inst = new Theme()); }
        }

        private static eTheme _SelectedTheme;
        public static eTheme SelectedTheme
        {
            get { return _SelectedTheme; }
            set
            {
                _SelectedTheme = value;

                foreach (Form f in Application.OpenForms)
                {
                    CheckTheme(f);
                }
            }
        }

        public static void SetTheme(eTheme newTheme)
        {
            SelectedTheme = newTheme;
        }

        internal protected static void CheckTheme(Form f)
        {
            switch (SelectedTheme)
            {
                case eTheme.Light: Instance.LightTheme(f); break;
                case eTheme.Dark: Instance.DarkTheme(f); break;
                case eTheme.Blue: break;
                default: break;
            }
        }

        private static FlatButton LightButton = new FlatButton
        {
            BackgroundColor = Colors.RGB(230, 230, 230),
            BackgroundColorFocus = Colors.RGB(213, 213, 213),
            BorderColor = Colors.RGB(213, 223, 229),
            BorderColorDefault = Colors.RGB(213, 223, 229),

            TextColor = Colors.RGB(47, 47, 47),
            SelectedColor = Colors.RGB(203, 223, 254),
        };

        private void SetButtonColors(FlatButton c, FlatButton btn)
        {
            c.BackgroundColor = btn.BackgroundColor;
            c.BackgroundColorFocus = btn.BackgroundColorFocus;
            c.BorderColor = btn.BorderColor;
            c.BorderColorDefault = btn.BorderColor;

            c.TextColor = btn.TextColor;
            c.SelectedColor = btn.SelectedColor;
            c.ResetColors();
        }

        protected virtual void LightTheme(Form f)
        {
            SetWindowDark(f.Handle, 0);

            if (f is MainBaseForm)
            {
                var form = (MainBaseForm)f;
                form.BackColor = Colors.HTML("F0F0F0");
                f.Refresh();
            }
            else if (f is ContentBaseForm)
            {
                var form = (ContentBaseForm)f;
                form.BackColor = Colors.HTML("F0F0F0");
                f.Refresh();
            }

            foreach (var control in f.GetControls<Control>())
            {
                //override firsts
                if (control is FlatPanel)
                {
                    var c = (FlatPanel)control;
                    c.BorderColor = Colors.HTML("A0A0A0");

                    if (c.BackColor != Color.Transparent)
                        c.BackColor = c.OriginalBackColor;
                }
                else if (control is FlatLabel)
                {
                    var c = (FlatLabel)control;
                    c.ForeColor = c.OriginalForeColor;
                }
                else if (control is FlatStatusBar)
                {
                    var c = (FlatStatusBar)control;
                    c.BackColor = Colors.RGB(145, 145, 145);
                    c.BackColorContent = Colors.RGB(240, 240, 240);
                }
                else if (control is FlatButton)
                {
                    SetButtonColors((FlatButton)control, LightButton);
                    //var c = (FlatButton)control;
                    //c.BackgroundColor = Colors.RGB(230, 230, 230);
                    //c.BackgroundColorFocus = Colors.RGB(213, 213, 213);
                    //c.BorderColor = Colors.RGB(213, 223, 229);
                    //c.BorderColorDefault = c.BorderColor;

                    //c.TextColor = Colors.RGB(47, 47, 47);
                    //c.SelectedColor = Colors.RGB(203, 223, 254);
                    //c.ResetColors();
                }
                else if (control is FlatTextBox)
                {
                    var c = (FlatTextBox)control;
                    c.BackgroundColor = Colors.HTML("FFFFFF");
                    c.BackgroundColorFocus = c.BackgroundColor;
                    c.LabelTextColor = Colors.RGB(108, 132, 199);
                    c.TextColor = Colors.RGB(47, 47, 47);
                    c.TextColorFocus = c.TextColor;
                    c.BorderColor = Colors.RGB(213, 223, 229);
                    c.ResetColors();
                }
                else if (control is FlatComboBox)
                {
                    var c = (FlatComboBox)control;
                    c.BackgroundColor = Colors.HTML("FFFFFF");
                    c.LabelTextColor = Colors.RGB(108, 132, 199);
                    c.ItemTextColor = Colors.RGB(47, 47, 47);
                    c.BorderColor = Colors.RGB(213, 223, 229);
                    c.ResetColors();
                }
            }
        }

        protected virtual void DarkTheme(Form f)
        {
            SetWindowDark(f.Handle);

            if (f is MainBaseForm)
            {
                var form = (MainBaseForm)f;
                form.BackColor = Colors.HTML("242424");
                f.Refresh();
            }
            else if (f is ContentBaseForm)
            {
                var form = (ContentBaseForm)f;
                form.BackColor = Colors.HTML("242424");
                f.Refresh();
            }

            foreach (var control in f.GetControls<Control>())
            {
                //override firsts
                if (control is FlatPanel)
                {
                    var c = (FlatPanel)control;
                    c.BorderColor = Colors.HTML("424242");

                    if (c.BackColor != Color.Transparent)
                    {
                        if (c.BackColor == Colors.HTML("F0F0F0"))
                            c.BackColor = Colors.HTML("242424");
                        else if (c.BackColor == Colors.HTML("FCFCFC"))
                            c.BackColor = Colors.HTML("272727");
                    }
                }
                else if (control is FlatLabel)
                {
                    var c = (FlatLabel)control;
                    c.ForeColor = Colors.HTML("A3B2DC");
                }
                else if (control is FlatStatusBar)
                {
                    var c = (FlatStatusBar)control;
                    c.BackColor = Colors.HTML("424242");
                    c.BackColorContent = Colors.HTML("242424");
                }
                else if (control is FlatButton)
                {
                    var c = (FlatButton)control;
                    c.BackgroundColor = Colors.HTML("505050");
                    c.BackgroundColorFocus = c.BackgroundColor;
                    c.BorderColor = Colors.HTML("666666");
                    c.BorderColorDefault = c.BorderColor;

                    c.TextColor = Colors.HTML("D2D2D2");
                    c.SelectedColor = Colors.HTML("191919");
                    c.ResetColors();
                }
                else if (control is FlatTextBox)
                {
                    var c = (FlatTextBox)control;
                    c.BackgroundColor = Colors.HTML("191919");
                    c.BackgroundColorFocus = c.BackgroundColor;
                    c.LabelTextColor = Colors.HTML("A3B2DC");
                    c.TextColor = Colors.HTML("D2D2D2");
                    c.TextColorFocus = c.TextColor;
                    c.BorderColor = Colors.HTML("424242");
                    c.ResetColors();
                }
                else if (control is FlatComboBox)
                {
                    var c = (FlatComboBox)control;
                    c.BackgroundColor = Colors.HTML("191919");
                    c.LabelTextColor = Colors.HTML("A3B2DC");
                    c.ItemTextColor = Colors.HTML("D2D2D2");
                    c.BorderColor = Colors.HTML("424242");
                    c.ResetColors();
                }
            }
        }

        protected void SetWindowDark(IntPtr handle, int dark = 1)
        {
            //var dark = 1;
            DwmSetWindowAttribute(handle, DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE, ref dark, sizeof(uint));
        }

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = true)]
        static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref int pvAttribute, uint cbAttribute);

        enum DWMWINDOWATTRIBUTE : uint
        {
            DWMWA_NCRENDERING_ENABLED,
            DWMWA_NCRENDERING_POLICY,
            DWMWA_TRANSITIONS_FORCEDISABLED,
            DWMWA_ALLOW_NCPAINT,
            DWMWA_CAPTION_BUTTON_BOUNDS,
            DWMWA_NONCLIENT_RTL_LAYOUT,
            DWMWA_FORCE_ICONIC_REPRESENTATION,
            DWMWA_FLIP3D_POLICY,
            DWMWA_EXTENDED_FRAME_BOUNDS,
            DWMWA_HAS_ICONIC_BITMAP,
            DWMWA_DISALLOW_PEEK,
            DWMWA_EXCLUDED_FROM_PEEK,
            DWMWA_CLOAK,
            DWMWA_CLOAKED,
            DWMWA_FREEZE_REPRESENTATION,
            DWMWA_PASSIVE_UPDATE_MODE,
            DWMWA_USE_HOSTBACKDROPBRUSH,
            DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
            DWMWA_WINDOW_CORNER_PREFERENCE = 33,
            DWMWA_BORDER_COLOR,
            DWMWA_CAPTION_COLOR,
            DWMWA_TEXT_COLOR,
            DWMWA_VISIBLE_FRAME_BORDER_THICKNESS,
            DWMWA_SYSTEMBACKDROP_TYPE,
            DWMWA_LAST
        }
    }
}