/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils;

using System;
using System.Globalization;

[Serializable]
public struct Color
{
    public byte R;
    public byte G;
    public byte B;
    public byte A;

    public Color(byte red, byte green, byte blue, byte alpha = 255)
    {
        R = red;
        G = green;
        B = blue;
        A = alpha;
    }

    public Color(Color color) : this(color.R, color.G, color.B, color.A) { }

    public Color(string hexColor)
    {
        if (hexColor.Contains('#')) hexColor = hexColor.Replace("#", "");
        R = 0;
        G = 0;
        B = 0;
        if (hexColor.Length == 6)
        {
            //#RRGGBB
            R = byte.Parse(hexColor[..2], NumberStyles.AllowHexSpecifier);
            G = byte.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            B = byte.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
        }
        else if (hexColor.Length == 3)
        {
            //#RGB
            R = byte.Parse(hexColor[0] + hexColor[0].ToString(), NumberStyles.AllowHexSpecifier);
            G = byte.Parse(hexColor[1] + hexColor[1].ToString(), NumberStyles.AllowHexSpecifier);
            B = byte.Parse(hexColor[2] + hexColor[2].ToString(), NumberStyles.AllowHexSpecifier);
        }
        A = 255;
    }

    /// <summary>
    /// Returns a random color with an alpha of 255
    /// </summary>
    public static Color Random => new(Randomizer.Byte(255), Randomizer.Byte(255), Randomizer.Byte(255), 255);

    /// <summary>
    /// Returns a random color with a random alpha
    /// </summary>
    public static Color RandomAlpha => new(Randomizer.Byte(255), Randomizer.Byte(255), Randomizer.Byte(255), Randomizer.Byte(255));

    public static readonly Color CheetoOrange = new("#F79239");
    public static readonly Color CheetoYellow = new("#FFFB00");

    /// <summary>
    /// Interpolates between a and b by t.
    /// </summary>
    /// <returns>The interpolated color</returns>
    public static Color Lerp(Color c1, Color c2, float t)
    {
        t = MathUtils.Clamp01(t);
        byte r = (byte)MathUtils.Lerp(c1.R, c2.R, t);
        byte g = (byte)MathUtils.Lerp(c1.G, c2.G, t);
        byte b = (byte)MathUtils.Lerp(c1.B, c2.B, t);
        byte a = (byte)MathUtils.Lerp(c1.A, c2.A, t);
        return new(r, g, b, a);
    }

    public static readonly Color Black = new(0, 0, 0);
    public static readonly Color Gray = new(128, 128, 128);
    public static readonly Color Grey = Gray;
    public static readonly Color White = new(255, 255, 255);
    public static readonly Color Red = new(255, 0, 0);
    public static readonly Color Green = new(0, 255, 0);
    public static readonly Color Blue = new(0, 0, 255);
    public static readonly Color Transparent = new(0, 0, 0, 0);

    /// <summary>
    /// Colors based on the HTML 4.01 specification
    /// </summary>
    public class Html
    {
        public static readonly Color White = Color.White;
        public static readonly Color Silver = new(192, 192, 192);
        public static readonly Color Gray = Color.Gray;
        public static readonly Color Black = Color.Black;
        public static readonly Color Red = Color.Red;
        public static readonly Color Maroon = new(128, 0, 0);
        public static readonly Color Yellow = new(255, 255, 0);
        public static readonly Color Olive = new(128, 128, 0);
        public static readonly Color Green = new(0, 128, 0);
        public static readonly Color Aqua = new(0, 255, 255);
        public static readonly Color Teal = new(0, 128, 128);
        public static readonly Color Blue = Color.Blue;
        public static readonly Color Navy = new(0, 0, 128);
        public static readonly Color Fushia = new(255, 0, 255);
        public static readonly Color Purple = new(128, 0, 128);
    }

    /// <summary>
    /// Crayola crayon colors
    /// </summary>
    public class Crayola
    {
        /// <summary>
        /// Crayola colors from 1903
        /// </summary>
        public class Original
        {
            public static readonly Color Red = new("#ED0A3F");
            public static readonly Color EnglishVermilion = new("#CC474B");
            public static readonly Color MadderLake = new("#CC3336");
            public static readonly Color PermanentGeraniumLake = new("#E12C2C");
            public static readonly Color IndianRed = new("#CD5C5C");
            public static readonly Color DarkVenetianRed = new("#B33B24");
            public static readonly Color VenetianRed = new("#C80815");
            public static readonly Color LightVenetianRed = new("#E6735C");
            public static readonly Color Orange = new("#FF8833");
            public static readonly Color GoldOchre = new("#F2C649");
            public static readonly Color MediumChromeYellow = new("#FCD667");
            public static readonly Color Yellow = Html.Yellow;
            public static readonly Color OliveGreen = new("#B5B35C");
            public static readonly Color LightChromeYellow = new("#FFFF9F");
            public static readonly Color LightChromeGreen = new("#BEE64B");
            public static readonly Color Green = new("#008001");
            public static readonly Color MediumChromeGreen = new("#6CA67C");
            public static readonly Color DarkChromeGreen = new("#01786F");
            public static readonly Color Blue = new("#2EB4E6");
            public static readonly Color PrussianBlue = new("#00468C");
            public static readonly Color CobaltBlue = new("#0047AB");
            public static readonly Color CelestialBlue = new("#4997D0");
            public static readonly Color UltramarineBlue = new("#4166F5");
            public static readonly Color Purple = new("#6A0DAD");
            public static readonly Color PermanentMagenta = new("#F653A6");
            public static readonly Color RosePink = new("#FF66CC");
            public static readonly Color BurntSienna = new("#E97451");
            public static readonly Color VanDykeBrown = new("#664228");
            public static readonly Color FleshTint = new("#FFCBA4");
            public static readonly Color BurntUmber = new("#8A3324");
            public static readonly Color RawUmber = new("#826644");
            public static readonly Color RawSienna = new("#D68A59");
            public static readonly Color Gold = new("#A57C00");
            public static readonly Color Silver = new("#AAA9AD");
            public static readonly Color Copper = new("#B87333");
            public static readonly Color Black = Color.Black;
            public static readonly Color CharcoalGray = new("#736A62");
            public static readonly Color White = Color.White;
        }

