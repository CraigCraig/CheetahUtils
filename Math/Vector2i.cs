namespace CheesyUtils.Math;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents a 2D vector with X and Y components.
/// </summary>
public class Vector2i : IEquatable<Vector2i?>
{
    public int X;
    public int Y;

    public Vector2i(int f)
    {
        X = Y = f;
    }

    public Vector2i(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Vector2i(int[] v2)
    {
        X = v2[0];
        Y = v2[1];
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Vector2i);
    }

    public bool Equals(Vector2i? other)
    {
        return other != null &&
               X == other.X &&
               Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override string? ToString()
    {
        return $"{X},{Y}";
    }

    public static float Dot(Vector2i u, Vector2i v)
    {
        return (u.X * v.X) + (u.Y * v.Y);
    }

    public static Vector2i Negate(Vector2i v)
    {
        return new Vector2i(-v.X, -v.Y);
    }

    public static bool operator ==(Vector2i? left, Vector2i? right)
    {
        return EqualityComparer<Vector2i>.Default.Equals(left, right);
    }

    public static bool operator !=(Vector2i? left, Vector2i? right)
    {
        return !(left == right);
    }

    public static Vector2i operator +(Vector2i left, Vector2i right)
    {
        return new Vector2i(left.X + right.X, left.Y + right.Y);
    }

    public static Vector2i operator -(Vector2i left, Vector2i right)
    {
        return new Vector2i(left.X - right.X, left.Y - right.Y);
    }

    public static Vector2i operator /(Vector2i left, Vector2i right)
    {
        return new Vector2i(left.X / right.X, left.Y / right.Y);
    }

    public static Vector2i operator *(Vector2i left, Vector2i right)
    {
        return new Vector2i(left.X * right.X, left.Y * right.Y);
    }

    public static implicit operator Vector2f(Vector2i v)
    {
        return new Vector2f(v.X, v.Y);
    }

    public static readonly Vector2i Zero = new(0, 0);
    public static readonly Vector2i Max = new(int.MaxValue, int.MaxValue);
}
