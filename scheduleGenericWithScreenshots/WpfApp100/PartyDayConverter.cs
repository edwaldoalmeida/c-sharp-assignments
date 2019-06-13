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
    class PartyDayConverter : IValueConverter
    {
        private int min = 1;
        private int max = 31;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int x = int.Parse(value.ToString());

            if (x < min || x > max)
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
