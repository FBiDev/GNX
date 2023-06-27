using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GNX
{
    public static class Theme
    {
        public static bool DarkMode { get; set; }

        public static void CheckTheme(Form f)
        {
            if (DarkMode)
            {
                SetDarkMode(f);
                SetWindowDark(f.Handle);
            }
            else
            {
                SetLightMode();
            }
        }

        public static void SetLightMode()
        {
            //ChangeTheme(f);
        }

        public static void SetDarkMode(Form f)
        {
            ChangeTheme(f);
        }

        static void ChangeTheme(Form f)
        {
            if (f is ContentBaseForm)
                ((ContentBaseForm)f).DarkTheme();
            if (f is MainBaseForm)
                ((MainBaseForm)f).DarkTheme();

            foreach (var c in f.GetControls<FlatLabel>())
                if (DarkMode) c.DarkTheme();

            foreach (var c in f.GetControls<FlatPanel>())
            {
                if (c.Name == "pnlHead" || c.Name == "pnlBody" || c.Name == "pnlFoot")
                {
                    if (DarkMode) c.DarkTheme();
                }
            }

            foreach (var c in f.GetControls<FlatButton>())
            {
                if (DarkMode) c.DarkTheme();
                //else c.LightMode();
            }

            foreach (var c in f.GetControls<FlatTextBox>())
            {
                if (DarkMode) c.DarkTheme();
                //else c.LightMode();
            }

            foreach (var c in f.GetControls<FlatComboBox>())
            {
                if (DarkMode) c.DarkTheme();
                //else c.LightMode();
            }
        }

        public static void SetWindowDark(IntPtr handle)
        {
            var dark = 1;
            DwmSetWindowAttribute(handle, DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE, ref dark, sizeof(uint));
        }

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = true)]
        public static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref int pvAttribute, uint cbAttribute);

        public enum DWMWINDOWATTRIBUTE : uint
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