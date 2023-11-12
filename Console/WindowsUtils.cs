namespace CheeseyUtils;

using System.Runtime.InteropServices;
using System.Runtime.Versioning;

/// <summary>
/// Some utilities for Windows.
/// </summary>
public static partial class WindowsUtils
{
    /// <summary>
    /// Checks if the program is running as administrator.
    /// </summary>
    /// <returns></returns>
    [SupportedOSPlatform("windows")]
    public static bool IsRunningAsAdmin()
    {
        using var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
        var principal = new System.Security.Principal.WindowsPrincipal(identity);
        return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
    }

    private const string Kernel32 = "kernel32.dll";

    #region kernel32.dll
    [LibraryImport(Kernel32, EntryPoint = "GetVersion", SetLastError = true)]
    internal static partial int GetVersion();

    [LibraryImport(Kernel32, EntryPoint = "SetConsoleMode", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

    [LibraryImport(Kernel32, EntryPoint = "GetConsoleMode", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool GetConsoleMode(IntPtr handle, out int mode);

    [LibraryImport(Kernel32, EntryPoint = "GetStdHandle", SetLastError = true)]
    internal static partial IntPtr GetStdHandle(int handle);
    #endregion

    private const string WinrtString = "api-ms-win-core-winrt-string-l1-1-0.dll";

    #region api-ms-win-core-winrt-string-l1-1-0.dll
    [LibraryImport(WinrtString, EntryPoint = "WindowsCreateString")]
    internal static partial int WindowsCreateString([MarshalAs(UnmanagedType.LPWStr)] string sourceString, int stringLength, out IntPtr hstring);

    [LibraryImport(WinrtString, EntryPoint = "WindowsDeleteString")]
    internal static partial int WindowsDeleteString(IntPtr hstring);
    #endregion

    [LibraryImport("api-ms-win-core-winrt-l1-1-0.dll", EntryPoint = "RoGetActivationFactory")]
    internal static partial int RoGetActivationFactory(IntPtr className, ref Guid guid, out IntPtr instance);
}