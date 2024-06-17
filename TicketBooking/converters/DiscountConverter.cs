using System.Globalization;
using System.Windows.Data;

namespace TicketBooking.converters
{
    internal class DiscountConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0) return null;
            var name = values[0] as string;
            var multiplier = values[1] as double?;
            var price = values[2] as double?;

            if (string.IsNullOrEmpty(name) || !multiplier.HasValue || !price.HasValue)
                return null;

            return $"{name} - {multiplier.Value * price.Value} r.";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
