/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils;

using System;

internal static class Randomizer
{
    private static readonly Random _random = new();

    /// <summary>
    /// Returns a non negative byte that is less than the specified maximum
    /// </summary>
    /// <param name="max"></param>
    /// <returns></returns>
    internal static byte Byte(byte max) => Convert.ToByte(_random.Next(max));

    internal static float Float()
    {
        Random rand = new();
        const double range = (double)float.MaxValue - float.MinValue;
        double sample = rand.NextDouble();
        double scaled = (sample * range) + float.MinValue;
        return (float)scaled;
    }
}