namespace CheeseyUtils.Console;

using System;
using System.Runtime.Versioning;

internal static class ConsoleUtils
{
    internal enum ColorType : int
    {
        FOREGROUND = 38,
        BACKGROUND = 48
    }

    [SupportedOSPlatform("windows")]
    internal static void AppendTitle(string value)
    {
        Console.Title = $"{Console.Title} {value}";
    }

    internal static void SetColor(ColorType type, Color color)
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

    internal static string ForegroundColor(Color color) => $"\x1b[{ColorType.FOREGROUND};2;{color.R};{color.G};{color.B}m";

    internal static string BackgroundColor(Color color) => $"\x1b[{ColorType.BACKGROUND};2;{color.R};{color.G};{color.B}m";
}