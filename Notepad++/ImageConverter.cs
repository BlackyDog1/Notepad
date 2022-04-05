
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Notepad__
{
    /// <summary>
    /// Converts a full path to a specific image type 
    /// </summary>
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class ImageConverter : IValueConverter
    {
        public static ImageConverter Instance = new ImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //full path to image
            var path = (string)value;

            if (path == null)
                return null;

            var name = MainWindow.GetFileFolderName(path);

            var image = "img/file.png";

            if (string.IsNullOrEmpty(name))
                image = "img/drive.png";
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "img/folder-open.png";

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
