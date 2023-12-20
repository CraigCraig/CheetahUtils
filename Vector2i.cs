namespace CheetahUtils;

using System;
using System.Collections.Generic;

public class Vector2i(int x = 0, int y = 0)
{
	public int X = x;
	public int Y = y;

	public override bool Equals(object? obj)
	{
		return obj is Vector2i i &&
			   X == i.X &&
			   Y == i.Y;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y);
	}

	// Override Add Operator
	public static Vector2i operator +(Vector2i a, Vector2i b)
	{
		return new Vector2i(a.X + b.X, a.Y + b.Y);
	}

	// Override Subtract Operator
	public static Vector2i operator -(Vector2i a, Vector2i b)
	{
		return new Vector2i(a.X - b.X, a.Y - b.Y);
	}

	public static bool operator ==(Vector2i? left, Vector2i? right)
	{
		return EqualityComparer<Vector2i>.Default.Equals(left, right);
	}

	public static bool operator !=(Vector2i? left, Vector2i? right)
	{
		return !(left == right);
	}
}