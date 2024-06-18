namespace TicketBooking.classes
{
    public class TicketType : Notifier
    {
        public int Id { get; set; }
        public int SeatType { get; set; }
        public string? Color { get; set; }
        public string? TicketName {  get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public List<Discount>? Discounts { get; set; }
        private int numOfSelectedDiscounts;
        public int NumOfSelectedDiscounts
        {
            get { return numOfSelectedDiscounts; }
            set
            {
                numOfSelectedDiscounts = value;
                OnPropertyChanged();
            }
        }
        private int numOfTickets;
        public int NumOfTickets
        {
            get { return numOfTickets; }
            set
            {
                numOfTickets = value;
                OnPropertyChanged();
            }
        }
    }
}