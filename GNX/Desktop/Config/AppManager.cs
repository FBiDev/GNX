using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public static class AppManager
    {
        public static string Name { get { return Assembly.GetExecutingAssembly().GetName().Name; } }
        public static string Version { get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }
        public static string BaseDirectory { get { return AppDomain.CurrentDomain.BaseDirectory; } }
        public static string ExecutablePath { get { return Assembly.GetExecutingAssembly().Location; } }
        public static bool Is64BitProcess { get { return Environment.Is64BitProcess; } }
        public static bool Is64BitOperatingSystem { get { return Environment.Is64BitOperatingSystem; } }
        public static string Processor_architecture { get { return Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"); } }
        public static ImageFileMachine TargetPlataform
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                PortableExecutableKinds p;
                ImageFileMachine machineInfo;
                assembly.ManifestModule.GetPEKind(out p, out machineInfo);

                return machineInfo;
            }
        }

        public static OSVersion GetOSVersion()
        {
            //var versionString = (string)Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion").GetValue("productName");
            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;
            OSVersion operatingSystem = OSVersion.Unknown;

            if (os.Platform == PlatformID.Win32Windows)
            {
                switch (vs.Minor)
                {
                    case 0: operatingSystem = OSVersion.Windows_95; break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = OSVersion.Windows_98SE;
                        else
                            operatingSystem = OSVersion.Windows_98;
                        break;
                    case 90: operatingSystem = OSVersion.Windows_ME; break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3: operatingSystem = OSVersion.Windows_NT3; break;
                    case 4: operatingSystem = OSVersion.Windows_NT4; break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = OSVersion.Windows_2000;
                        else
                            operatingSystem = OSVersion.Windows_XP; break;
                    case 6:
                        switch (vs.Minor)
                        {
                            case 0: operatingSystem = OSVersion.Windows_Vista; break;
                            case 1: operatingSystem = OSVersion.Windows_7; break;
                            case 2: operatingSystem = OSVersion.Windows_8; break;
                            default: operatingSystem = OSVersion.Windows_8_1; break;
                        }
                        break;
                    case 10:
                        operatingSystem = OSVersion.Windows_10;
                        break;
                }
            }
            return operatingSystem;
        }

        public static void Start()
        {
            StartGarbageCollect();
        }

        public static void Exit()
        {
            Application.Exit();
            Environment.Exit(0);
        }

        #region Lock to 1 Execution only
        public static void SingleProcess(bool locked, Mutex singleton)
        {
            if (!singleton.WaitOne(TimeSpan.Zero, true) && locked)
            {
                //there is already another instance running!
                MessageBox.Show("Esse programa já esta sendo executado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Exit();
            }
        }
        #endregion

        #region Minimize RAM usage
        [DllImport("psapi.dll")]
        static extern int EmptyWorkingSet(IntPtr hwProc);

        static System.Windows.Forms.Timer tmrGarbage = new System.Windows.Forms.Timer();

        static void StartGarbageCollect()
        {
            tmrGarbage.Interval = 50;
            tmrGarbage.Tick += CollectGarbage;
            tmrGarbage.Start();
        }

        static void CollectGarbage(object source, EventArgs e)
        {
            GC.Collect();
            EmptyWorkingSet(Process.GetCurrentProcess().Handle);
        }
        #endregion
    }
}