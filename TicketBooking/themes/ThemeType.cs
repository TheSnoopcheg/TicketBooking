using System;

namespace TicketBooking.themes
{
    public enum ThemeType
    {
        Light,
        Dark
    }
    public static class ThemeTypeExtension
    { 
        public static string GetName(this ThemeType themeType)
        {
            switch (themeType)
            {
                case ThemeType.Light: return "LightTheme";
                case ThemeType.Dark: return "DarkTheme";
                default: throw new ArgumentOutOfRangeException(nameof(themeType), themeType, null);
            }
        }
    }
}
