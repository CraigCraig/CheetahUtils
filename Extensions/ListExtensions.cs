namespace CheetahUtils.Extensions;
public static class ListExtensions
{
    public static List<string> ToUpperCase(this List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToUpperInvariant();
        }
        return list;
    }

    public static List<string> ToLowerCase(this List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLowerInvariant();
        }
        return list;
    }

    public static List<string> ToTitleCase(this List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToTitleCase();
        }
        return list;
    }

    public static List<string> Shuffle(this List<string> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = new Random().Next(n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }
        return list;
    }
}