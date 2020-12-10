using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace AnalysisAPP.Converts
{
    public class ValueColorConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value == DependencyProperty.UnsetValue)
                return false;
            if ((double)value < 0)
                return new SolidColorBrush(Color.FromRgb(50, 205, 85));
            return new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
