/// ======================================================================
///		CheetahUtils: (https://github.com/CraigCraig/CheetahUtils)
///				Project:  Craig's CheetahUtils a Collection of C# Utils
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils.Exceptions;

using System.Collections;

public class ExecutionException : Exception
{
    public override IDictionary Data => base.Data;

    public override string? HelpLink { get => base.HelpLink; set => base.HelpLink = value; }

    public override string Message => base.Message;

    public override string? Source { get => base.Source; set => base.Source = value; }

    public override string? StackTrace => base.StackTrace;

    public override bool Equals(object? obj) => base.Equals(obj);
    public override Exception GetBaseException() => base.GetBaseException();
    public override int GetHashCode() => base.GetHashCode();
    public override string ToString() => base.ToString();
}