namespace CheeseyUtils.Extensions;

public static class Strings
{
    public static string ToTitleCase(this string str)
    {
        string[] words = str.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
        }
        return string.Join(' ', words);
    }
}