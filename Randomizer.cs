/// ======================================================================
///		CheetahUtils: (https://github.com/CraigCraig/CheetahUtils)
///				Project:  Craig's CheetahUtils a Collection of C# Utils
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils;

using System;

internal static class Randomizer
{
    /// <summary>
    /// Returns a non negative byte that is less than the specified maximum
    /// </summary>
    /// <param name="max"></param>
    /// <returns></returns>
    internal static byte Byte(byte max) => Convert.ToByte(Random.Shared.Next(max));

    internal static float Float()
    {
        Random rand = new();
        const double range = (double)float.MaxValue - float.MinValue;
        double sample = rand.NextDouble();
        double scaled = (sample * range) + float.MinValue;
        return (float)scaled;
    }
}