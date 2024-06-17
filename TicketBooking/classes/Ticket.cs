namespace TicketBooking.classes
{
    public class Ticket
    {
        public int Id { get; set; }
        public Seat? Seat { get; set; }
        public string? Name {  get; set; }
        public double Price { get; set; }
        public Discount? SelectedDiscount { get; set; }
    }
}