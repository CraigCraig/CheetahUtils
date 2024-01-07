/// ======================================================================
///		CheetahUtils: (https://github.com/CraigCraig/CheetahUtils)
///				Project:  Craig's CheetahUtils a Collection of C# Utils
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS || EDITOR
namespace CheetahUtils;

public static class FileUtils
{
    public static bool IsSymbolic(string path)
    {
        FileInfo pathInfo = new(path);
        return pathInfo.Attributes.HasFlag(FileAttributes.ReparsePoint);
    }
}
#endif