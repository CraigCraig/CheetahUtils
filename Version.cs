namespace CheeseyUtils;

using System.Text;

public class Version(int major = 0, int minor = 0, int patch = 0, int build = 0, int rc = 0)
{
    public int Major { get; set; } = major;
    public int Minor { get; set; } = minor;
    public int Patch { get; set; } = patch;
    public int Build { get; set; } = build;
    public int RC { get; set; } = rc;

    public override string ToString()
    {
        StringBuilder sb = new();
        _ = sb.Append($"{Major}");

        if (Minor != 0 || Patch != 0)
        {
            _ = sb.Append($".{Minor}");
        }

        if (Patch != 0 || Build != 0)
        {
            _ = sb.Append($".{Patch}");
        }

        if (Build != 0)
        {
            _ = sb.Append($".{Build}");
        }

        if (RC != 0)
        {
            _ = sb.Append($"-RC{RC}");
        }

        return sb.ToString();
    }
}
