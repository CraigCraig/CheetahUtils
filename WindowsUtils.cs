namespace CheesyUtils;

using System.Runtime.Versioning;

/// <summary>
/// Some utilities for Windows.
/// </summary>
public static class WindowsUtils
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
}