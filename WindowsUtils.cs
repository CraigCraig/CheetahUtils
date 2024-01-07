/// ======================================================================
///		CheetahUtils: (https://github.com/CraigCraig/CheetahUtils)
///				Project:  Craig's CheetahUtils a Collection of C# Utils
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahUtils;

using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Principal;

public static class WindowsUtils
{
    [SupportedOSPlatform("WINDOWS")]
    public static bool IsRunningAsAdmin()
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    public static bool IsWin11()
    {
        try
        {
            RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (key != null)
            {
                int osBuild = Convert.ToInt32(key.GetValue("CurrentBuildNumber"));
                if (osBuild >= 21996)
                {
                    return true;
                }
            }
        }
        catch { }
        return false;
    }

    public static string GetVersion()
    {
        RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
        if (key != null)
        {
            string? UBR = key?.GetValue("UBR")?.ToString();
            string? CurrentBuild = key?.GetValue("CurrentBuild")?.ToString();

            if (!string.IsNullOrEmpty(UBR) && !string.IsNullOrEmpty(CurrentBuild))
            {
                string version = CurrentBuild + "." + UBR;

                return "Build " + version;
            }
        }

        return "N/A";
    }

    private const string Kernel32 = "kernel32.dll";
    private const string User32 = "user32.dll";

    [DllImport(User32)]
    internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport(User32)]
    internal static extern IntPtr GetForegroundWindow();

    [DllImport(Kernel32, EntryPoint = "GetVersion", SetLastError = true)]
    internal static extern int GetVersion2();

    [DllImport(Kernel32, EntryPoint = "SetConsoleMode", SetLastError = true)]
    internal static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

    [DllImport(Kernel32, EntryPoint = "GetConsoleMode", SetLastError = true)]
    internal static extern bool GetConsoleMode(IntPtr handle, out int mode);

    internal static void Initialize()
    {
        IntPtr handle = GetStdHandle(-11);
        _ = GetConsoleMode(handle, out int mode);
        _ = SetConsoleMode(handle, mode | 0x4);
    }

    [DllImport(Kernel32, EntryPoint = "GetStdHandle", SetLastError = true)]
    internal static extern IntPtr GetStdHandle(int handle);

    [DllImport(User32)]
    internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    private static IntPtr _handle;

    /// <summary>
    /// Gets or sets whether the console should be shown.
    /// </summary>
    /// <param name="flag"></param>
    internal static void ShowConsole(bool flag)
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        _handle = GetStdHandle(-11);
        _ = flag ? ShowWindow(_handle, SW_SHOW) : ShowWindow(_handle, SW_HIDE);
    }

    /// <summary>
    /// Gets or sets the console mode.
    /// </summary>
    internal static int ConsoleMode
    {
        get
        {
            _ = GetConsoleMode(_handle, out int mode);
            return mode;
        }
        set => SetConsoleMode(_handle, value);
    }
}
#endif