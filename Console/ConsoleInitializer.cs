namespace CheeseyUtils.Console;

using Microsoft.Win32.SafeHandles;
using System.IO;
using System;
using System.Runtime.InteropServices;

/// <summary>
/// Methods meant to only be ran on Windows machines.
/// </summary>
public static partial class ConsoleInitializer
{
    [LibraryImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    private static partial int AllocConsole();

    [LibraryImport("kernel32.dll", EntryPoint = "AttachConsole", SetLastError = true)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    private static partial uint AttachConsole(uint dwProcessId);

    [LibraryImport("kernel32.dll", EntryPoint = "CreateFileW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvStdcall) })]
    private static partial nint CreateFileW(
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

    public static void Initialize(bool alwaysCreateNewConsole = false)
    {
        AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        bool consoleAttached = true;
        if (alwaysCreateNewConsole || (AttachConsole(ATTACH_PARRENT) == 0 && Marshal.GetLastWin32Error() != ERROR_ACCESS_DENIED))
        {
            consoleAttached = AllocConsole() != 0;
        }

        if (consoleAttached)
        {
            InitializeOutStream();
            InitializeInStream();
        }

        if (WindowsUtils.GetVersion() >= 0x0A000000)
        {
            var handle = WindowsUtils.GetStdHandle(-11);
            if (WindowsUtils.GetConsoleMode(handle, out int mode))
            {
                mode |= 0x0004;
                _ = WindowsUtils.SetConsoleMode(handle, mode);
            }
        }
    }

    private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Console.WriteLine(e);
    }

    private static void InitializeOutStream()
    {
        var fs = CreateFileStream("CONOUT$", GENERIC_WRITE, FILE_SHARE_WRITE, FileAccess.Write);
        if (fs != null)
        {
            var writer = new StreamWriter(fs) { AutoFlush = true };
            Console.SetOut(writer);
            Console.SetError(writer);
        }
    }

    private static void InitializeInStream()
    {
        var fs = CreateFileStream("CONIN$", GENERIC_READ, FILE_SHARE_READ, FileAccess.Read);
        if (fs != null)
        {
            Console.SetIn(new StreamReader(fs));
        }
    }

    private static FileStream? CreateFileStream(string name, uint win32DesiredAccess, uint win32ShareMode, FileAccess dotNetFileAccess)
    {
        var file = new SafeFileHandle(CreateFileW(name, win32DesiredAccess, win32ShareMode, nint.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, nint.Zero), true);
        if (!file.IsInvalid)
        {
            var fs = new FileStream(file, dotNetFileAccess);
            return fs;
        }
        return null;
    }
}