namespace CheetahUtils;

using System.Text;
using CliWrap;

public static class Terminal
{
	public static string Execute(string command, string[] args)
	{
		StringBuilder sb = new();
		var c = Cli.Wrap(command).WithArguments(args)
			.WithStandardErrorPipe(PipeTarget.ToDelegate((s) => sb.AppendLine(s)))
			.WithStandardOutputPipe(PipeTarget.ToDelegate((s) => sb.AppendLine(s)));

		var result = c.ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
		return sb.ToString();
	}
}