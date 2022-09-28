// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Mono.Unix.Native;

namespace CacheSizeTest
{
    public static class LinuxCache
    {
        public static unsafe void Print()
        {
            long cacheSize = 0;
            cacheSize = Math.Max(cacheSize, Syscall.sysconf(SysconfName._SC_LEVEL1_DCACHE_SIZE));
            cacheSize = Math.Max(cacheSize, Syscall.sysconf(SysconfName._SC_LEVEL2_CACHE_SIZE));
            cacheSize = Math.Max(cacheSize, Syscall.sysconf(SysconfName._SC_LEVEL3_CACHE_SIZE));
            cacheSize = Math.Max(cacheSize, Syscall.sysconf(SysconfName._SC_LEVEL4_CACHE_SIZE));

            Console.WriteLine($"Cache size: {cacheSize}");
        }
    }
}
