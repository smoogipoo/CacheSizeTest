using System.Runtime.InteropServices;
using CacheSizeTest;

if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    WindowsCache.Print();
else
    LinuxCache.Print();
