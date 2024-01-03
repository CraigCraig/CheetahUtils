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