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
            var selector = sender as TicketPricingSelector;
            if (selector == null || !selector.IsVisible) return;
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
                ticketType.NumOfTickets = Tickets.Count(u => u.Name == ticketType.Name);
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
                        if(obj is not object[] objects || objects.Length < 3) return;
                        var discount = objects[0] as Discount;
                        var ticketType = objects[1] as TicketType;
                        var param = objects[2] as string;
                        if(discount == null || ticketType == null || string.IsNullOrEmpty(param)) return;

                        Ticket? ticket;
                        if(param == "+")
                        {
                            ticket = Tickets.FirstOrDefault(u => u.Name == ticketType.Name && u.SelectedDiscount == ticketType.Discounts[0]);
                            UpdateCountAndSelectedDiscount(discount, ticketType, ticket, true);
                        }
                        else if (param == "-")
                        {
                            ticket = Tickets.FirstOrDefault(u => u.Name == ticketType.Name && u.SelectedDiscount == discount);
                            UpdateCountAndSelectedDiscount(discount, ticketType, ticket, false);
                        }
                        CalculateTotalPrice();
                    }));
            }
        }

        private void UpdateCountAndSelectedDiscount(Discount discount, TicketType ticketType, Ticket? ticket, bool incerement)
        {
            if (ticket == null) return;
            int countChange = incerement ? 1 : -1;
            discount.Count += countChange;
            ticketType.NumOfSelectedDiscounts += countChange;
            ticket.SelectedDiscount = incerement ? discount : ticketType.Discounts![0];
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = Tickets.Sum(ticket => ticket.Price * ticket.SelectedDiscount!.PriceMultiplier);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
