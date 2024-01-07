/// ======================================================================
///		CheetahUtils: (https://github.com/CraigCraig/CheetahUtils)
///				Project:  Craig's CheetahUtils a Collection of C# Utils
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils;

/// <summary>
/// A collection of math utilities
/// </summary>
public static class MathUtils
{
    /// <summary>
    /// Clamps a value between a minimum and maximum value
    /// </summary>
    /// <returns>The clamped value</returns>
    public static float Clamp(float value, float min, float max)
    {
        if (value < min) value = min;
        else if (value > max) value = max;
        return value;
    }

    /// <summary>
    /// Clamps a value between a minimum and maximum value
    /// </summary>
    /// <returns>The clamped value</returns>
    public static int Clamp(int value, int min, int max)
    {
        if (value < min)
            value = min;
        else if (value > max)
            value = max;
        return value;
    }

    /// <summary>
    /// Clamps a value between 0 and 1 and returns value
    /// </summary>
    /// <returns>The clamped value</returns>
    public static float Clamp01(float value)
    {
        return value switch
        {
            < 0F => 0F,
            > 1F => 1F,
            _ => value
        };
    }

    /// <summary>
    /// Interpolates between a and b by t.
    /// t is clamped between 0 and 1.
    /// </summary>
    /// <returns>The interpolated value</returns>
    public static float Lerp(float a, float b, float t) => a + ((b - a) * Clamp01(t));

    /// <summary>
    /// Interpolates between a and b by t.
    /// t is NOT clamped.
    /// </summary>
    /// <returns>The interpolated value</returns>
    public static float LerpUnclamped(float a, float b, float t) => a + ((b - a) * t);

    public static float RoundToDigit(float value, int digit)
    {
        float p = (float)Math.Pow(10, digit);
        return (float)Math.Round(value * p) / p;
    }

    public static float FloorToDigit(float value, int digit)
    {
        float p = (float)Math.Pow(10, digit);
        return (float)Math.Floor(value * p) / p;
    }

    public static float CeilingToDigit(float value, int digit)
    {
        float p = (float)Math.Pow(10, digit);
        return (float)Math.Ceiling(value * p) / p;
    }
}
