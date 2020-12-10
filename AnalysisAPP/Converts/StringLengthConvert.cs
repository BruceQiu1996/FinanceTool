using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AnalysisAPP.Converts
{
    public class StringLengthConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value == DependencyProperty.UnsetValue) 
            {
                return null;
            }

            if (value.ToString().Length > 50)
                return value.ToString().Trim().Substring(0, 50) + "...";
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
