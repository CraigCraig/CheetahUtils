/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahUtils;

using System.Runtime.Versioning;

public static class ConsoleUtils
{
    public enum ColorType : int
    {
        FOREGROUND = 38,
        BACKGROUND = 48
    }

    [SupportedOSPlatform("windows")]
    public static void AppendTitle(string value) => Console.Title = $"{Console.Title} {value}";

    public static void SetColor(ColorType type, Color color)
    {
        switch (type)
        {
            case ColorType.FOREGROUND:
                Console.Write(ForegroundColor(color));
                break;
            case ColorType.BACKGROUND:
                Console.Write(BackgroundColor(color));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    public static string ForegroundColor(Color color) => $"\x1b[{38};2;{color.R};{color.G};{color.B}m";

    public static string BackgroundColor(Color color) => $"\x1b[{48};2;{color.R};{color.G};{color.B}m";
}
#endif