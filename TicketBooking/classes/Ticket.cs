namespace TicketBooking.classes
{
    public class Ticket : Notifier
    {
        public int Id { get; set; }
        public Seat? Seat { get; set; }
        public string? Name {  get; set; }
        public double Price { get; set; }
        private Discount? _selectedDiscount;
        public Discount? SelectedDiscount
        {
            get { return _selectedDiscount; }
            set
            {
                _selectedDiscount = value;
                OnPropertyChanged();
            }
        }
    }
}