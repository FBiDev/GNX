using System;
using System.Runtime.InteropServices;
//

namespace GNX
{
    public static class NativeMethods
    {
        public static int WM_NCLBUTTONDOWN { get { return 0xA1; } }
        public static IntPtr HT_CAPTION { get { return new IntPtr(0x2); } }

        [DllImportAttribute("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern void SetWindowPos(uint Hwnd, uint Level, int X, int Y, int W, int H, uint Flags);

        public static IntPtr _SendMessage(IntPtr Handle)
        {
            return SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, new IntPtr(0));
        }

        public static bool _ReleaseCapture()
        {
            return ReleaseCapture();
        }

        #region Tests
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
}