        /// <summary>
        /// Crayola colors from 1990-present (02/19/2022)
        /// </summary>
        public class Present
        {
            public static readonly Color Scarlet = new("#FD0E35");
            public static readonly Color TorchRed = new("#FD0E35"); // Same as above
            public static readonly Color SunsetOrange = new("#FE4C40");
            public static readonly Color VividTangerine = new("#FF9980");
            public static readonly Color MacaroniAndCheese = new("#FFB97B");
            public static readonly Color MangoTango = new("#E77200");
            public static readonly Color BananaMania = new("#FBE7B2");
            public static readonly Color Dandelion = new("#FED85D");
            public static readonly Color Canary = new("#FFFF99");
            public static readonly Color Inchworm = new("#AFE313");
            public static readonly Color Asparagus = new("#7BA05B");
            public static readonly Color GrannySmithApple = new("#9DE093");
            public static readonly Color Fern = new("#63B76C");
            public static readonly Color Shamrock = new("#33CC99");
            public static readonly Color MountainMeadow = new("#1AB385");
            public static readonly Color JungleGreen = new("#29AB87");
            public static readonly Color CaribbeanGreen = new("#00CC99");
            public static readonly Color TropicalRainForest = new("#00755E");
            public static readonly Color RobinsEggBlue = new("#00CCCC");
            public static readonly Color TealBlue = new("#008080");
            public static readonly Color OuterSpace = new("#2D383A");
            public static readonly Color PacificBlue = new("#1CA9C9");
            public static readonly Color Cerulean = new("#02A4D3");
            public static readonly Color Denim = new("#1560BD");
            public static readonly Color Bluetiful = new("#3C69E7");
            public static readonly Color WildBlueYonder = new("#A2ADD0");
            public static readonly Color Indigo = new("#4B0082");
            public static readonly Color Manatee = new("#979AAA");
            public static readonly Color BlueBell = new("#A2A2D0");
            public static readonly Color PurpleHeart = new("#69359C");
            public static readonly Color RoyalPurple = new("#7851A9");
            public static readonly Color Wisteria = new("#C9A0DC");
            public static readonly Color VividViolet = new("#9F00FF");
            public static readonly Color PurpleMountainsMajesty = new("#9678B6");
            public static readonly Color Fuchsia = new("#C154C1");
            public static readonly Color PinkFlamingo = new("#FC74FD");
            public static readonly Color JazzberryJam = new("#A50B5E");
            public static readonly Color Eggplant = new("#614051");
            public static readonly Color Cerise = new("#DE3163");
            public static readonly Color WildStrawberry = new("#FF43A4");
            public static readonly Color CottonCandy = new("#FFBCD9");
            public static readonly Color Razzmatazz = new("#E3256B");
            public static readonly Color PigPink = new("#FDDDE6");
            public static readonly Color Blush = new("#DE5D83");
            public static readonly Color Cranberry = new("#DE5D83"); // Same as above
            public static readonly Color TickleMePink = new("#FC89AC");
            public static readonly Color Mauvelous = new("#EF98AA");
            public static readonly Color PinkSherbert = new("#F78FA7");
            public static readonly Color BrinkPink = new("#F78FA7"); // Same as above
            public static readonly Color FuzzyWuzzy = new("#CC6666");
            public static readonly Color Beaver = new("#9F8170");
            public static readonly Color Tumbleweed = new("#DEAA88");
            public static readonly Color DesertSand = new("#EDC9AF");
            public static readonly Color Almond = new("#EFDECD");
            public static readonly Color Shadow = new("#8A795D");
            public static readonly Color Timberwolf = new("#D9D6CF");
            public static readonly Color AntiqueBrass = new("#CD9575");
        }
    }

    /// <summary>
    /// Visual Studio Dark Theme colors 2022 Preview
    /// </summary>
    public class VsDark
    {
        //Embedded tab control: active tab
        public static readonly Color Foreground = new(220, 220, 220);
        public static readonly Color Background = new(30, 30, 30);
        public static readonly Color Comment = new(87, 166, 74);
    }

    public override readonly string ToString() => $"rgba({R}, {G}, {B}, {A})";
}
