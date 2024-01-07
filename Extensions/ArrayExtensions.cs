/// ======================================================================
///		CheetahUtils: (https://github.com/CraigCraig/CheetahUtils)
///				Project:  Craig's CheetahUtils a Collection of C# Utils
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils.Extensions;

public static class ArrayExtensions
{
    public static string[] ToUpperCase(this string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = list[i].ToUpperInvariant();
        }
        return list;
    }

    public static string[] ToLowerCase(this string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = list[i].ToLowerInvariant();
        }
        return list;
    }

    public static string[] ToTitleCase(this string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = list[i].ToTitleCase();
        }
        return list;
    }

    public static string[] Shuffle(this string[] list)
    {
        int n = list.Length;
        while (n > 1)
        {
            n--;
            int k = new Random().Next(n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }
        return list;
    }
}