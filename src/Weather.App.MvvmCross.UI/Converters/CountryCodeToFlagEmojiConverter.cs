using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MvvmCross.Converters;

namespace Weather.App.MvvmCross.Core.Converters
{
    public class CountryCodeToFlagEmojiConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Concat(((string)value).ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(nameof(CountryCodeToFlagEmojiConverter));
        }
    }
}