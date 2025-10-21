using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CopyThatProgram
{
    [SupportedOSPlatform("windows")]
    internal static class FastEnumerator
    {
        public struct Entry
        {
            public string FullPath;
            public string Name;
            public bool IsDirectory;
            public long Length;
        }

        public static IEnumerable<Entry> Enumerate(string root, EnumerationOptions opt)
        {
            var queue = new Queue<string>();
            queue.Enqueue(root);

            var findData = new WIN32_FIND_DATA();
            while (queue.Count > 0)
            {
                string dir = queue.Dequeue();
                string spec = Path.Combine(dir, "*");

                IntPtr hFind = FindFirstFileEx(spec, FINDEX_INFO_LEVELS.FindExInfoBasic,
                                               ref findData, FINDEX_SEARCH_OPS.FindExSearchNameMatch,
                                               IntPtr.Zero, FIND_FIRST_EX_LARGE_FETCH);

                if (hFind == INVALID_HANDLE_VALUE) continue;

                do
                {
                    string name = findData.cFileName;
                    if (name == "." || name == "..") continue;

                    bool isDir = (findData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) != 0;
                    long len = (long)findData.nFileSizeLow | ((long)findData.nFileSizeHigh << 32);

                    string full = Path.Combine(dir, name);
                    yield return new Entry
                    {
                        FullPath = full,
                        Name = name,
                        IsDirectory = isDir,
                        Length = len
                    };

                    if (opt.RecurseSubdirectories && isDir)
                        queue.Enqueue(full);

                } while (FindNextFile(hFind, ref findData));

                FindClose(hFind);
            }
        }

        #region interop
        private const int FILE_ATTRIBUTE_DIRECTORY = 0x10;
        private const int FIND_FIRST_EX_LARGE_FETCH = 2;
        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        private enum FINDEX_INFO_LEVELS { FindExInfoStandard, FindExInfoBasic }
        private enum FINDEX_SEARCH_OPS { FindExSearchNameMatch }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct WIN32_FIND_DATA
        {
            public uint dwFileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindFirstFileEx(
            string lpFileName, FINDEX_INFO_LEVELS fInfoLevelId,
            ref WIN32_FIND_DATA lpFindFileData, FINDEX_SEARCH_OPS fSearchOp,
            IntPtr lpSearchFilter, int dwAdditionalFlags);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool FindNextFile(IntPtr hFindFile, ref WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FindClose(IntPtr hFindFile);
        #endregion
    }
}
