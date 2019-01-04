using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Validierung
{
    class IntBetweenXAndYRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(int.TryParse(value.ToString(), out int integer)) {
                if(integer >= Min && integer <= Max)
                {
                    return ValidationResult.ValidResult;
                }
                return new ValidationResult(false, $"Wert ist nicht zwischen {Min} und {Max}");
            }
            return new ValidationResult(false, "Keine gültige Zahl");
        }
    }
}