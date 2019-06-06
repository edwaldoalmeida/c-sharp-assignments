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
    [ValueConversion(typeof(int), typeof(Brush))]
    class MyConverter : IValueConverter
    {
        private int min = 1;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int i = int.Parse(value.ToString());

            if (i < min)
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
