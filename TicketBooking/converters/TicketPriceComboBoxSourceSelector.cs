using System.Globalization;
using System.Windows.Data;
using TicketBooking.classes;

namespace TicketBooking.converters
{
    public class TicketPriceComboBoxSourceSelector : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) return null;
            var ticketTypes = values[0] as IEnumerable<TicketType>;
            var name = values[1] as string;
            if (ticketTypes == null || string.IsNullOrEmpty(name)) return null;
            var ticketType = ticketTypes.FirstOrDefault(t => t.Name == name);
            if (ticketType == null) return null;
            return ticketType.Discounts;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
