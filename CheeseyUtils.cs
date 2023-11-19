namespace CheeseyUtils;

using System.Reflection;

/// <summary>
/// Class specific to CheeseyUtils.
/// </summary>
public static class CheeseyUtils
{
    /// <summary>
    /// The version of CheeseyUtils.
    /// Note:
    /// Returns 0.0 if Version is null, this should never happen.
    /// However
    /// </summary>
    public static Version Version { get; } = Assembly.GetEntryAssembly()?.GetName().Version ?? new(0, 0);

    /// <summary>
    /// Author of CheeseyUtils.
    /// </summary>
    public static string Author { get; } = "Craig Craig";

    /// <summary>
    /// Description of CheesyUtils.
    /// </summary>
    public static string Description { get; } = "A collection of utilities for .NET 8.0";

    /// <summary>
    /// Repository of CheeseyUtils.
    /// </summary>
    public static string Repository { get; } = "https://github.com/CraigCriag/CheeseyUtils";
}