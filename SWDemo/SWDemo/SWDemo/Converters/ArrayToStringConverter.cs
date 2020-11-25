using System;
using System.Globalization;
using Xamarin.Forms;

namespace SWDemo.Converters
{
    public class ArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            var arr = (string[])value;
            string res = "";

            foreach (var st in arr)
                res = string.Format("{0}\r\n * {1}", res, st);
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string []d = new string[] { "" };
            return d;
        }
    }
}
