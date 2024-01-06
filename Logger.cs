/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils;

#region Usings
using System.Diagnostics;
using System.Runtime.CompilerServices;
#endregion

/// <summary>
/// Logger class for CheetahUtils
/// </summary>
public class Logger
{
    public LogLevel Level { get; set; }
    public string Prefix;

    private static readonly string _folderPath = $@"{Environment.CurrentDirectory}\Logs";
    private static readonly string _logPath = $@"{_folderPath}\latest.log";
    private static readonly string _oldLogPath = $"{_folderPath}{$@"\old_{(DateTime.Now - DateTime.MinValue).TotalMilliseconds}.log"}";

    public Logger(string? prefix, LogLevel level = LogLevel.WARNING)
    {
        Level = level;
        Prefix = prefix ?? "N/A";

        if (!Directory.Exists(_folderPath)) _ = Directory.CreateDirectory(_folderPath);
        if (File.Exists(_logPath)) File.Move(_logPath, _oldLogPath);

        Write($"Logger for {Prefix} initialized..");
    }

    public enum LogLevel
    {
        SUPER,
        NONE,
        ERROR,
        ATTENTION,
        WARNING,
        INFO,
        DEBUG,
        FINE,
    }

    /// <summary>
    /// Opens the latest log file in Notepad
    /// </summary>
    public void OpenLatestLogFile()
    {
        try
        {
            _ = Process.Start(_logPath);
        }
        catch (Exception e)
        {
            Error($"Failed to open Log: {e.Message} - {_logPath}");
        }
    }

    /// <summary>
    /// Writes an <see cref="Exception"/> to the logger as <see cref="LogLevel.ERROR"/>
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="code"></param>
    /// <param name="name"></param>
    /// <param name="line"></param>
    public void Exception<T>(T ex, string code = "", [CallerMemberName] string name = "", [CallerLineNumber] int line = -1)
    {
        Write($"[{name}] [{line}] An Exception Occurred -> {ex?.GetType()}", LogLevel.ERROR);
        if (!string.IsNullOrEmpty(code))
            Write($"Error Code: {code}");
        Write($"");
        if ((ex as Exception) != null)
        {
            string? message = (ex as Exception)?.Message;
            string? stackTrace = (ex as Exception)?.StackTrace;
            System.Reflection.MethodBase? targetSite = (ex as Exception)?.TargetSite;
            string? source = (ex as Exception)?.Source;
            if (message != null)
                Write($"Exception Message: {message}", LogLevel.ERROR);

            if (stackTrace != null)
                Write($"Exception StackTrace: {stackTrace}", LogLevel.ERROR);

            if (targetSite != null)
                Write($"Exception TargetSite: {targetSite}", LogLevel.ERROR);

            if (source != null)
                Write($"Exception Source: {source}", LogLevel.ERROR);
        }
        else
        {
            Write($"Exception Was Null!", LogLevel.ERROR);
        }
    }

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.ERROR"/>
    /// </summary>
    /// <param name="line"></param>
    public void Error(string msg, [CallerMemberName] string name = "", [CallerLineNumber] int line = -1)
    {
        Write($"An Error Occurred");
        Write($"CallerName: {name}", LogLevel.ERROR);
        Write($"CallerLine: {line}", LogLevel.ERROR);
        Write($"{msg}", LogLevel.ERROR);
    }

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.ERROR"/>
    /// This particular method does not use the <see cref="CallerMemberName"/> and <see cref="CallerLineNumber"/> attributes
    /// </summary>
    /// <param name="msg"></param>
    public void ErrorNoCall(string msg) => Write(!string.IsNullOrEmpty(msg) ? $"An Error Occurred: {msg}" : $"An Error Occurred");

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.FINE"/>
    /// </summary>
    /// <param name="line"></param>
    public void Fine(string line) => Write($"{line}", Color.Grey, LogLevel.FINE);

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.SUPER"/> if client is in Super mode
    /// </summary>
    /// <param name="line"></param>
    public void Super(string line) =>
            //if (Config.Data.Logger.Super)
            Write($"{line}", Color.Grey, LogLevel.SUPER);

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.SUPER"/> if client is in Super mode
    /// </summary>
    /// <param name="line"></param>
    public void Super(string line, Color color) =>
            //if (Config.Data.Logger.Super)
            Write($"{line}", color, LogLevel.SUPER);

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.INFO"/>
    /// </summary>
    /// <param name="line"></param>
    public void Info(string line) => Write($"{line}", Color.Grey, LogLevel.INFO);

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.ATTENTION"/>
    /// </summary>
    /// <param name="line"></param>
    public void Attention(string line) => Write($"{line}", Color.CheetoYellow, LogLevel.ATTENTION);

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.DEBUG"/>
    /// </summary>
    /// <param name="line"></param>
    public void Debug(string line) => Write($"{line}", Color.White, LogLevel.DEBUG);

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.DEBUG"/>
    /// </summary>
    /// <param name="line"></param>
    /// <param name="color"></param>
    public void Debug(string line, System.Drawing.Color color) => Write($"{line}", new Color(color.R, color.G, color.B), LogLevel.DEBUG);

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.DEBUG"/>
    /// </summary>
    /// <param name="line"></param>
    public void Debug(string line, Color color) => Write($"{line}", color, LogLevel.DEBUG);

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.WARNING"/>
    /// </summary>
    /// <param name="line"></param>
    public void Warn(string line) => Write($"{line}", LogLevel.WARNING);

