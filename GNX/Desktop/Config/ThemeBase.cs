using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public static class ThemeBase
    {
        public enum eTheme
        {
            Light,
            Dark
        }

        public static eTheme SelectedTheme { get; set; }
        static bool SelectedThemeChanged;

        static ThemeColor _ColorSet;
        public static ThemeColor ColorSet
        {
            get
            {
                return _ColorSet;
            }
            set
            {
                _ColorSet = value;

                if (_ColorSet == null) return;

                if (SelectedThemeChanged == false) return;

                foreach (Form f in Application.OpenForms)
                {
                    CheckTheme(f);
                }
            }
        }

        public static bool ToggleDarkMode()
        {
            if (SelectedTheme != eTheme.Dark)
            {
                SetTheme(eTheme.Dark);
                return true;
            }

            SetTheme(eTheme.Light);
            return false;
        }

        public static void SetTheme(eTheme newTheme)
        {
            SelectedTheme = newTheme;
            SelectedThemeChanged = true;

            switch (SelectedTheme)
            {
                case eTheme.Light: ColorSet = new ThemeColorLight(); break;
                case eTheme.Dark: ColorSet = new ThemeColorDark(); break;
            }
        }

        public static void CheckControlTheme(Control control)
        {
            if (ColorSet.IsNull()) ColorSet = new ThemeColorLight();

            if (control is FlatPanel)
                ColorSet.FlatPanel((FlatPanel)control);
            else if (control is FlatLabel)
                ColorSet.FlatLabel((FlatLabel)control);

            if (control is FlatButton)
            {
                ColorSet.FlatButton((FlatButton)control);
                ((FlatButton)control).ResetColors();
            }
            else if (control is FlatCheckBox)
            {
                ColorSet.FlatCheckBox((FlatCheckBox)control);
                ((FlatCheckBox)control).ResetColors();
            }
            else if (control is FlatTextBox)
            {
                ColorSet.FlatTextBox((FlatTextBox)control);
                ((FlatTextBox)control).ResetColors();
            }
            else if (control is FlatMaskedTextBox)
            {
                ColorSet.FlatMaskedTextBox((FlatMaskedTextBox)control);
                ((FlatMaskedTextBox)control).ResetColors();
            }
            else if (control is FlatComboBox)
            {
                ColorSet.FlatComboBox((FlatComboBox)control);
                ((FlatComboBox)control).ResetColors();
            }
            else if (control is FlatStatusBar)
                ColorSet.FlatStatusBar((FlatStatusBar)control);
            else if (control is FlatTabControl)
                ColorSet.FlatTabControl((FlatTabControl)control);
            else if (control is FlatPictureBox)
                ColorSet.FlatPictureBox((FlatPictureBox)control);
            else if (control is FlatGroupBox)
                ColorSet.FlatGroupBox((FlatGroupBox)control);
            else if (control is FlatListView)
                ColorSet.FlatListView((FlatListView)control);
            else if (control is FlatDataGrid)
                ColorSet.FlatDataGrid((FlatDataGrid)control);
            else if (control is ButtonExe)
                ColorSet.ButtonExe((ButtonExe)control);
            else if (control is RichTextBox)
                ColorSet.RichTextBox((RichTextBox)control);
        }

        public static void CheckTheme(Form f)
        {
            if (ColorSet == null) return;

            ColorSet.WindowForm(f);

            if (f is MainBaseForm)
                ColorSet.MainBaseForm((MainBaseForm)f);
            else if (f is ContentBaseForm)
                ColorSet.ContentBaseForm((ContentBaseForm)f);
            else if (f is Form)
                ColorSet.Form(f);

            foreach (var control in f.GetControls<Control>())
            {
                CheckControlTheme(control);
            }
        }

        public static void SetWindowDark(IntPtr handle, int dark = 1)
        {
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