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
    }
}
