using System.Windows;
using System.Windows.Controls;
using TicketBooking.classes;

namespace TicketBooking.controls
{
    /// <summary>
    /// Interaction logic for TicketPresenter.xaml
    /// </summary>
    public partial class TicketPresenter : UserControl
    {
        public TicketPresenter()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TicketsProperty = DependencyProperty.Register(
            "Tickets",
            typeof(IEnumerable<Ticket>),
            typeof(TicketPresenter));

        public IEnumerable<Ticket> Tickets
        {
            get { return (IEnumerable<Ticket>)GetValue(TicketsProperty);}
            set { SetValue(TicketsProperty, value); }
        }

        public static readonly DependencyProperty MovieProperty = DependencyProperty.Register(
            "Movie",
            typeof(Movie),
            typeof(TicketPresenter));
        public Movie Movie
        {
            get { return (Movie)GetValue(MovieProperty); }
            set { SetValue(MovieProperty, value); }
        }

        public static readonly DependencyProperty SessionProperty = DependencyProperty.Register(
            "Session",
            typeof(Session),
            typeof(TicketPresenter));
        public Session Session
        {
            get { return (Session)GetValue(SessionProperty); }
            set { SetValue(SessionProperty, value); }
        }

        public static readonly DependencyProperty TicketTypesProperty = DependencyProperty.Register(
            "TicketTypes",
            typeof(IEnumerable<TicketType>),
            typeof(TicketPresenter));
        public IEnumerable<TicketType> TicketTypes
        {
            get { return (IEnumerable<TicketType>)GetValue(TicketTypesProperty); }
            set { SetValue(TicketTypesProperty, value); }
        }

        public static readonly DependencyProperty TotalPriceProperty = DependencyProperty.Register(
            "TotalPrice",
            typeof(double),
            typeof(TicketPresenter),
            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public double TotalPrice
        {
            get { return (double)GetValue(TotalPriceProperty); }
            set { SetValue(TotalPriceProperty, value); }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = Tickets.Sum(ticket => ticket.Price * ticket.SelectedDiscount!.PriceMultiplier);
        }
    }
}
