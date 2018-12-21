using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UserControl_24_Uhr
{
    public class IntToDateTimeConverter : IValueConverter
    {
        //Source -> Target
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(int.TryParse(value.ToString(), out int hours))
            {
                return new TimeSpan(hours, 0, 0);
            }
            if(value is DateTime date)
            {
                return new TimeSpan(date.Hour, 0, 0);
            }
            return value;
        }

        //Target -> Source
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
