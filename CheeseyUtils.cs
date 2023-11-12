namespace CheeseyUtils;

/// <summary>
/// Class specific to CheesyUtils.
/// </summary>
public static class CheesyUtils
{
    /// <summary>
    /// The version of CheesyUtils.
    /// </summary>
    public static Version Version { get; } = new(1, 0, 0, 0, 0, Version.ReleaseChannel.Development);

    /// <summary>
    /// Author of CheesyUtils.
    /// </summary>
    public static string Author { get; } = "Craig Craig";

    /// <summary>
    /// Description of CheesyUtils.
    /// </summary>
    public static string Description { get; } = "A collection of utilities for .NET 8.0";

    /// <summary>
    /// Repository of CheesyUtils.
    /// </summary>
    public static string Repository { get; } = "https://github.com/CraigCriag/CheeseyUtils";
}