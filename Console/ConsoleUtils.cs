namespace CheeseyUtils.Console;

using System;

internal static class ConsoleUtils
{
    internal enum ColorType : int
    {
        FOREGROUND = 38,
        BACKGROUND = 48
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
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

    internal static string ForegroundColor(Color color) => $"\x1b[{38};2;{color.R};{color.G};{color.B}m";

    internal static string BackgroundColor(Color color) => $"\x1b[{48};2;{color.R};{color.G};{color.B}m";
}