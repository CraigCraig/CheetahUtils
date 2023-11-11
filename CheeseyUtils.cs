namespace CheesyUtils;

using System;

public static class CheesyUtils
{
    public static Version? Version => typeof(CheesyUtils).Assembly.GetName().Version ?? throw new NullReferenceException("Version is null");
}