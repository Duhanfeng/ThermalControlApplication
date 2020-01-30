using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ThermalContainerApplication.Converters
{
    public class StateToConnectNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return (bool)value ? "断开" : "连接";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
