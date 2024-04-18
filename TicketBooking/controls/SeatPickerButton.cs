using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TicketBooking.classes;

namespace TicketBooking.controls
{
    internal class SeatPickerButton : Button
    {

        #region IsSelected

        internal static readonly DependencyPropertyKey IsSelectedPropertyKey = DependencyProperty.RegisterReadOnly(
            "IsSelected",
            typeof(bool),
            typeof(SeatPickerButton),
            new FrameworkPropertyMetadata(false));
        public static readonly DependencyProperty IsSelectedProperty = IsSelectedPropertyKey.DependencyProperty;
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
        }

        #endregion

        internal void SetSelectedPropertyValue(bool value)
        {
            SetValue(IsSelectedPropertyKey, value);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if(this.DataContext is Seat v)
            {
                if(v.Status == "Free")
                {
                    SetValue(IsSelectedPropertyKey, !IsSelected);
                }
            }
        }
    }
}
