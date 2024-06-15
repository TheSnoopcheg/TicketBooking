using System.Globalization;
using System.Windows.Data;

namespace TicketBooking.converters
{
    internal class DiscountConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0) return null;
            if (values[0] == null || !(values[0] is string) || (string)values[0] == string.Empty) return null;
            if (values[1] == null || !(values[1] is double) ||  (double)values[1] == double.NaN) return null;
            if (values[2] == null || !(values[2] is double) || (double)values[2] == double.NaN) return null;
            return values[0].ToString() + " - " + ((double)values[1] * (double)values[2]).ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
