using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RecordCase.Core.Collections.Extensions;

namespace RecordCase.Core.Filesystem
{
    public static class DirectoryInfoExtensions
    {
        public static void Empty(this DirectoryInfo obj)
        {            
            obj.EnumerateFiles().ForEachInEnumerable(f=>f.Delete());
            obj.EnumerateDirectories().ForEachInEnumerable(d=> { d.Empty(); d.Delete(); });

        }


        public static List<FileInfo> GetFilesFromDirectory(this DirectoryInfo rootPath, bool traverse, String search_pattern)
        {
            List<FileInfo> files = new List<FileInfo>(rootPath.GetFiles(search_pattern));
            if (traverse)
            {
                foreach (DirectoryInfo di in rootPath.GetDirectories())
                {
                    files.AddRange(GetFilesFromDirectory(di, traverse, search_pattern));
                }
            }
            return files;
        }
    }
}
