namespace CheeseyUtils;

public static class Log
{
    public static void WriteLine(string line)
    {
        System.Console.WriteLine($"{Colors.White}{line}{Colors.White}");
    }
}
