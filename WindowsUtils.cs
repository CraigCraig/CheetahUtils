#if WINDOWS
namespace CheetahUtils;

using System.Runtime.Versioning;
using System.Security.Principal;

public static class WindowsUtils
{
	[SupportedOSPlatform("windows")]
	public static bool IsAdministrator()
	{
		var identity = WindowsIdentity.GetCurrent();
		var principal = new WindowsPrincipal(identity);
		return principal.IsInRole(WindowsBuiltInRole.Administrator);
	}
}
#endif