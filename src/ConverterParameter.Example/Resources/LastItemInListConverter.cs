using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace ConverterParameter.Example.Resources
{
    public class LastItemInListConverter : MarkupExtension ,IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is IEnumerable<object> theList)
            {
                foreach (var objectInList in theList)
                {
                    if (objectInList == value)
                    {
                        return objectInList == theList.Last();
                    }
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}