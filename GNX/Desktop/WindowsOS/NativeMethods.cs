﻿using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public static class NativeMethods
    {
        public static int WM_NCLBUTTONDOWN { get { return 0xA1; } }
        public static IntPtr HT_CAPTION { get { return new IntPtr(0x2); } }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public static IntPtr SendMessageInternal(IntPtr Handle)
        {
            return SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, new IntPtr(0));
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        static extern void SetWindowPos(uint Hwnd, uint Level, int X, int Y, int W, int H, uint Flags);

        public static bool IsVCRedist2012Installed()
        {
            return IsAPPInstalled("Microsoft Visual C++ 2012 x64", "11.0.50727");
        }

        static bool IsAPPInstalled(string displayName, string additionalName = "")
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
            {
                if (key == null) return false;

                foreach (string subKeyName in key.GetSubKeyNames())
                {
                    using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                    {
                        var appName = subKey.GetValue("DisplayName");

                        if (appName == null) continue;
                        var appNameStr = appName.ToString();

                        if (appNameStr.Contains(displayName) && appNameStr.Contains(additionalName))
                            return true;
                    }
                }
            }
            return false;
        }

        //GETOS
        #region OSVERSIONINFOEX
        [DllImport("kernel32.dll")]
        internal static extern bool GetVersionEx(ref OSVERSIONINFOEX osVersionInfo);

        internal static OSVERSIONINFOEX GetOSVersionInfo()
        {
            var osVersionInfo = new OSVERSIONINFOEX
            {
                dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX))
            };
            GetVersionEx(ref osVersionInfo);
            return osVersionInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct OSVERSIONINFOEX
        {
            public int dwOSVersionInfoSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szCSDVersion;
            public short wServicePackMajor;
            public short wServicePackMinor;
            public short wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }
        #endregion OSVERSIONINFOEX

        #region Tests
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        //int SPI_SETDRAGFULLWINDOWS = 0x0025;
        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //private static extern int SystemParametersInfo(int uAction, int uParam, int lpvParam, int fuWinIni);
        //SystemParametersInfo(SPI_SETDRAGFULLWINDOWS, 0, 0, 2);
        //SystemParametersInfo(SPI_SETDRAGFULLWINDOWS, 1, 0, 2);

        //[Flags()]
        //public enum RedrawWindowFlags : uint
        //{
        //    Invalidate = 0X1,
        //    InternalPaint = 0X2,
        //    Erase = 0X4,
        //    Validate = 0X8,
        //    NoInternalPaint = 0X10,
        //    NoErase = 0X20,
        //    NoChildren = 0X40,
        //    AllChildren = 0X80,
        //    UpdateNow = 0X100,
        //    EraseNow = 0X200,
        //    Frame = 0X400,
        //    NoFrame = 0X800
        //}

        //public static int WM_NCPAINT = 0x85;

        //[DllImport("user32.dll")]
        //public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);
        //[DllImport("User32.dll")]
        //private extern static int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        //[DllImport("user32.dll")]
        //static extern IntPtr GetWindowDC(IntPtr hWnd);
        #endregion
    }

    public static class Window
    {
        public static void SendKey(Keys key)
        {
            switch (key)
            {
                case Keys.Enter: SendKeys.Send("{ENTER}"); break;
                case Keys.Tab: SendKeys.Send("{TAB}"); break;
                case Keys.Escape: SendKeys.Send("{ESCAPE}"); break;
            }
        }

        static void SuppressAltKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.RButton | Keys.ShiftKey | Keys.Alt))
                e.SuppressKeyPress = true;
        }

        public static void AltMenuDisable(Form f)
        {
            f.KeyDown -= SuppressAltKey;
            f.KeyDown += SuppressAltKey;
        }
    }

    public static class Mouse
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [Flags]
        enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        public static void LeftClick(Point location)
        {
            var prevLocation = Cursor.Position;
            Cursor.Position = new Point(location.X, location.Y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
            Cursor.Position = prevLocation;
        }
    }
}