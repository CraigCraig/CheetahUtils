/// ======================================================================
///		CheetahUtils: (https://github.com/CraigCraig/CheetahUtils)
///				Project:  Craig's CheetahUtils a Collection of C# Utils
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils;

using CliWrap;

public static class TerminalUtils
{

    /// <summary>
    /// Executes a command in PowerShell
    /// </summary>
    /// <param name="command"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string? PowerShell(string command)
    {
        try
        {
            string[] args = command.Split(" ");
            StringBuilder sb = new();
            Command c = Cli.Wrap("pwsh").WithArguments(args.Prepend("-Command"))
                .WithValidation(CommandResultValidation.None)
                .WithStandardErrorPipe(PipeTarget.ToDelegate((s) => sb.AppendLine(s)))
                .WithStandardOutputPipe(PipeTarget.ToDelegate((s) => sb.AppendLine(s)));

            CommandResult result = c.ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return sb.ToString();
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Executes a command in cmd
    /// </summary>
    /// <param name="command"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string? Cmd(string command)
    {
        try
        {
            string[] args = command.Split(" ");
            StringBuilder sb = new();
            Command c = Cli.Wrap("cmd").WithArguments(args.Prepend("/c"))
                .WithValidation(CommandResultValidation.None)
                .WithStandardErrorPipe(PipeTarget.ToDelegate((s) => sb.AppendLine(s)))
                .WithStandardOutputPipe(PipeTarget.ToDelegate((s) => sb.AppendLine(s)));

            CommandResult result = c.ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return sb.ToString();
        }
        catch
        {
            return null;
        }
    }
}