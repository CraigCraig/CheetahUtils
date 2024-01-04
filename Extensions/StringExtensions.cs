/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils.Extensions;

public static class StringExtensions
{
    public static string ToTitleCase(this string str)
    {
        string[] words = str.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = $"{words[i][..1].ToUpperInvariant()}{words[i][1..].ToLowerInvariant()}";
        }
        return string.Join(' ', words);
    }
}