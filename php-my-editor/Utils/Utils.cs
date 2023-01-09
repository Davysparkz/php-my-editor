using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace php_my_editor.Utils
{
    public static class IconUtil
    {
        public static ImageSource ToImageSource(this Icon icon)
        {
            var imageSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions()
                );

            return imageSource;
        }
    }

    public static class Utils
    {
        public static string ToNewLinesString(this List<int> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString();
        }
    }
}
