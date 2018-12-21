using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Validierung
{
    public class DateTimeNotInFutureRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(DateTime.TryParse(value.ToString(), out DateTime date))
            {
                if(date < DateTime.Now)
                {
                    return ValidationResult.ValidResult;
                }
                return new ValidationResult(false, "Datum darf nicht in der Zukunft liegen!");
            }
            return new ValidationResult(false, "Kein gültiges Datum!");
        }
    }
}