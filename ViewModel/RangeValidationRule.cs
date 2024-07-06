using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFToDoList.ViewModel
{
    public class RangeValidationRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is int number)
            {
                if (number >= Min && number <= Max)
                {
                    return ValidationResult.ValidResult;
                }
            }
            return new ValidationResult(false, "请输入1到20之间的数字。");
        }
    }
}
