using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RecordCase.Core.Extensions
{
    public static class BitmapImageExtensions
    {
        public static byte[] ToByteArray(this BitmapImage bitmap)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            encoder.Save(memStream);
            return memStream.GetBuffer();
        }
    }
}
