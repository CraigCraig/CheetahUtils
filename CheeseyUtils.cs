﻿namespace CheeseyUtils;

/// <summary>
/// Class specific to CheeseyUtils.
/// </summary>
public static class CheeseyUtils
{
    /// <summary>
    /// The version of CheeseyUtils.
    /// </summary>
    public static Version Version { get; } = new(1, 0, 0, 0, 0, Version.ReleaseChannel.Development);

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