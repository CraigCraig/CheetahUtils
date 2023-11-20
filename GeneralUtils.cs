namespace CheetahUtils;

using System;

/// <summary>
/// Utilities that don't have their own category yet, they may be moved in the future.
/// </summary>
public static class GeneralUtils
{
	/// <summary>
	/// Swaps the endianness of a 32-bit integer.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static ushort SwapEndianness(ushort value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse(bytes);
		return BitConverter.ToUInt16(bytes, 0);
	}

	/// <summary>
	/// Swaps the endianness of a 32-bit integer.
	/// </summary>
	public static ulong SwapEndianness(ulong value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse(bytes);
		return BitConverter.ToUInt64(bytes, 0);
	}

	/// <summary>
	/// Gets the percentage of a number.
	/// </summary>
	/// <param name="cur">The current number.</param>
	/// <param name="max">The maximum number.</param>
	/// <returns>The percentage of the number.</returns>
	public static int GetPercent(int cur, int max)
	{
		return cur / max * 100;
	}
}