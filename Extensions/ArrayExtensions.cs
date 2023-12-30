namespace CheetahUtils.Extensions;

public static class ArrayExtensions
{
	public static string[] ToUpperCase(this string[] list)
	{
		for (int i = 0; i < list.Length; i++)
		{
			list[i] = list[i].ToUpper();
		}
		return list;
	}

	public static string[] ToLowerCase(this string[] list)
	{
		for (int i = 0; i < list.Length; i++)
		{
			list[i] = list[i].ToLower();
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