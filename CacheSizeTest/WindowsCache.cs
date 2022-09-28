// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Windows.Win32;
using Windows.Win32.System.SystemInformation;

namespace CacheSizeTest
{
    public static class WindowsCache
    {
        public static unsafe void Print()
        {
            uint length = 0;
            PInvoke.GetLogicalProcessorInformation(null, ref length);

            SYSTEM_LOGICAL_PROCESSOR_INFORMATION[] buffer = new SYSTEM_LOGICAL_PROCESSOR_INFORMATION[length];
            fixed (SYSTEM_LOGICAL_PROCESSOR_INFORMATION* ptr = &buffer[0])
                PInvoke.GetLogicalProcessorInformation(ptr, ref length);

            uint lastCacheSize = 0;

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i].Relationship == LOGICAL_PROCESSOR_RELATIONSHIP.RelationCache)
                {
                    if (lastCacheSize < buffer[i].Anonymous.Cache.Size)
                        lastCacheSize = buffer[i].Anonymous.Cache.Size;
                }
            }

            Console.WriteLine($"Cache size: {lastCacheSize}");
        }
    }
}