    /// <summary>
    /// Logs "----------------------" to the logger.
    /// </summary>
    public void Bars()
    {
        Write(string.Empty, Color.Black, noNewline: true);
        for (int i = 0; i < 16; i++)
        {
            Append("-", Color.Random);
        }
        Append(Environment.NewLine, Color.Black);
    }

    /// <summary>
    /// Writes a line to the logger.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="level"></param>
    public void Write(string message, LogLevel level = LogLevel.INFO) => Write(message, Color.White, level);

    /// <summary>
    /// Writes a line to the logger, with a specific <see cref="System.Drawing.Color"/>.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    /// <param name="level"></param>
    public void Write(string message, System.Drawing.Color color, LogLevel level = LogLevel.INFO) => Write(message, new Color(color.R, color.G, color.B), level);

    public void Append(string message, Color? color)
    {
        Color lcolor = color ?? Color.White;
        Write(message, lcolor, append: true);
    }

    /// <summary>
    /// Writes a line to the logger, with a specific <see cref="Color"/>.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    /// <param name="level"></param>
    public void Write(string message, Color color, LogLevel level = LogLevel.INFO, bool append = false, bool noNewline = false)
    {
        if (append)
        {
            PublicWrite(message, color);
        }
        else
        {
            if (Level >= level)
            {
                Color lcolor = Color.White;
                if (level == LogLevel.SUPER)
                    lcolor = Color.Html.Teal;
                if (level == LogLevel.FINE)
                    lcolor = Color.Html.Olive;
                if (level == LogLevel.INFO)
                    lcolor = Color.Html.Gray;
                if (level == LogLevel.DEBUG)
                    lcolor = Color.CheetoYellow;
                if (level == LogLevel.ATTENTION)
                    lcolor = Color.Crayola.Original.RosePink;
                if (level == LogLevel.WARNING)
                    lcolor = Color.Crayola.Original.Yellow;
                if (level == LogLevel.ERROR)
                    lcolor = Color.Crayola.Original.Red;

                CultureInfo ci = CultureInfo.InvariantCulture;
                PublicWrite($"[", Color.Random);
                PublicWrite($"{DateTime.Now.ToString("hh:mm:ss.fff", ci)}", Color.Crayola.Present.BananaMania);
                PublicWrite($"] ", Color.Random);

                PublicWrite($"[", Color.Random);
                PublicWrite($"CheetoClient", Color.CheetoOrange);
                PublicWrite($"] ", Color.Random);

                PublicWrite($"[", Color.Random);
                PublicWrite($"{Enum.GetName(typeof(LogLevel), level)}", lcolor);
                PublicWrite($"] ", Color.Random);
                PublicWriteLine(message, color, noNewline);
            }
        }
    }

    private static void PublicWriteLine(string message, Color color, bool noNewline = false)
    {
        if (noNewline)
        {
            PublicWrite(message, color);
        }
        else
        {
            PublicWrite(message + Environment.NewLine, color);
        }
    }

    private static void PublicWrite(string message, Color color)
    {
        Console.Write($"{ConsoleUtils.ForegroundColor(color)}{message}");
        File.AppendAllText(_logPath, message);
    }
}