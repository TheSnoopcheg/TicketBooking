using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using TicketBooking.classes;

namespace TicketBooking.converters
{
    public class DiscountCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            var discounts = value as List<Discount>;
            if (discounts == null) return null;
            return discounts.Skip(1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
