#if WINDOWS || EDITOR
namespace CheetahUtils;

#region Using Statements
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
#endregion

public static class ConsoleUtils
{
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool WriteConsoleOutputW(
        SafeFileHandle hConsoleOutput,
        CharInfo[] lpBuffer,
        Coord dwBufferSize,
        Coord dwBufferCoord,
        ref Rectangle lpWriteRegion);

    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern SafeFileHandle CreateFile(
        string fileName,
        [MarshalAs(UnmanagedType.U4)] uint fileAccess,
        [MarshalAs(UnmanagedType.U4)] uint fileShare,
        nint securityAttributes,
        [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
        [MarshalAs(UnmanagedType.U4)] int flags,
        nint template);

    [StructLayout(LayoutKind.Sequential)]
    public struct Coord(short x, short y)
    {
        public short x = x, y = y;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct CharInfo
    {
        [FieldOffset(0)] public ushort Character;
        [FieldOffset(2)] public short Attributes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle(short left, short top, short right, short bottom)
    {
        public short left = left, top = top, right = right, bottom = bottom;
    }
}
#endif