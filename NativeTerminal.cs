/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils;

using CliWrap;

public static class NativeTerminal
{
    /// <summary>
    /// Executes a command in the native terminal
    /// </summary>
    /// <param name="command"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string? Execute(string command, string[] args)
    {
        try
        {
            StringBuilder sb = new();
            Command c = Cli.Wrap(command).WithArguments(args)
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