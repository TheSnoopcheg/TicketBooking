using System.Globalization;
using System.Windows.Data;
using TicketBooking.classes;

namespace TicketBooking.converters
{
    internal class DiscountButtonIsEnableConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || parameter == null) return false;
            var discount = values[0] as Discount;
            var ticket = values[1] as TicketType;
            var operation = parameter as string;
            if (discount == null || ticket == null || string.IsNullOrEmpty(operation)) return false;

            return (operation == "+" && ticket.NumOfTickets > ticket.NumOfSelectedDiscounts) ||
                (operation == "-" && discount.Count > 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
