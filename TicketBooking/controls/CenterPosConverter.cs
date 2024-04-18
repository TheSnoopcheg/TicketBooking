﻿using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace TicketBooking.controls
{
    internal class CenterPosConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            if(value is double v)
            {
                return v / 2;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
