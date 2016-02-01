using PostStore.Strings;
using System;
using System.Globalization;
using System.Windows.Data;

namespace PostStore.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public static readonly IValueConverter Instance = new DateTimeConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format(culture.DateTimeFormat, FormatStrings.DateTimeFormat, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime result;
            var convertionSucceed = DateTime.TryParseExact(value.ToString(), "dd/MM/yy", culture.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces, out result);
            return convertionSucceed ? result : value;
        }
    }
}
