namespace CheeseyUtils.Extensions;

public static class Strings
{
    public static string ToTitleCase(this string str)
    {
        string[] words = str.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = $"{words[i][..1].ToUpper()}{words[i][1..].ToLower()}";
        }
        return string.Join(' ', words);
    }
}