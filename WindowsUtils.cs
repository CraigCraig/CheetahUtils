#if WINDOWS || EDITOR
namespace CheetahUtils;

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
}
#endif