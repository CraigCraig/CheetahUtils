namespace CheetahUtils;
/// <summary>
/// A class that represents a color.
/// </summary>
public partial class Color
{
	/// <summary>
	/// The red component of the color.
	/// </summary>
	public byte R { get; set; }

	/// <summary>
	/// The green component of the color.
	/// </summary>
	public byte G { get; set; }

	/// <summary>
	/// The blue component of the color.
	/// </summary>
	public byte B { get; set; }

	/// <summary>
	/// The alpha component of the color.
	/// </summary>
	public byte A { get; set; }

	/// <summary>
	/// Creates a new color with the specified components.
	/// </summary>
	/// <param name="r">The red component of the color.</param>
	/// <param name="g">The green component of the color.</param>
	/// <param name="b">The blue component of the color.</param>
	/// <param name="a">The alpha component of the color.</param>
	public Color(byte r, byte g, byte b, byte a)
	{
		R = r;
		G = g;
		B = b;
		A = a;
	}

	/// <summary>
	/// Creates a new color with the specified components and an alpha value of 255.
	/// </summary>
	/// <param name="r">The red component of the color.</param>
	/// <param name="g">The green component of the color.</param>
	/// <param name="b">The blue component of the color.</param>
	public Color(byte r, byte g, byte b)
	{
		R = r;
		G = g;
		B = b;
		A = 255;
	}

	/// <summary>
	/// Creates a new color with all components set to 0 and an alpha value of 255.
	/// </summary>
	public Color()
	{
		R = 0;
		G = 0;
		B = 0;
		A = 255;
	}

	/// <summary>
	/// Creates a new color with the specified hex code.
	/// </summary>
	/// <param name="hex">The hex code of the color.</param>
	public Color(string hex)
	{
		hex = hex.Replace("#", "");
		if (hex.Length == 6)
		{
			R = byte.Parse(hex[..2], System.Globalization.NumberStyles.HexNumber);
			G = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
			B = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
			A = 255;
		}
		else if (hex.Length == 8)
		{
			R = byte.Parse(hex[..2], System.Globalization.NumberStyles.HexNumber);
			G = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
			B = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
			A = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
		}
		else
		{
			throw new ArgumentException("Invalid hex code.");
		}
	}

	/// <summary>
	/// Check if this color is equal to another color.
	/// </summary>
	public override bool Equals(object? obj) => obj is Color c && this == c;

	// check if two colors are equal
	public static bool operator ==(Color a, Color b) => a.R == b.R && a.G == b.G && a.B == b.B && a.A == b.A;

	// check if two colors are not equal
	public static bool operator !=(Color a, Color b) => !(a == b);

	/// <summary>
	/// Cast to System.Drawing.Color
	/// </summary>
	/// <param name="c"></param>
	public static implicit operator System.Drawing.Color(Color c) => System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);

	/// <summary>
	/// Cast from System.Drawing.Color
	/// </summary>
	/// <param name="c"></param>
	public static implicit operator Color(System.Drawing.Color c) => new(c.R, c.G, c.B, c.A);

#if SFML
    // cast to SFML.Graphics.Color
    public static implicit operator SFML.Graphics.Color(Color c) => new(c.R, c.G, c.B, c.A);

    // cast from SFML.Graphics.Color
    public static implicit operator Color(SFML.Graphics.Color c) => new(c.R, c.G, c.B, c.A);
#endif

	/// <summary>
	/// Get the hash code of this color.
	/// </summary>
	/// <returns></returns>
	public override int GetHashCode()
	{
		return HashCode.Combine(R, G, B, A);
	}

	/// <summary>
	/// Convert this color to a string.
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return $"\x1b[{38};2;{R};{G};{B}m";
	}
}