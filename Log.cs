namespace CheetahUtils;

public static class Log
{
    /// <summary>
    /// Sets whether or not the logger prints the lines to the console
    /// </summary>
    public static bool PrintToConsole { get; set; }

    private static readonly string logFile = Path.Combine($"{Environment.CurrentDirectory}", "latest.log");

    public static void Clear()
    {
        if (PrintToConsole) Console.Clear();
        if (File.Exists(logFile))
        {
            File.Delete(logFile);
        }
    }

    public static void Write(string line) => InternalWrite($"{line}");

    private static void InternalWrite(string line)
    {
        if (PrintToConsole) Console.WriteLine(line);
        StreamWriter fs = File.AppendText(logFile);
        fs.WriteLine(line);
        fs.Flush();
        fs.Close();
    }
}