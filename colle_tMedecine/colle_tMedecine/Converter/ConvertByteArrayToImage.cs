using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace colle_tMedecine.Converter
{
    class ConvertByteArrayToImage : IValueConverter
    {
        public ConvertByteArrayToImage() { }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            byte[] picture = value as byte[];
            if (picture != null && picture.Length > 0)
            {
                
                MemoryStream stream = new MemoryStream(picture);
                stream.Position = 0;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = stream;
                bi.EndInit();

                ImageSource imgsrc = bi;
                return imgsrc;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
