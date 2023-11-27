namespace CheetahUtils;

public static class Log
{
	private static readonly string logFile = Path.Combine($"{Environment.CurrentDirectory}", "latest.log");

	public static void Clear()
	{
		if (File.Exists(logFile))
		{
			File.Delete(logFile);
		}
	}

	public static void Write(string line)
	{
		InternalWrite($"{line}");
	}

	private static void InternalWrite(string line)
	{
        StreamWriter fs = File.AppendText(logFile);
		fs.WriteLine(line);
		fs.Flush();
		fs.Close();
	}
}