using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace RecordCase.Core.WPF.Converters
{
    public class BinaryImageConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, global::System.Globalization.CultureInfo culture)
        {
            if (value != null && value is byte[])
            {
                var bytes = value as byte[];

                var stream = new MemoryStream(bytes);

                var image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();

                return image;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, global::System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
