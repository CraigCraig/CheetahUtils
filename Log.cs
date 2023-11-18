namespace CheeseyUtils;

public static class Log
{
    private static string _logFile = $"{Environment.CurrentDirectory}latest.log";
    private static bool _initialized = false;
    private static readonly List<string> _buffer = [];

    private static void Initialize()
    {
        SetPath(_logFile);
        Task task = Task.Run(() =>
        {
            _buffer.Add("Logger Initialized");
            while (true)
            {
                lock (_buffer)
                {
                    while (_buffer.Count > 0)
                    {
                        File.AppendAllText(_logFile, _buffer[0]);
                        Console.WriteLine(_buffer[0]);
                        _buffer.RemoveAt(0);
                    }
                }
                Thread.Sleep(1);
            }
        });

        _initialized = true;
    }

    public static void SetPath(string path)
    {
        _logFile = path;
        if (!File.Exists(_logFile))
        {
            _ = File.Create(_logFile);
        }
        else
        {
            File.Delete(_logFile);
            _ = File.Create(_logFile);
        }
        _buffer.Add($"LogFile: {_logFile}");
    }

    public static void WriteLine(string line)
    {
        InternalWrite($"line{Environment.NewLine}");
    }

    private static void InternalWrite(string line)
    {
        if (!_initialized)
        {
            Initialize();
        }

        lock (_buffer)
        {
            _buffer.Add(line);
        }
    }
}