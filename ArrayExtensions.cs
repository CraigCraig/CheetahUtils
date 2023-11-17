namespace CheeseyUtils;

public static class ArrayExtensions
{
    /// <summary>
    /// Converts all strings in the array to lowercase
    /// </summary>
    /// <param name="list"></param>
    public static void ToLower(this string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    // Add a method to convert all strings in the array to uppercase
    /// <summary>
    /// Converts all strings in the array to uppercase
    /// </summary>
    public static void ToUpper(this string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = list[i].ToUpper();
        }
    }
}