namespace CheesyUtils.Math;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents a 2D vector with X and Y components.
/// </summary>
public class Vector2f : IEquatable<Vector2f?>
{
    public float X;
    public float Y;

    public Vector2f(float f)
    {
        X = Y = f;
    }

    public Vector2f(float x, float y)
    {
        X = x;
        Y = y;
    }

    public Vector2f(float[] v2)
    {
        X = v2[0];
        Y = v2[1];
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Vector2f);
    }

    public bool Equals(Vector2f? other)
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

    public static float Dot(Vector2f u, Vector2f v)
    {
        return u.X * v.X + u.Y * v.Y;
    }

    public static Vector2f Negate(Vector2f v)
    {
        return new Vector2f(-v.X, -v.Y);
    }

    public static bool operator ==(Vector2f? left, Vector2f? right)
    {
        return EqualityComparer<Vector2f>.Default.Equals(left, right);
    }

    public static bool operator !=(Vector2f? left, Vector2f? right)
    {
        return !(left == right);
    }

    public static Vector2f operator +(Vector2f left, Vector2f right)
    {
        return new Vector2f(left.X + right.X, left.Y + right.Y);
    }

    public static Vector2f operator -(Vector2f left, Vector2f right)
    {
        return new Vector2f(left.X - right.X, left.Y - right.Y);
    }

    public static Vector2f operator /(Vector2f left, Vector2f right)
    {
        return new Vector2f(left.X / right.X, left.Y / right.Y);
    }

    public static Vector2f operator *(Vector2f left, Vector2f right)
    {
        return new Vector2f(left.X * right.X, left.Y * right.Y);
    }

    public static readonly Vector2f Zero = new(0, 0);
    public static readonly Vector2f Max = new(float.MaxValue, float.MaxValue);
}
