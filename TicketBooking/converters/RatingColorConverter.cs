using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TicketBooking.converters
{
    internal class RatingColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return new SolidColorBrush(Colors.Black);
            if (value is double v)
            {
                if (v <= 3.0)
                    return new SolidColorBrush(Colors.Red);
                else if (v > 3.0 && v <= 7.5)
                    return new SolidColorBrush(Colors.Gray);
                else
                    return new SolidColorBrush(Colors.Green);
            }
            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
