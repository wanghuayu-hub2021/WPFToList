using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFToDoList.ViewModel
{
    public class PageNumberConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2)
                return null;

            // values[0] 是当前页码，values[1] 是要减去的数值
            int currentPage = System.Convert.ToInt32(values[0]);
            int subtractValue = System.Convert.ToInt32(values[1]);

            // 计算上一页的页码
            int previousPage = currentPage + subtractValue;

            // 确保页码不会小于 1
            return Math.Max(1, previousPage);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack is not supported.");
        }
    }
}
