using System;
using System.Linq;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
//

namespace GNX
{
    public class cApp
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
                Assembly assembly = Assembly.GetExecutingAssembly();
                PortableExecutableKinds p;
                ImageFileMachine machineInfo;
                assembly.ManifestModule.GetPEKind(out p, out machineInfo);

                return machineInfo;
            }
        }

        public static OSVersion GetOSVersion()
        {
            //var versionString = (string)Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion").GetValue("productName");
            OperatingSystem os = System.Environment.OSVersion;
            Version vs = os.Version;
            OSVersion operatingSystem = OSVersion.Unknown;

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = OSVersion.Windows_95;
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = OSVersion.Windows_98SE;
                        else
                            operatingSystem = OSVersion.Windows_98;
                        break;
                    case 90:
                        operatingSystem = OSVersion.Windows_ME;
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = OSVersion.Windows_NT3;
                        break;
                    case 4:
                        operatingSystem = OSVersion.Windows_NT4;
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = OSVersion.Windows_2000;
                        else
                            operatingSystem = OSVersion.Windows_XP;
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = OSVersion.Windows_Vista;
                        else if (vs.Minor == 1)
                            operatingSystem = OSVersion.Windows_7;
                        else if (vs.Minor == 2)
                            operatingSystem = OSVersion.Windows_8;
                        else
                            operatingSystem = OSVersion.Windows_8_1;
                        break;
                    case 10:
                        operatingSystem = OSVersion.Windows_10;
                        break;
                    default:
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

        #region Language
        private static CultureInfo Language;
        private static RegionInfo Country;

        public static void SetLanguage(CultureID name)
        {
            int CultureName = Convert.ToInt32(name);
            //Language = CultureInfo.GetCultureInfo(CultureName);

            Language = new CultureInfo(CultureName);

            //Change Culture Info Month names.
            Language.DateTimeFormat.MonthNames = Language.DateTimeFormat.MonthNames.Select(m => Language.TextInfo.ToTitleCase(m)).ToArray();
            Language.DateTimeFormat.MonthGenitiveNames = Language.DateTimeFormat.MonthGenitiveNames.Select(m => Language.TextInfo.ToTitleCase(m)).ToArray();
            Language.DateTimeFormat.AbbreviatedMonthNames = Language.DateTimeFormat.AbbreviatedMonthNames.Select(m => Language.TextInfo.ToTitleCase(m)).ToArray();

            //Culture for any thread
            CultureInfo.DefaultThreadCurrentCulture = Language;

            //Culture for UI in any thread
            CultureInfo.DefaultThreadCurrentUICulture = Language;

            Country = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
        }

        public static string CurrencySymbol
        {
            get { return Language.NumberFormat.CurrencySymbol; }
        }

        public static string CurrencyDecimalSeparator
        {
            get { return Language.NumberFormat.CurrencyDecimalSeparator; }
        }

        public static string NumberDecimalSeparator
        {
            get { return Language.NumberFormat.NumberDecimalSeparator; }
        }

        public static string CurrencyGroupSeparator
        {
            get { return Language.NumberFormat.CurrencyGroupSeparator; }
        }
        #endregion

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
        private static extern int EmptyWorkingSet(IntPtr hwProc);

        private static System.Windows.Forms.Timer tmrGarbage = new System.Windows.Forms.Timer();

        private static void StartGarbageCollect()
        {
            tmrGarbage.Interval = 50;
            tmrGarbage.Tick += new EventHandler(CollectGarbage);
            tmrGarbage.Start();
        }

        private static void CollectGarbage(object source, EventArgs e)
        {
            GC.Collect();
            EmptyWorkingSet(Process.GetCurrentProcess().Handle);
        }
        #endregion
    }
}
