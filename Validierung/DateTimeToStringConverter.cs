using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Validierung
{
    public class DateTimeToStringConverter : IValueConverter
    {
        //DateTime -> String
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime time)
            {
                return time.ToShortDateString();
            }
            return null;
        }

        //String -> DateTime
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(DateTime.TryParse(value.ToString(), out DateTime dvalue))
           {
                return dvalue;
           }
           return null;
        }
    }
}
