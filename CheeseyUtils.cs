namespace CheesyUtils;

using System;

/// <summary>
/// Class specific to CheesyUtils.
/// </summary>
public static class CheesyUtils
{
    /// <summary>
    /// The version of CheesyUtils.
    /// </summary>
    public static Version? Version => typeof(CheesyUtils).Assembly.GetName().Version ?? throw new NullReferenceException("Version is null");
}