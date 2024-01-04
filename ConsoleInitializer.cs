/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahUtils;

using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

/// <summary>
/// Methods meant to only be ran on Windows machines.
/// </summary>
internal static class ConsoleInitializer
{
    [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    private static extern int AllocConsole();

    [DllImport("kernel32.dll", EntryPoint = "AttachConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    private static extern uint AttachConsole(uint dwProcessId);

    [DllImport("kernel32.dll", EntryPoint = "CreateFileW", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    private static extern nint CreateFileW(
          string lpFileName,
          uint dwDesiredAccess,
          uint dwShareMode,
          nint lpSecurityAttributes,
          uint dwCreationDisposition,
          uint dwFlagsAndAttributes,
          nint hTemplateFile
        );

    private const uint GENERIC_WRITE = 0x40000000;
    private const uint GENERIC_READ = 0x80000000;
    private const uint FILE_SHARE_READ = 0x00000001;
    private const uint FILE_SHARE_WRITE = 0x00000002;
    private const uint OPEN_EXISTING = 0x00000003;
    private const uint FILE_ATTRIBUTE_NORMAL = 0x80;
    private const uint ERROR_ACCESS_DENIED = 5;

    private const uint ATTACH_PARRENT = 0xFFFFFFFF;

    internal static void Initialize(bool alwaysCreateNewConsole = false)
    {
        AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        bool consoleAttached = true;
        if (alwaysCreateNewConsole
            || (AttachConsole(ATTACH_PARRENT) == 0
            && Marshal.GetLastWin32Error() != ERROR_ACCESS_DENIED))
        {
            consoleAttached = AllocConsole() != 0;
        }

        if (consoleAttached)
        {
            InitializeOutStream();
            InitializeInStream();
        }
    }

    private static void UnhandledException(object sender, UnhandledExceptionEventArgs e) => Log.Exception(e);

    private static void InitializeOutStream()
    {
        FileStream? fs = CreateFileStream("CONOUT$", GENERIC_WRITE, FILE_SHARE_WRITE, FileAccess.Write);
        if (fs != null)
        {
            StreamWriter writer = new(fs) { AutoFlush = true };
            Console.SetOut(writer);
            Console.SetError(writer);
        }
    }

    private static void InitializeInStream()
    {
        FileStream? fs = CreateFileStream("CONIN$", GENERIC_READ, FILE_SHARE_READ, FileAccess.Read);
        if (fs != null)
            Console.SetIn(new StreamReader(fs));
    }

    private static FileStream? CreateFileStream(string name, uint win32DesiredAccess, uint win32ShareMode, FileAccess dotNetFileAccess)
    {
        SafeFileHandle file = new(CreateFileW(name, win32DesiredAccess, win32ShareMode, nint.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, nint.Zero), true);
        if (!file.IsInvalid)
        {
            FileStream fs = new(file, dotNetFileAccess);
            return fs;
        }
        return null;
    }
}