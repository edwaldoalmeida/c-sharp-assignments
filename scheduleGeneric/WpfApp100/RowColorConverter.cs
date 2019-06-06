using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp100
{
    class RowColorConverter : IValueConverter
    {
        int criticalAge = 60;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int x = int.Parse(value.ToString());

            if (x > criticalAge)
            {
                return Brushes.Red;
            }
            else
            {
                return Brushes.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
