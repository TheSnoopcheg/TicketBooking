using System.Globalization;
using System.Windows.Data;
using TicketBooking.classes;

namespace TicketBooking.converters
{
    class DiscountPriceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is not double price) return null;
            if (values[1] is not Discount discount) return null;
            return (price * discount.PriceMultiplier).ToString();
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
