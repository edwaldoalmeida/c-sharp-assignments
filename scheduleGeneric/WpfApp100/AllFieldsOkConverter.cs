using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp100
{
    class AllFieldsOkConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool res = true;

            foreach (object val in values)
            {
                if (string.IsNullOrEmpty(val as string))
                {
                    res = false;
                }
            }

            string newval = string.Empty;

            return res;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
