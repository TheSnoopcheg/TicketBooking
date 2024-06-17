using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using TicketBooking.classes;
using System.Diagnostics;
using System.Windows.Input;

namespace TicketBooking.controls
{
    /// <summary>
    /// Interaction logic for TicketPricingSelector.xaml
    /// </summary>
    public partial class TicketPricingSelector : UserControl, INotifyPropertyChanged
    {
        public TicketPricingSelector()
        {
            InitializeComponent();
            this.IsVisibleChanged += TicketPricingSelector_IsVisibleChanged;
        }

        private void TicketPricingSelector_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateDiscountCounts();
        }

        public static readonly DependencyProperty TotalPriceProperty = DependencyProperty.Register(
            "TotalPrice",
            typeof(double),
            typeof(TicketPricingSelector));
        public double TotalPrice
        {
            get {  return (double)GetValue(TotalPriceProperty);}
            set { SetValue(TotalPriceProperty, value); }
        }

        public static readonly DependencyProperty TicketsProperty = DependencyProperty.Register(
            "Tickets",
            typeof(ObservableCollection<Ticket>),
            typeof(TicketPricingSelector));
        public ObservableCollection<Ticket> Tickets
        {
            get { return (ObservableCollection<Ticket>)GetValue(TicketsProperty); }
            set { SetValue(TicketsProperty, value); }
        }

        public static readonly DependencyProperty TicketTypesProperty = DependencyProperty.Register(
            "TicketTypes",
            typeof(IEnumerable<TicketType>),
            typeof(TicketPricingSelector));


        private void UpdateDiscountCounts()
        {
            foreach(var ticketType in TicketTypes)
            {
                if (ticketType.Discounts == null) return;
                foreach(var discount in ticketType.Discounts)
                {
                    discount.Count = Tickets.Count(u => u.SelectedDiscount == discount && u.Name == ticketType.Name);
                }
            }
        }

        public IEnumerable<TicketType> TicketTypes
        {
            get { return (IEnumerable<TicketType>)GetValue(TicketTypesProperty); }
            set { SetValue(TicketTypesProperty, value); }
        }

        private ICommand? _changeDiscountCommand;
        public ICommand ChangeDiscountCommand
        {
            get
            {
                return _changeDiscountCommand ??
                    (_changeDiscountCommand = new RelayCommand(obj =>
                    {

                    }));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
