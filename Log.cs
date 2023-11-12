namespace CheeseyUtils;

using System;
using System.Runtime.CompilerServices;
using System.Text;

public static class Log
{
    public static Color DefaultColor { get; set; } = Colors.LightGray;

    public static Level LogLevel { get; set; } = Level.INFO;

    public enum Level
    {
        INFO,
        WARNING,
        ERROR,
        DEBUG,
        FATAL
    }

    public static void Info(string line)
    {
        InternalWriteLine(line, Level.INFO);
    }

    public static void Debug(string line)
    {
        InternalWriteLine(line, Level.DEBUG);
    }

    public static void Warning(string line, [CallerMemberName] string callerName = "")
    {
        line = $"[{callerName}] {Colors.DarkYellow}{line}";
        InternalWriteLine(line, Level.WARNING);
    }

    public static void Error(Exception ex, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
    {
        Error(ex.Message, callerName, callerLine);
    }

    public static void Error(string? line = null, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
    {
        if (!string.IsNullOrEmpty(line))
        {
            line = $"[{callerName}] [{callerLine}] {Colors.DarkYellow}{line}";
            InternalWriteLine(line, Level.ERROR);
        }
    }

    private static void InternalWriteLine(string line, Level level)
    {
        StringBuilder sb = new();
        _ = sb.Append($"{Colors.White}");
        var pcolor = Colors.Gray;
        var lcolor = DefaultColor;

        if (level == Level.ERROR)
        {
            pcolor = Colors.DarkRed;
            lcolor = Colors.LightGray;
        }

        if (level == Level.WARNING)
        {
            pcolor = Colors.DarkYellow;
            lcolor = Colors.LightGray;
        }

        _ = sb.Append($"{Colors.White}[{pcolor}{level}{Colors.White}]{lcolor} ");
        _ = sb.Append(line);
        System.Console.WriteLine(sb);
    }
}
