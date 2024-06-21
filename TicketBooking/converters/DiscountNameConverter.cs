using System.Globalization;
using System.Windows.Data;
using TicketBooking.classes;

namespace TicketBooking.converters
{
    class DiscountNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Discount discount) return string.Empty;
            return $"{discount.Name} ({discount.PriceMultiplier*100}%)";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
