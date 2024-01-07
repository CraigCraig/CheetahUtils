/// ======================================================================
///		CheetahUtils: (https://github.com/CraigCraig/CheetahUtils)
///				Project:  Craig's CheetahUtils a Collection of C# Utils
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils;

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

    public override int GetHashCode() => HashCode.Combine(X, Y);

    // Override Add Operator
    public static Vector2i operator +(Vector2i a, Vector2i b) => new(a.X + b.X, a.Y + b.Y);

    // Override Subtract Operator
    public static Vector2i operator -(Vector2i a, Vector2i b) => new(a.X - b.X, a.Y - b.Y);

    public static bool operator ==(Vector2i? left, Vector2i? right) => EqualityComparer<Vector2i>.Default.Equals(left, right);

    public static bool operator !=(Vector2i? left, Vector2i? right) => !(left == right);
}