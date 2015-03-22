using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace RecordCase.Core.Extensions
{
    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }
    }
}
