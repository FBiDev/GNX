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

        protected static eTheme SelectedTheme { get; set; }
        public static void SetTheme(eTheme newTheme)
        {
            SelectedTheme = newTheme;
        }

        internal protected static void CheckTheme(Form f)
        {
            switch (SelectedTheme)
            {
                case eTheme.Light: break;
                case eTheme.Dark: Instance.DarkTheme(f); break;
                case eTheme.Blue: break;
                default: break;
            }
        }

        protected virtual void DarkTheme(Form f)
        {
            SetWindowDark(f.Handle);

            if (f is MainBaseForm)
            {
                var form = (MainBaseForm)f;
                form.BackColor = ColorTranslator.FromHtml("#242424");
            }

            if (f is ContentBaseForm)
            {
                var form = (ContentBaseForm)f;
                form.BackColor = ColorTranslator.FromHtml("#242424");
            }

            foreach (var c in f.GetControls<FlatLabel>())
                c.DarkTheme();

            foreach (var c in f.GetControls<FlatPanel>())
                c.DarkTheme();

            foreach (var c in f.GetControls<FlatStatusBar>())
                c.DarkTheme();

            foreach (var c in f.GetControls<FlatButton>())
                c.DarkTheme();

            foreach (var c in f.GetControls<FlatTextBox>())
                c.DarkTheme();

            foreach (var c in f.GetControls<FlatComboBox>())
                c.DarkTheme();
        }

        protected void SetWindowDark(IntPtr handle)
        {
            var dark = 1;
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