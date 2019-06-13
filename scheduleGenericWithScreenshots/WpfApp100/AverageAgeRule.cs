using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp100
{
    class AverageAgeRule : ValidationRule
    {
        private int min;
        private int max;

        public int Min { get => min; set => min = value; }
        public int Max { get => max; set => max = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int number = 0;

            if (!int.TryParse((string)value, out number))
            {
                return new ValidationResult(false, "Invalid Data Type");
            }
            if (number < min || number > max)
            {
                return new ValidationResult(false, string.Format("Please enter a number greater than {0} and lesser than {1}", min, max));
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
