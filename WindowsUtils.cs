#if WINDOWS || EDITOR
namespace CheetahUtils;

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
}

public static class FileUtils
{
    public static bool IsSymbolic(string path)
    {
        FileInfo pathInfo = new(path);
        return pathInfo.Attributes.HasFlag(FileAttributes.ReparsePoint);
    }
}

public static class ShortcutUtils
{
    /// <summary>
    /// WIP: Checks if a Shortcut has a valid target
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool IsValid(string path) => false;

    private sealed class NativeMethods
    {
        [DllImport("msi.dll", CharSet = CharSet.Auto)]
        public static extern uint MsiGetShortcutTarget(string targetFile, StringBuilder productCode, StringBuilder featureID, StringBuilder componentCode);

        [DllImport("msi.dll", CharSet = CharSet.Auto)]
        public static extern InstallState MsiGetComponentPath(string productCode, string componentCode, StringBuilder componentPath, ref int componentPathBufferSize);

        public const int MaxFeatureLength = 38;
        public const int MaxGuidLength = 38;
        public const int MaxPathLength = 1024;

        public enum InstallState
        {
            NotUsed = -7,
            BadConfig = -6,
            Incomplete = -5,
            SourceAbsent = -4,
            MoreData = -3,
            InvalidArg = -2,
            Unknown = -1,
            Broken = 0,
            Removed = 1,
            Absent = 2,
            Local = 3,
            Source = 4,
            Default = 5
        }
    }
}

#endif