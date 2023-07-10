using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GNX
{
    public partial class Theme
    {
        public enum eTheme
        {
            Empty,
            Light,
            Dark
        }

        protected static Theme _inst;
        protected static Theme Instance
        {
            get { return _inst ?? (_inst = new Theme()); }
            set { _inst = _inst ?? (_inst = value); }
        }

        public static eTheme SelectedTheme { get; set; }

        public static void SetTheme(eTheme newTheme)
        {
            SelectedTheme = newTheme;

            foreach (Form f in Application.OpenForms)
            {
                CheckTheme(f);
            }
        }

        public static void DarkMode()
        {
            if (SelectedTheme == eTheme.Dark)
                SetTheme(eTheme.Light);
            else
                SetTheme(eTheme.Dark);
        }

        internal protected static void CheckTheme(Form f)
        {
            switch (SelectedTheme)
            {
                case eTheme.Light:
                    Instance.SetWindowDark(f.Handle, 0); break;
                case eTheme.Dark:
                    Instance.SetWindowDark(f.Handle, 1); break;
            }

            Instance.ChangeControlsTheme(f);
        }

        public void ChangeControlsTheme(Form f)
        {
            if (f is MainBaseForm)
            {
                SetMainBaseTheme((MainBaseForm)f);
            }
            else if (f is ContentBaseForm)
            {
                SetContentBaseTheme((ContentBaseForm)f);
            }

            foreach (var control in f.GetControls<Control>())
            {
                if (control is FlatPanel)
                {
                    SetFlatPanelTheme((FlatPanel)control);
                }
                else if (control is FlatLabel)
                {
                    SetFlatLabelTheme((FlatLabel)control);
                }
                if (control is FlatButton)
                {
                    SetFlatButtonTheme((FlatButton)control);
                }
                else if (control is FlatTextBox)
                {
                    SetFlatTextBoxTheme((FlatTextBox)control);
                }
                else if (control is FlatComboBox)
                {
                    SetFlatComboBoxTheme((FlatComboBox)control);
                }
                else if (control is FlatStatusBar)
                {
                    SetFlatStatusBarTheme((FlatStatusBar)control);
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