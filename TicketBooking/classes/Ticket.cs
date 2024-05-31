namespace TicketBooking.classes
{
    internal class Ticket
    {
        public SeatType SeatType { get; set; }
        public string? TicketName {  get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public List<double>? Discounts { get; set; }
    }
}
