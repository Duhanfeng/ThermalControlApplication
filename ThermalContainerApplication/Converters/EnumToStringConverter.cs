using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using DhfLib.Infrastructure;

namespace ThermalContainerApplication.Converters
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return EnumHelper.GetDescription(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
